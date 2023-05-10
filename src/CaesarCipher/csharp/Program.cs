using System;

namespace CaesarCipher;
public class Program
{
    public static void Main(string[] args)
    {
        var (message, key) = Inputs(args);

        var (cipher, code, encoded, decoded) = key.Length switch
        {
            1 => Caesar(message, key[0]),
            _ => Vigenere(message, key),
        };

        Console.WriteLine($"Command: {Environment.GetCommandLineArgs()[0]}({cipher})");
        Console.WriteLine($"Text: {message}");
        Console.WriteLine($"Key: {code}");
        Console.WriteLine($"Encoded: {encoded}");
        Console.WriteLine($"Decoded: {decoded}");
    }

    public static (object cipher, object code, string encoded, string decoded) Caesar(string message, char key)
    {
        var cipher = new Caesar();
        var encoded = cipher.Encode(message, key);
        var decoded = cipher.Decode(encoded, key);
        return (cipher, key, encoded, decoded);
    }
    public static (object cipher, object code, string encoded, string decoded) Vigenere(string message, string key)
    {
        var cipher = new Vigenere();
        var encoded = cipher.Encode(message, key);
        var decoded = cipher.Decode(encoded, key);
        return (cipher, key, encoded, decoded);
    }

    public static (string? message, string? key) Inputs(string[] args)
    {
        if (args.Length >= 2)
        {
            return (args[0], args[1]);
        }
        else
        {
            Console.Write("message? ");
            var message = Console.ReadLine()?.TrimEnd();

            Console.Write("key? ");
            var key = Console.ReadLine()?.TrimEnd();

            return (message, key);
        }
    }
}
