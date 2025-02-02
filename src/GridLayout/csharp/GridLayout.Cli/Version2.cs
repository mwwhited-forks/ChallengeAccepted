using System;
using System.Linq;

namespace GridLayout.Cli;

public class Version2
{
    public static TileColors[,] Execute(int rows = 13, int columns = 12)
    {
        var colors = Enum.GetValues<TileColors>().Aggregate(TileColors.None, (i, v) => i | v);

        var rand = new Random();
        var tiles = new TileColors[rows, columns];

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < columns; x++)
            {
                var current = (x, y);
                var up = current.Up(ref rows);
                var down = current.Down(ref rows);
                var left = current.Left(ref columns);
                var right = current.Right(ref columns);

                var existing = tiles.Get(ref up) | tiles.Get(ref down) | tiles.Get(ref left) | tiles.Get(ref right);
                var possible = colors & ~existing;
            again:
                var filtered = (TileColors)(rand.Next((int)colors) & (int)possible );
                var tile = filtered switch
                {
                    TileColors t when (t & TileColors.Green) != 0 => TileColors.Green,
                    TileColors t when (t & TileColors.Blue) != 0 => TileColors.Blue,
                    TileColors t when (t & TileColors.Pink) != 0 => TileColors.Pink,
                    TileColors t when (t & TileColors.Yellow) != 0 => TileColors.Yellow,
                    TileColors t when (t & TileColors.Orange) != 0 => TileColors.Orange,
                    _ => TileColors.None,
                };
                if (tile== TileColors.None)goto again;
                tiles[y, x] = tile;
            }
        }

        return tiles;
    }
}