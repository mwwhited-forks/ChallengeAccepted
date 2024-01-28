using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellChecker.Common;

public record BkTree<T> where T : IComparable
{
    public IEditDistance EditDistance { get; init; } = new WagnerFischerDistance();

    private BkNode<T>? _root;

    public IEnumerable<(int distance, ReadOnlyMemory<T> value)> Search(ReadOnlyMemory<T> value, int maxDistance) =>
        Search(_root, [], value, maxDistance).AsReadOnly();

    private List<(int distance, ReadOnlyMemory<T> value)> Search(BkNode<T>? node, List<(int distance, ReadOnlyMemory<T> value)> results, ReadOnlyMemory<T> needle, int maxDistance)
    {
        if (node != null)
        {
            var currentDistance = EditDistance.Calculate(node.Value.Span, needle.Span);

            if (currentDistance <= 0)
                results.Add((currentDistance, node.Value));

            var min = currentDistance - maxDistance;
            var max = currentDistance + maxDistance;

            foreach (var key in node.Children.Keys.Where(k => min <= k && k <= max))
                Search(node.At(key), results, needle, maxDistance);
        }
        return results;
    }

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

    public override string ToString() => _root?.ToString() ?? "<empty>";
    public int Count() => _root?.Count() ?? 0;
}
