import java.io.*;

public class Program
{
    public static void main(String[] args)
    {
        var cipher = new MorseCode();
        var message = Inputs(args);
        var encoded = cipher.Encode(message);
        var decoded = cipher.Decode(encoded);
    
        Console.writeLine("Command: " + cipher);
        Console.writeLine("Text: " + message);
        Console.writeLine("Encoded: " + encoded);
        Console.writeLine("Decoded: " + decoded);
    }

    public static String Inputs(String[] args)
    {
        if (args.length >= 1)
        {
            return args[0];
        }
        else
        {
            Console.write("message? ");
            var message = Console.readLine();

            return message;
        }
    }
}