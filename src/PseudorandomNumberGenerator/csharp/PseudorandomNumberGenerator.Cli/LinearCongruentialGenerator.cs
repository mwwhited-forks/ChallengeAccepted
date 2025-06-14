namespace PseudorandomNumberGenerator.Cli;

public class LinearCongruentialGenerator : IGenerator
{
    // https://en.wikipedia.org/wiki/Linear_congruential_generator

    public static IGenerator ZXSpecrum(int? seed = default) =>
        new LinearCongruentialGenerator(
            seed: seed ?? (int)(DateTime.Now.Ticks % int.MaxValue),
            a: 75,
            m: (int)Math.Pow(2, 16) + 1,
            c: 0
            );

    public LinearCongruentialGenerator(int seed, int a, int m, int c)
    {
        Seed = seed;
        Xn = Seed % m;
        A = a;
        C = c;
        M = m;
    }

    public int Seed { get; init; }
    public int A { get; init; }
    public int C { get; init; }
    public int M { get; init; }

    public int Xn { get; private set; }

    public int Next() => Xn = (A * Xn + C) % M;
}