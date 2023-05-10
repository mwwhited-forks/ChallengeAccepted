#![allow(unused)]

mod caesar;
use std::env;

fn main() {
    let (cmd, text, code) = inputs();
    let encoded = shift_cipher_encode(&text, &code);
    let decoded = shift_cipher_decode(&encoded, &code);

    println!("Command: {}", cmd);
    println!("Text: {}", text);
    println!("Key: {}", code);
    println!("Encode: {}", encoded);
    println!("Decode: {}", decoded);
}

fn inputs() -> (String, String, String) {
    let args: Vec<String> = env::args().collect();
    if args.len() >= 3 {
        (args[0].clone(), args[1].clone(), args[2].clone())
    } else {
        let message = caesar::input("message? ");
        let key = caesar::input("key? ");
        (args[0].clone(), message, key)
    }
}

pub fn clean_key(code: &str) -> String {
    code.chars()
        .filter(|c| c.is_alphabetic())
        .collect()
}

pub fn shift_cipher_encode(text: &str, code: &str) -> String {
    let code_chars = clean_key(code);
    text.chars()
        .enumerate()
        .map(|(i, c)| {
            let k = code_chars.chars().nth(i % code_chars.len()).unwrap();
            let o = caesar::char_offset(k);
            caesar::shift_cipher_encode_char(c, o)
        })
        .collect()
}

pub fn shift_cipher_decode(text: &str, code: &str) -> String {
    let code_chars = clean_key(code);
    text.chars()
        .enumerate()
        .map(|(i, c)| {
            let k = code_chars.chars().nth(i % code_chars.len()).unwrap();
            let o = caesar::char_offset(k);
            caesar::shift_cipher_decode_char(c, o)
        })
        .collect()
}


#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_clean_key() {
        assert_eq!("KEY", clean_key("123KEY*&"));
    }

    #[test]
    fn test_shift_cipher_encode() {
        let encoded = shift_cipher_encode("Hello World", "World");
        println!("{}", encoded);
        assert_eq!("Dscwr Kfcoz", encoded);
    }

    #[test]
    fn test_shift_cipher_decode() {
        let decoded = shift_cipher_decode("Dscwr Kfcoz", "World");
        println!("{}", decoded);
        assert_eq!("Hello World", decoded);
    }
}