#![allow(unused)]

use std::env;
use std::io::{self, Write};

fn main() {
    let (cmd, text, code) = inputs();
    let encoded = shift_cipher_encode(&text, code);
    let decoded = shift_cipher_decode(&encoded, code);

    println!("Command: {}", cmd);
    println!("Text: {}", text);
    println!("Key: {}", code);
    println!("Encode: {}", encoded);
    println!("Decode: {}", decoded);
}

fn inputs() -> (String, String, char) {
    let args: Vec<String> = env::args().collect();
    if args.len() >= 3 {
        (
            args[0].clone(),
            args[1].clone(),
            args[2].chars().next().unwrap(),
        )
    } else {
        (
            args[0].clone(),
            input("message? "),
            input("key? ").chars().next().unwrap(),
        )
    }
}

pub fn input(prompt: &str) -> String {
    print!("{}", prompt);
    io::stdout().flush().unwrap();

    let mut input = String::new();
    io::stdin().read_line(&mut input).unwrap();
    input.trim_end().to_owned()
}

pub fn char_offset(input: char) -> u8 {
    match input {
        'A'..='Z' => input as u8 - b'A',
        'a'..='z' => input as u8 - b'a',
        _ => 0,
    }
}

pub fn shift_cipher_encode(text: &str, code: char) -> String {
    let shift = char_offset(code);
    text.chars()
        .map(|c| shift_cipher_encode_char(c, shift))
        .collect()
}

pub fn shift_cipher_encode_char(c: char, shift: u8) -> char {
    if c.is_ascii_alphabetic() {
        let start = if c.is_ascii_uppercase() { b'A' } else { b'a' };
        let adjusted_char = ((c as u8 - start + shift) % 26 + start) as char;
        adjusted_char
    } else {
        c
    }
}

pub fn shift_cipher_decode(text: &str, code: char) -> String {
    let shift = char_offset(code);
    text.chars()
        .map(|c| shift_cipher_decode_char(c, shift))
        .collect()
}

pub fn shift_cipher_decode_char(c: char, shift: u8) -> char {
    if c.is_ascii_alphabetic() {
        let start = if c.is_ascii_uppercase() { b'A' } else { b'a' };
        let adjusted_char = ((c as u8 - start + 26 - shift) % 26 + start) as char;
        adjusted_char
    } else {
        c
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_char_offset() {
        assert_eq!(char_offset('A'), 0);
        assert_eq!(char_offset('a'), 0);
        assert_eq!(char_offset('Z'), 25);
        assert_eq!(char_offset('z'), 25);
    }

    #[test]
    fn test_shift_cipher_encode() {
        assert_eq!(shift_cipher_encode("hello", 'a'), "hello");
        assert_eq!(shift_cipher_encode("hello", 'b'), "ifmmp");
    }

    #[test]
    fn test_shift_cipher_decode() {
        assert_eq!(shift_cipher_decode("hello", 'a'), "hello");
        assert_eq!(shift_cipher_decode("ifmmp", 'b'), "hello");
    }
}