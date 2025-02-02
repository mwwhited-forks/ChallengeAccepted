using System;
using System.Collections.Generic;
using System.Linq;

namespace GridLayout.Cli;

public static class TileColorsExtensions
{
    public static ConsoleColor ToConsoleColor(this TileColors tile) => tile switch
    {
        TileColors.Yellow => ConsoleColor.Yellow,
        TileColors.Green => ConsoleColor.Green,
        TileColors.Blue => ConsoleColor.Blue,
        TileColors.Pink => ConsoleColor.Red,
        TileColors.Orange => ConsoleColor.Magenta,
        _ => ConsoleColor.White,
    };

    public static (IEnumerable<string> lines, IEnumerable<string> colors) ToRows(this TileColors[,] tiles)
    {
        var lines = new List<string>();
        var colorLines = new List<string>();

        var rows = tiles.GetUpperBound(0) + 1;
        var columns = tiles.GetUpperBound(1) + 1;

        var headers = "\t" + string.Join("\t", Enumerable.Range(1, columns));
        Console.ForegroundColor = ConsoleColor.White;
        Console.ResetColor();
        Console.WriteLine(headers);

        for (var y = 0; y < rows; y++)
        {
            Console.ResetColor();
            Console.Write(y + 1);

            var row = new TileColors[columns];
            for (var x = 0; x < row.Length; x++)
            {
                var tile = row[x] = tiles[y, x];
                Console.ForegroundColor = tile.ToConsoleColor();
                Console.Write("\t{0}", tile);
            }
            Console.ResetColor();
            Console.WriteLine();

            var line = string.Join("\t", row.Select(r => (int)r));
            var colorLine = string.Join("\t", row);
            lines.Add(line);
            colorLines.Add(colorLine);
        }

        return (lines, colorLines);
    }

    //public static TileColors[,] EnsureUniqueNeighbors(this TileColors[,] tiles)
    //{
    //    var rows = tiles.GetUpperBound(0) + 1;
    //    var columns = tiles.GetUpperBound(1) + 1;
    //    var colors = Enum.GetValues<TileColors>().Aggregate(TileColors.None, (i, v) => i | v);
    //    for (var y = 0; y < rows; y++)
    //    {
    //        for (var x = 0; x < columns; x++)
    //        {
    //            var current = (x, y);
    //            var up = current.Up(ref rows);
    //            var down = current.Down(ref rows);
    //            var left = current.Left(ref columns);
    //            var right = current.Right(ref columns);
    //            var existing = tiles.Get(ref current) | tiles.Get(ref up) | tiles.Get(ref down) | tiles.Get(ref left) | tiles.Get(ref right);
    //            var missing = colors & ~existing;
    //           // if (missing != TileColors.None) throw new Exception($"Missing \"{missing}\" near ({current.x}, {current.y})");
    //        }
    //    }
    //    return tiles;
    //}
}