using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Common;
using System;
using System.IO;
using System.Linq;

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
    public void AnotherTreeTest()
    {
        // https://en.wikipedia.org/wiki/BK-tree
        // https://www.geeksforgeeks.org/bk-tree-introduction-implementation/

        var tree = new BkTree<char>()
        {
            EditDistance = new WagnerFischerDistance(),
        };

        var words = new[]
        {
            "hell",
            "help",
            "shell",
            "smell",
            "fell",
            "felt",
            "oops",
            "pop",
            "oouch",
            "halt",
        };

        foreach (var word in words)
        {
            tree.Add(word.AsMemory());
        }

        TestContext.WriteLine(tree.ToString());

        Assert.Inconclusive();
    }

    private static BkTree<char>? _tree;
    private BkTree<char> Build()
    {
        using var resource = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".wordlist.txt") ??
            throw new NotSupportedException();
        using var reader = new StreamReader(resource);
        var tree = new BkTree<char>();

        while (reader.Peek() != -1)
            tree.Add(reader.ReadLine().AsMemory());

        return tree;
    }


    [DataTestMethod, TestCategory("Unit")]
    [DataRow("hello", 0, "hello")]
    [DataRow("helo", 1, "hero")]
    [DataRow("littel", 1, "lintel")]
    [DataRow("little", 0, "little")]
    public void FullTest(string needle, int firstDistance, string firstValue)
    {
        _tree ??= Build();

        TestContext.WriteLine($"total nodes: {_tree.Count()}");

        TestContext.WriteLine(new string('-', 10));

        var result = _tree.Search(needle.AsMemory(), needle.Length / 2).OrderBy(i => i.distance);
        TestContext.WriteLine(string.Join(Environment.NewLine, result));

        TestContext.WriteLine(new string('-', 10));
        TestContext.WriteLine(_tree.ToString());

        var first = result.First();

        Assert.AreEqual(firstDistance, first.distance);
        Assert.AreEqual(firstValue, new string(first.value.ToArray()));
    }
}
