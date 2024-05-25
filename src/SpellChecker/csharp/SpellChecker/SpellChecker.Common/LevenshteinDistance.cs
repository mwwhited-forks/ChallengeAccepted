using System;
using System.Linq;

namespace SpellChecker.Common;

public class LevenshteinDistance : IEditDistance
{
    public int Calculate<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right) where T : IComparable =>
        left.Length == 0 ? right.Length :
        right.Length == 0 ? left.Length :
        left[0].CompareTo(right[0]) == 0 ? Calculate(left[1..], right[1..]) :
        1 + new[]{
            Calculate(left[1..], right),
            Calculate(left, right[1..]),
            Calculate(left[1..], right[1..]),
            }.Min();
}
