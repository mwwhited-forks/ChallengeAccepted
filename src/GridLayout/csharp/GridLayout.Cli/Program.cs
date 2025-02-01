using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GridLayout.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var rows = 13;
        var columns = 12;

        var colors = Enum.GetValues<TileColors>()
            .Where(t => t != TileColors.None)
            .ToArray();

        var rand = new Random();

        var tiles = new TileColors[rows, columns];

        for (var iy = 0; iy <= rows; iy++)
        {
            for (var ix = 0; ix <= columns; ix++)
            {
                Console.ForegroundColor = ConsoleColor.White;

                if (ix == 0 && iy == 0)
                {
                    Console.Write($"\t");
                }
                else if (ix == 0 && iy != 0)
                {
                    Console.Write($"{iy}\t");
                }
                else if (ix != 0 && iy == 0)
                {
                    Console.Write($"{ix}\t");
                }
                else
                {
                    var (x, y) = (ix - 1, iy - 1);

                    (int y, int x)[] neighborIndexes =
                    [
                        //((y + rows -1) % rows,(x + columns -1) % columns),
                        ((y + rows -1) % rows,(x + columns +0) % columns),
                        //((y + rows -1) % rows,(x + columns +1) % columns),
                        ((y + rows +0) % rows,(x + columns -1) % columns),
                        //((y + rows +0) % rows,(x + columns +0) % columns),
                        ((y + rows +0) % rows,(x + columns +1) % columns),
                        //((y + rows +1) % rows,(x + columns -1) % columns),
                        ((y + rows +1) % rows,(x + columns +0) % columns),
                        //((y + rows +1) % rows,(x + columns +1) % columns),
                    ];

                    TileColors[] neighbors = neighborIndexes.Select(i => tiles[i.y, i.x]).ToArray();
                    var possible = colors.Except(neighbors).ToArray();
                    if (possible.Length == 0)
                    {
                        possible = colors;
                    }

                    var tile = possible[rand.Next() % possible.Length];
                    tiles[y, x] = tile;
                    Console.ForegroundColor = Map(tile);
                    Console.Write($"{tile}\t");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();


        }

        var lines = new List<string>();
        var colorLines = new List<string>();
        for (var y = 0; y < rows; y++)
        {
            var r = new TileColors[columns];
            for (var x = 0; x < columns; x++)
            {
                r[x] = tiles[y, x];
            }
            var l = string.Join("\t", r.Select(r => (int)r));
            var l2 = string.Join("\t", r);
            lines.Add(l);
            colorLines.Add(l2);
        }
        File.WriteAllLines("results.txt", lines);
        File.WriteAllLines("colors.txt", colorLines);
    }
    private static ConsoleColor Map(TileColors tile) => tile switch
    {
        TileColors.None => ConsoleColor.White,
        TileColors.Yellow => ConsoleColor.Yellow,
        TileColors.Green => ConsoleColor.Green,
        TileColors.Blue => ConsoleColor.Blue,
        TileColors.Pink => ConsoleColor.Red,
        TileColors.Orange => ConsoleColor.Magenta,
    };
}

public enum TileColors
{
    None,
    Orange,
    Yellow,
    Pink,
    Blue,
    Green,
}