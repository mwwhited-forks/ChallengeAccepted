using System.Diagnostics;

namespace PseudorandomNumberGenerator.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var lcg = LinearCongruentialGenerator.ZXSpecrum();
        var rand = new Random(0);
        var sw = new Stopwatch();
        int t = 0;

        var lcgs = new List<long>();
        var rands = new List<long>();

        var loops = 10_000_000;
        var passes = 10;

        Console.WriteLine("x\tLCG\t\t\t\tRAND\t\t\tDiff");
        for (var x = 0; x < passes; x++)
        {
            Console.Write($"{x:000}");
            sw.Restart();
            for (int i = 0; i < loops; i++)
            {
                t = lcg.Next();
            }
            sw.Stop();
            var lcgL = sw.ElapsedTicks;
            Console.Write($"\t{sw.Elapsed}");
            if (x != 0)lcgs.Add(sw.ElapsedTicks);

            sw.Restart();
            for (int i = 0; i < loops; i++)
            {
                t = lcg.Next();
            }
            sw.Stop();
            var randL = sw.ElapsedTicks;
            Console.Write($"\t{(lcgL > randL ? '>' : lcgL < randL ? '<' : '=')}");
            Console.Write($"\t{sw.Elapsed}");
            Console.Write($"\t{((randL - lcgL)> 0 ? "+" : "")}{randL - lcgL:0000000.00000000}");
            Console.WriteLine();
            if (x != 0) rands.Add(sw.ElapsedTicks);
        }

        var lcgA = lcgs.Average();
        var randA = rands.Average();

        Console.WriteLine($"!\t{lcgA:0000000.00000000}\t{(lcgA > randA ? '>' : lcgA < randA ? '<' : '=')}\t{randA:0000000.00000000}\t{((randA - lcgA) > 0 ? "+" : "")}{randA-lcgA:0000000.00000000}");
    }
}
