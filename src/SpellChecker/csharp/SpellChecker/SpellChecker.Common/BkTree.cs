using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpellChecker.Common;

public record BkTree<T> where T : IComparable
{
    public IEditDistance EditDistance { get; init; } = new WagnerFischerDistance();

    private BkNode? _root;

    public IEnumerable<(int distance, ReadOnlyMemory<T> value)> Search(ReadOnlyMemory<T> value, int allowance) =>
        _root?.Search(EditDistance, value, allowance) ?? Enumerable.Empty<(int, ReadOnlyMemory<T>)>();

    public void Add(ReadOnlyMemory<T> value)
    {
        if (_root == null)
        {
            _root = new() { Value = value };
            return;
        }

        var current = _root;
        var distance = EditDistance.Calculate(_root.Value.Span, value.Span);
        while (current.Has(distance))
        {

            var at = current.At(distance);
            current = at;
            distance = EditDistance.Calculate(current.Value.Span, value.Span);
            if (distance == 0)
                return;
        }

        if (!current.Add(distance, new() { Value = value }))
            throw new NotSupportedException();
    }

    public void Add(IEnumerable<ReadOnlyMemory<T>> set)
    {
        foreach(var item in set)    
            Add(item);
    }

    public override string ToString() => _root?.ToString() ?? "<empty>";
    public int Count() => _root?.Count() ?? 0;


    [DebuggerDisplay("{Value}")]
    internal record BkNode
    {
        // https://en.wikipedia.org/wiki/BK-tree
        internal required ReadOnlyMemory<T> Value { get; init; }
        private Dictionary<int, BkNode> Children { get; } = [];

        public bool Has(int distance) => Children.ContainsKey(distance);
        public BkNode At(int distance) =>
            Children.TryGetValue(distance, out var child) ? child : throw new NotSupportedException();

        public bool Add(int distance, BkNode child) =>
            Children.TryAdd(distance, child);

        public IEnumerable<(int distance, ReadOnlyMemory<T> value)> Search(
            IEditDistance editDistance,
            ReadOnlyMemory<T> value,
            int allowance
            )
        {
            if (Value.Length == 0)
                yield break;

            var currentDistance = editDistance.Calculate(Value.Span, value.Span);

            if (currentDistance <= allowance)
                yield return (currentDistance, Value);

            var min = currentDistance - allowance;
            var max = currentDistance + allowance;


            var similar = from child in Children
                          where min <= child.Key && child.Key <= max
                          from kinda in child.Value.Search(editDistance, value, allowance)
                          select kinda;

            foreach (var child in similar)
                yield return child;
        }


        public override string ToString() => string.Join(Environment.NewLine, AsStrings(1, 0));

        public IEnumerable<string> AsStrings(int depth, int weight) =>
            new[] { new string('\t', depth) + $"{weight}: {Value}" }.Concat(
                Children.SelectMany(child => child.Value.AsStrings(depth + 1, child.Key))
                );

        public int Count() =>
            Children.Sum(child => child.Value.Count()) + 1;

    }
}
