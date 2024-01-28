using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpellChecker.Common;

[DebuggerDisplay("{Value}")]
internal record BkNode<T> where T : IComparable
{
    // https://en.wikipedia.org/wiki/BK-tree
    internal required ReadOnlyMemory<T> Value { get; init; }
    internal Dictionary<int, BkNode<T>> Children { get; } = [];

    public bool Has(int distance) => Children.ContainsKey(distance);
    public BkNode<T> At(int distance) =>
        Children.TryGetValue(distance, out var child) ? child : throw new NotSupportedException();

    public bool Add(int distance, BkNode<T> child) =>
        Children.TryAdd(distance, child);

    //public IEnumerable<(int distance, T[] value)> Search(T[] value, int maxDistance) =>
    //    throw new NotImplementedException();

    public override string ToString() => string.Join(Environment.NewLine, AsStrings(1, 0));

    public IEnumerable<string> AsStrings(int depth, int weight) =>
        new[] { new string('\t', depth) + $"{weight}: {Value}" }.Concat(
            Children.SelectMany(child => child.Value.AsStrings(depth + 1, child.Key))
            );

    public int Count() =>
        Children.Sum(child=>child.Value.Count()) + 1;
}
