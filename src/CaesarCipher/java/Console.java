import java.io.*;

public class Console {
    public static String readLine() {
        BufferedReader buffer = new BufferedReader(new InputStreamReader(System.in));
        try {            
            return buffer.readLine();            
        } catch (IOException e) {
            System.err.println("An error occurred while reading input: " + e.getMessage());
        }
        return null;
    }

    public static void writeLine(String input){
        System.out.println(input);
    }
    
    public static void write(String input){
        System.out.print(input);
    }
}