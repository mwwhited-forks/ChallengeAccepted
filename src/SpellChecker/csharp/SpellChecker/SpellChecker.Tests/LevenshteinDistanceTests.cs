using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Common;

namespace SpellChecker.Tests;

[TestClass]
public class LevenshteinDistanceTests
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod, TestCategory("Unit")]
    [DataRow("can", "can", 0)]
    [DataRow("cat", "can", 1)]
    [DataRow("can", "fat", 2)]
    [DataRow("can", "fater", 4)]
    [DataRow("smart", "blend", 5)]
    public void CalculateTest(string left, string right, int expectedDistance)
    {
        var result = new LevenshteinDistance().Calculate<char>(left, right);
        TestContext.WriteLine($"\"{left}\"->\"{right}\" Levenshtein distance:  {result}");
        Assert.AreEqual(expectedDistance, result);
    }
}
