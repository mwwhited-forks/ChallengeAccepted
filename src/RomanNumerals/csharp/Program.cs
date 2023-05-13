using System;

namespace RomanNumerals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var converter = new RomanNumeral();
            var value = GetInt(args);
            var converted = converter.Convert(value);
            var convertedBack = converter.Convert(converted);

            Console.WriteLine($"Command: {Environment.GetCommandLineArgs()[0]}({converter})");
            Console.WriteLine($"{nameof(value)}: {value}");
            Console.WriteLine($"{nameof(converted)}: {converted}");
            Console.WriteLine($"{nameof(convertedBack)}: {convertedBack}");
        }

        public static int GetInt(string[] args)
        {
            while (true)
            {
                var input = Inputs(args);
                if (int.TryParse(input, out var value)) return value;
            }
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
