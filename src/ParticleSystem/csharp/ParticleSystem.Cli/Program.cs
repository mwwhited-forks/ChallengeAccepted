using System.Drawing;
using System.Numerics;

namespace ParticleSystem.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var origin = new Vector2(Console.WindowWidth / 2,2);
        var particleSystem = new ParticleSystem(origin);

        static int ValueX(Vector2 value) =>
            Math.Max(Math.Min(Console.WindowWidth - 1, (int)(value.X / 5)),0);

        static int ValueY(Vector2 value) =>
            Math.Max(Math.Min(Console.WindowHeight - 1, (int)(value.Y / 5)), 0);

        var p = 0;
        while (true)
        {
            Console.Clear();
            particleSystem.Add();
            particleSystem.Run();
            p++;

            foreach (var particle in particleSystem.Particles)
            {
                //Console.WriteLine($"{p} {ValueX(particle.Position)}, {ValueY(particle.Position)}");
                Console.SetCursorPosition(ValueX(particle.Position) + Console.WindowWidth / 2, ValueY(particle.Position));
                Console.Write(".");

            }

            Task.Delay(50).Wait();
        }

    }
}


public class Particle
{
    private static readonly Random Rand = new();

    public Particle(
        Vector2 position
        )
    {
        Acceleration = new Vector2(0, 0.5f);
        Velocity = new Vector2((float)Rand.NextDouble() * 2 - 1, (float)Rand.NextDouble() * 2 - 2);
        Position = position;
        LifeTime = 255;
    }

    public Vector2 Position { get; private set; }
    public Vector2 Velocity { get; private set; }
    public Vector2 Acceleration { get; private set; }
    public double LifeTime { get; private set; }

    public bool Update()
    {
        Velocity += Acceleration;
        Position += Velocity;
        LifeTime -= 1;

        return IsDead;
    }

    public bool IsDead => LifeTime < 0;

    public override string ToString() => $"{Position}";
}

public class ParticleSystem
{
    public ParticleSystem(
        Vector2 origin
        ) => Origin = origin;

    public Vector2 Origin { get; private set; }
    public List<Particle> Particles { get; } = [];

    public void Add() => Particles.Add(new Particle(Origin));

    public void Run()
    {
        foreach(var particle in Particles.ToArray())
            if (particle.Update())
                Particles.Remove(particle);
    }
}
