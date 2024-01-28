using System;

namespace SpellChecker.Common;

public interface IEditDistance
{
    int Calculate<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right) where T : IComparable;
}
