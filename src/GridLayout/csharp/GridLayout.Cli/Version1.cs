using System;
using System.Linq;

namespace GridLayout.Cli;

public class Version1
{
    public static TileColors[,] Execute(int rows = 13, int columns = 12)
    {
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
                    Console.ForegroundColor = tile.ToConsoleColor();
                    Console.Write($"{tile}\t");
                }
                Console.WriteLine();
            }
        }

        Console.ResetColor();

        return tiles;
    }

}