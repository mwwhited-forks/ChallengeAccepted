import java.io.*;

public class Program
{
    public static void main(String[] args)
    {
        var inputs = Inputs(args);
        var cipher = getCipher(inputs);

        Console.writeLine("Command: " + cipher);
        Console.writeLine("Text: " + inputs.message());
        Console.writeLine("Code: " + inputs.code());

        var encoded = cipher.Encode(inputs.message(), inputs.code());
        Console.writeLine("Encoded: " + encoded);

        var decoded = cipher.Decode(encoded, inputs.code());    
        Console.writeLine("Decoded: " + decoded);
    }

    public static Response Inputs(String[] args)
    {
        if (args.length >= 2)
        {
            return new Response(args[0],args[1]);
        }
        else
        {
            Console.write("message? ");
            var message = Console.readLine();
            
            Console.write("code? ");
            var code = Console.readLine();

            return new Response(message,code);
        }
    }

    public static CipherInterface getCipher(Response request){
        return request.code().length() == 1 ?
            new CaesarCipher() :
            new VigenereCipher();
    }
}

record Response (String message, String code){};