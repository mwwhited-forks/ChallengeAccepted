namespace HammingGenerator.Cli;

internal class Program
{
    public static uint Fact(uint value) =>
        (uint)Math.Ceiling(Math.Exp(Enumerable.Range(1, (int)value).Select(i => Math.Log(i)).Sum()));

    static void Main(string[] args)
    {
        uint[] bitDepths = [5, 8, 10, 12, 16];
        foreach (var bitDepth in bitDepths)
        {
            Console.WriteLine($"Bits: {bitDepth}");
            GenerateHammingDistanceData(bitDepth);
        }

        static void GenerateHammingDistanceData(uint bitdepth)
        {
            uint mask = (uint)Math.Pow(2, bitdepth) - 1;

            var masks = new List<(uint mask, uint distance)>();
            masks.Add((0, 0));

            var distance = bitdepth;

            //Console.WriteLine($"mask\tb:{Convert.ToString(mask, 2).PadLeft(15, '0')}");
            for (uint d = 0; d < bitdepth; d++)
            {
                var c = Fact(bitdepth) / (Fact(d) * Fact((uint)(bitdepth - d)));
                Console.WriteLine($"{d}\t{c}");
            }

            var set = new List<uint>();

            for (uint b = 0; b < bitdepth; b++)
            {
                uint v = (uint)(1 << (int)b);
                set.Add(v);
            }
            var idx = 0;
            foreach (var s in set)
            {
                // Console.WriteLine($"{1}-{Convert.ToString(s, 2).PadLeft(15, '0')}-({s:000})-{idx++:00}");
                masks.Add((s, 1));
            }

            for (uint d = 1; d < distance; d++)
            {
                var set2 = new List<uint>();
                foreach (var s in set.Distinct())
                {
                    uint v = (s << 1) + 1;
                    for (var x = 0; x <= bitdepth - d; x++)
                    {
                        var v2 = v << x;
                        if (v2 < mask)
                            set2.Add(v2 & mask);
                    }
                }
                set.Clear();
                set.AddRange(set2);
                set2.Clear();

                idx = 0;
                foreach (var s in set.Distinct().Order())
                {
                    //Console.WriteLine($"{d+1}-{Convert.ToString(s, 2).PadLeft(15, '0')}-({s:000})-{idx++:00}");
                    masks.Add((s, (uint)d + 1));
                }
            }
            masks.Add((mask, bitdepth));

            foreach (var s in masks)
            {
                Console.WriteLine($"{s.distance}-{Convert.ToString(s.mask, 2).PadLeft((int)bitdepth, '0')}");
            }

            File.WriteAllLines($"Hamming{bitdepth}.csv",
                from m in masks
                select $"{Convert.ToString(m.mask, 2).PadLeft((int)bitdepth, '0')},{m.distance:00},{m.mask:00000}"
                       );

            var r = new Random();
            var needle = (byte)(r.Next() & 0xff);

            var haystack = from m in masks
                           select new
                           {
                               m.distance,
                               m.mask,
                               match = m.mask ^ needle
                           };

            foreach (var s in haystack)
            {
                Console.WriteLine(s);
            }
        }
    }
}
