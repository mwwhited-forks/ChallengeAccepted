using System;

namespace SpellChecker.Common;

public class WagnerFischerDistance : IEditDistance
{
    public int Calculate<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right) where T : IComparable
    {
        var distance = new int[left.Length + 1, right.Length + 1];

        for (var j = 0; j <= right.Length; j++)
            for (var i = 0; i <= left.Length; i++)
            {
                distance[i, j] = (j, i) switch
                {
                    (0, _) => i,
                    (_, 0) => j,
                    (_, _) => Math.Min(Math.Min(
                        distance[i - 1, j] + 1,
                        distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + (left[i - 1].CompareTo(right[j - 1]) == 0 ? 0 : 1)
                        )
                };
            }

        return distance[left.Length, right.Length];

    }
}
