using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Common;
using System;
using System.IO;

namespace SpellChecker.Tests;

[TestClass]
public class BkTreeTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void TreeTest()
    {
        // https://en.wikipedia.org/wiki/BK-tree

        var tree = new BkTree<char>()
        {
            EditDistance = new WagnerFischerDistance(),
        };

        var words = new[]
        {
            "book",
            "books",
            "boo",
            "cake",
            "cape",
            "cart",
            "boom",
            "cook",
        };

        foreach (var word in words)
        {
            tree.Add(word.AsMemory());
        }

        TestContext.WriteLine(tree.ToString());

        Assert.Inconclusive();
    }

    [TestMethod]
    public void FullTest()
    {
        using var resource = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".wordlist.txt") ??
            throw new NotSupportedException();
        using var reader = new StreamReader(resource);

        var tree = new BkTree<char>();

        while (reader.Peek() != -1)
            tree.Add(reader.ReadLine().AsMemory());

        TestContext.WriteLine($"total nodes: {tree.Count()}");

        var result = tree.Search("helo".AsMemory(), 100);
        TestContext.WriteLine(string.Join(';',result));

        TestContext.WriteLine(tree.ToString());

        Assert.Inconclusive();
    }
}
