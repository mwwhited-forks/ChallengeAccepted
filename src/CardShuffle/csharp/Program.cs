using System;
using System.Linq;

namespace CardShuffle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builddeck = from suit in Enumerable.Range(0, 4)
                            from face in Enumerable.Range(0, 13)
                            select (suit << 4) | face;
            var deck = builddeck.ToArray();
            var shuffled = builddeck.Shuffle(new Random(1)).ToArray();
            // 0c;05;1a;2b;25;17;13;33;04;21;01;0a;3c;2c;1c;1b;31;18;3a;27;24;02;34;0b;19;23;37;07;16;39;30;12;10;00;14;26;36;15;2a;06;03;29;28;22;08;20;09;38;11;32;3b;35

            Console.WriteLine($"Command: {Environment.GetCommandLineArgs()[0]}({nameof(ShuffleExtensions)})");
            Console.WriteLine($"{nameof(deck)}: {string.Join(";", deck.Select(c => c.ToString("x2")))}");
            Console.WriteLine($"{nameof(shuffled)}: {string.Join(";", shuffled.Select(c => c.ToString("x2")))}");
        }
    }
}