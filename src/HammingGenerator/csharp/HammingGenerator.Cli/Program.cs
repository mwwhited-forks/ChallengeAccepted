namespace HammingGenerator.Cli;

internal class Program
{
    public static int Fact(int value) =>
        (int)Math.Ceiling(Math.Exp(Enumerable.Range(1, value).Select(i => Math.Log(i)).Sum()));

    static void Main(string[] args)
    {
        var bitdepth = 8;
        var mask = (int)Math.Pow(2, bitdepth) - 1;

        var masks = new List<(int mask, int distance)>();
        masks.Add((mask, 0));

        var distance = bitdepth;

        //Console.WriteLine($"mask\tb:{Convert.ToString(mask, 2).PadLeft(15, '0')}");
        for (var d = 0; d < bitdepth; d++)
        {
            var c = Fact(bitdepth) / (Fact(d) * Fact(bitdepth - d));
            // Console.WriteLine($"{d}\t{c}");
        }

        var set = new List<int>();

        for (var b = 0; b < bitdepth; b++)
        {
            var v = 1 << b;
            set.Add(v);
        }
        var idx = 0;
        foreach (var s in set)
        {
            // Console.WriteLine($"{1}-{Convert.ToString(s, 2).PadLeft(15, '0')}-({s:000})-{idx++:00}");
            masks.Add((mask - s, 1));
        }

        for (var d = 1; d < distance; d++)
        {
            var set2 = new List<int>();
            foreach (var s in set)
            {
                var v = (s << 1) + 1;
                for (var x = 0; x <= bitdepth - d; x++)
                {
                    var v2 = v << x;
                    if (v2 < mask)
                        set2.Add(v2);
                }
            }
            set.Clear();
            set.AddRange(set2);
            set2.Clear();

            idx = 0;
            foreach (var s in set.Distinct().Order())
            {
                //Console.WriteLine($"{d+1}-{Convert.ToString(s, 2).PadLeft(15, '0')}-({s:000})-{idx++:00}");
                masks.Add((mask - s, d));
            }
        }

        foreach (var s in masks)
        {
            Console.WriteLine($"{s.distance}-{Convert.ToString(s.mask, 2).PadLeft(bitdepth, '0')}");
        }
    }
}
