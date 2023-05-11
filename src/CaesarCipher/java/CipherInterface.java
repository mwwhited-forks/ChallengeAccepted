public interface CipherInterface {
    String Encode(String message, String code);
    String Decode(String message, String code);
}