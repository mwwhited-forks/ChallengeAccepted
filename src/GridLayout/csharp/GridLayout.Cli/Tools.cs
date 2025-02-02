using System;
using System.Diagnostics.Contracts;

namespace GridLayout.Cli;

public static class Tools
{
    [Pure]
    public static (int x, int y) Up(this ref (int x, int y) position, ref int bound) => (position.x, position.y.Bound(-1, ref bound));
    [Pure]
    public static (int x, int y) Down(this ref (int x, int y) position, ref int bound) => (position.x, position.y.Bound(1, ref bound));
    [Pure]
    public static (int x, int y) Left(this ref (int x, int y) position, ref int bound) => (position.x.Bound(-1, ref bound), position.y);
    [Pure]
    public static (int x, int y) Right(this ref (int x, int y) position, ref int bound) => (position.x.Bound(1, ref bound), position.y);

    [Pure]
    public static int Bound(this ref int i, int offset, ref int bound) => (i + bound + offset) % bound;

    [Pure]
    public static T Get<T>(this T[,] array, ref (int x, int y) position) => array[position.y, position.x];
}
