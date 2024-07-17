using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System;

namespace csharp;

internal class Program
{
    public static string[] Responses = [
            "It is certain",
            "It is decidedly so",
            "Without a doubt",
            "Yes definitely",
            "You may rely on it",
            "As I see it, yes",
            "Most likely",
            "Outlook good",
            "Yes",
            "Signs point to yes",
            "Reply hazy, try again",
            "Ask again later",
            "Better not tell you now",
            "Cannot predict now",
            "Concentrate and ask again",
            "Don’t count on it",
            "My reply is no",
            "My sources say no",
            "Outlook not so good",
            "Very doubtful",
        ];

    static void Main()
    {
        var rand = new Random();
        do
        {
            Console.WriteLine(Responses[rand.Next(Responses.Length)]);

            Console.WriteLine("Press Escape to Exit");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
