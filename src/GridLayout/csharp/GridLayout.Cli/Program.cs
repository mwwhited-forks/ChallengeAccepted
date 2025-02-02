using System.IO;

namespace GridLayout.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        //var tiles = Version1.Execute();
        var tiles = Version2.Execute();

        var (lines, colorLines) = tiles.ToRows();
        File.WriteAllLines("results.txt", lines);
        File.WriteAllLines("colors.txt", colorLines);
    }
}
