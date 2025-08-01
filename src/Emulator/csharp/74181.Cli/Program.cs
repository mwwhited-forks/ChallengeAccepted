using System.Collections;

namespace _74181.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        for (byte s = 0; s < 16; s++)
        {
            bool m = false;
            //bool[] s = [false, false, false, false];
            // ((s[3] ? 0b1000 : 0) + (s[2] ? 0b0100 : 0) + (s[1] ? 0b0010 : 0) + (s[0] ? 0b0001 : 0))

            bool c = false;
            uint a = 5;
            uint b = 8;


            var (q, c0) = SN74F181.Compute(m, s, c, a, b);

            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine($"\tm={m}");
            //Console.WriteLine($"\ts={s:x4}");
            //Console.WriteLine($"\tc={c}");
            //Console.WriteLine($"\ta={a:x4}");
            //Console.WriteLine($"\tb={b:x4}");
            //Console.WriteLine($"\tq={result.q:x4}, c={result.c}");


            Console.WriteLine($"{m}\t{s:x2}\t{c}\t{a:x2}\t{b:x2}\t{q:x2}\t{c0}");
        }
    }
}

public class SN74F181
{
    // https://en.wikipedia.org/wiki/74181

    public static (uint q, bool c) Compute(bool m, bool[] s, bool c, uint a, uint b)
    {
        if (s.Length != 4) throw new ArgumentOutOfRangeException(nameof(s));
        return Compute(m, s[3], s[2], s[1], s[0], c, a, b);
    }

    public static (uint q, bool c) Compute(byte s, bool c, uint a, uint b)
    {
        if (s > 0b1_1111) throw new ArgumentOutOfRangeException(nameof(s));
        var bits = new BitArray([s]);
        return Compute(bits[4], bits[3], bits[2], bits[1], bits[0], c, a, b);
    }

    public static (uint q, bool c) Compute(bool m, byte s, bool c, uint a, uint b)
    {
        if (s > 0b1111) throw new ArgumentOutOfRangeException(nameof(s));
        var bits = new BitArray([s]);
        return Compute(m, bits[3], bits[2], bits[1], bits[0], c, a, b);
    }

    public static (uint q, bool c) Compute(bool m, bool s3, bool s2, bool s1, bool s0, bool c, uint a, uint b)
    {
        uint mask = 0x000000ff;

        a &= mask;
        b &= mask;

        if (m) // logic
        {
            uint result = (s3, s2, s1, s0) switch
            {
                (false, false, false, false) => ~a,
                (false, false, false, true) => ~(a | b),
                (false, false, true, false) => ~a & b,
                (false, false, true, true) => 0,
                (false, true, false, false) => ~(a & b),
                (false, true, false, true) => ~b,
                (false, true, true, false) => a ^ b,
                (false, true, true, true) => a & ~b,
                (true, false, false, false) => ~a | b,
                (true, false, false, true) => ~(a ^ b),
                (true, false, true, false) => b,
                (true, false, true, true) => a & b,
                (true, true, false, false) => 1,
                (true, true, false, true) => a | ~b,
                (true, true, true, false) => a | b,
                (true, true, true, true) => a,
            };

            uint realResult = (uint)(result & mask);
            bool carryOut = (result & ~mask) == 0;
            return (realResult, carryOut);
        }
        else // arithmetic 
        {
            unchecked
            {
                long result = (s3, s2, s1, s0) switch
                {
                    (false, false, false, false) => a,
                    (false, false, false, true) => (a | b),
                    (false, false, true, false) => a | ~b,
                    (false, false, true, true) => (uint)-1,
                    (false, true, false, false) => a + (a & ~b),
                    (false, true, false, true) => (a | b) + (a & ~b),
                    (false, true, true, false) => a - b - 1,
                    (false, true, true, true) => (a & ~b) - 1,
                    (true, false, false, false) => a + (a & b),
                    (true, false, false, true) => a + b - 1,
                    (true, false, true, false) => (a | ~b) + (a & b),
                    (true, false, true, true) => (a & b) - 1,
                    (true, true, false, false) => a + a,
                    (true, true, false, true) => (a | b) + a,
                    (true, true, true, false) => (a | ~b) + a,
                    (true, true, true, true) => a - 1,
                } + (c ? 0 : 1);

                uint realResult = (uint)(result & mask);
                return (realResult, (result & ~mask) == 0);
            }
        }
    }

}