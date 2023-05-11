import java.util.*;
import java.util.stream.Collectors;

public class CaesarCipher implements CipherInterface
{

    public String Encode(String input, String code){
        var offset = GetOffset(code.charAt(0));
        
        return input == null ? "" : input.chars()
            .map(c -> Encode((char) c, offset))
            .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
            .toString();
    } 

    protected char Encode(char input, char code) {
        return Encode(input, GetOffset(code));
    }
    protected char Encode(char input, int offset) 
    {
        if (input >= 'A' && input <= 'Z') return (char)('A' + ((input - 'A' + offset) % 26));
        else if (input >= 'a' && input <= 'z') return (char)('a' + ((input - 'a' + offset) % 26));
        else return input;
    };

    public String Decode(String input, String code){
        var offset = GetOffset(code.charAt(0));
        
        return input == null ? "" : input.chars()
            .map(c -> Decode((char) c, offset))
            .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
            .toString();
    }
    protected char Decode(char input, char code) {
        return Decode(input, GetOffset(code));
    }
    protected char Decode(char input, int offset) 
    {
        if (input >= 'A' && input <= 'Z') return (char)('A' + ((input + 26 - 'A' - offset) % 26));
        else if (input >= 'a' && input <= 'z') return (char)('a' + ((input + 26 - 'a' - offset) % 26));
        else return input;
    };
    
    protected int GetOffset(char code) 
    {
        if (code >= 'A' && code <= 'Z') return code - 'A';
        else if (code >= 'a' && code <= 'z') return code - 'a';
        else throw new IllegalArgumentException("\"code\" must be between 'A' and 'Z'");
    };
}