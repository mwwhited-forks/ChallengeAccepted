import java.util.*;
import java.util.stream.*;

public class VigenereCipher extends CaesarCipher
{
    @Override
    public String Encode(String input, String code){
        String codeChars = CleanCode(code);
        return IntStream.range(0, input.length())
                .mapToObj(i -> Encode(input.charAt(i), codeChars.charAt(i % codeChars.length())))
                .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
                .toString();
    }

    @Override
    public String Decode(String input, String code){
        String codeChars = CleanCode(code);
        return IntStream.range(0, input.length())
                .mapToObj(i -> Decode(input.charAt(i), codeChars.charAt(i % codeChars.length())))
                .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
                .toString();
    }

    protected String CleanCode(String code){
        return code.chars()
                .filter(Character::isAlphabetic)
                .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
                .toString();
    } 
}