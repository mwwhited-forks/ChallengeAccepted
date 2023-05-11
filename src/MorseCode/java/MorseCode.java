import java.util.*;
import java.util.stream.Collectors;

public class MorseCode
{
    public String Encode(String input ){
        return input.chars()
            .mapToObj(c -> (char) c)
            .map(c -> EncodeChar(c))
            .collect(Collectors.joining(" "))
            .replace("  ", " ")
            ;
    }
    public String EncodeChar(char input) {
        return _map.get((char)( input > '_' ? input & 0b01011111 : input));
    }
    
    public String Decode(String input ){
        return Arrays.stream(input.split(" "))
            .map(c -> DecodeChar(c))
            .collect(Collectors.joining(""))
            ;
    }
    
    public String DecodeChar(String input) {
        var ret = Utilities.getKeyByValue(_map, input);
        if (ret == null) ret = ' ';
        return "" + ret;
    }

    Map<Character, String> _map = new HashMap<Character, String>(){{
        put('A', ".-"    );
        put('B', "-..."  );
        put('C', "-.-."  );
        put('D', "-.."   );
        put('E', "."     );
        put('F', "..-."  );
        put('G', "--."   );
        put('H', "...."  );
        put('I', ".."    );
        put('J', ".---"  );
        put('K', "-.-"   );
        put('L', ".-.."  );
        put('M', "--"    );
        put('N', "-."    );
        put('O', "---"   );
        put('P', ".--."  );
        put('Q', "--.-"  );
        put('R', ".-."   );
        put('S', "..."   );
        put('T', "-"     );
        put('U', "..-"   );
        put('V', "...-"  );
        put('W', ".--"   );
        put('X', "-..-"  );
        put('Y', "-.--"  );
        put('Z', "--.."  );
        put('1', ".----" );
        put('2', "..---" );
        put('3', "...--" );
        put('4', "....-" );
        put('5', "....." );
        put('6', "-...." );
        put('7', "--..." );
        put('8', "---.." );
        put('9', "----." );
        put('0', "-----" );
        put(' ', " "     );
        put('\n', "\r\n" );
    }};
}