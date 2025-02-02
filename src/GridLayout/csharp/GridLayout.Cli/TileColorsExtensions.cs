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
        for (var y = 0; y < tiles.GetUpperBound(0); y++)
        {
            var r = new TileColors[tiles.GetUpperBound(1)];
            for (var x = 0; x < r.Length; x++)
            {
                r[x] = tiles[y, x];
            }
            var l = string.Join("\t", r.Select(r => (int)r));
            var l2 = string.Join("\t", r);
            lines.Add(l);
            colorLines.Add(l2);
        }

        return (lines, colorLines);
    }
}