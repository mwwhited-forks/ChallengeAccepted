using System;

namespace MorseCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cipher = new MorseCode();
            var message = Inputs(args);
            var encoded = cipher.Encode(message);
            var decoded = cipher.Decode(encoded);

            Console.WriteLine($"Command: {Environment.GetCommandLineArgs()[0]}({cipher})");
            Console.WriteLine($"Text: {message}");
            Console.WriteLine($"Encoded: {encoded}");
            Console.WriteLine($"Decoded: {decoded}");
        }

        public static string? Inputs(string[] args)
        {
            if (args.Length >= 1)
            {
                return args[0];
            }
            else
            {
                Console.Write("message? ");
                var message = Console.ReadLine()?.TrimEnd();

                return message;
            }
        }
    }
}
