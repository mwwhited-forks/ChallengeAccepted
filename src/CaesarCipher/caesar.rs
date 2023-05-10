#![allow(unused)]

use std::env;

fn main() {
    let (cmd, text, code) = inputs();
    let encoded =  shift_cipher_encode(&text, code);
    let decoded =  shift_cipher_decode(&encoded, code);

    println!("Command: {}", cmd);
    println!("Text: {}", text);
    println!("Key: {}", code);
    println!("Encode: {}", encoded);
    println!("Decode: {}", decoded);
}

pub fn inputs() -> (String, String, char) {
    let args: Vec<String> = env::args().collect();
    if args.len() >= 3 {
        return (args[0].clone(), args[1].clone(), args[2].chars().nth(0).unwrap());
    } else {
        return (args[0].clone(), "Hello, world!".to_string(), 'H')
    }
}

pub fn char_offset(input: char) -> u8 {
    let start = match input {
        'A'..='Z' => 'A',
        'a'..='z' => 'a',
        _ => input
    } as u8;
    let ret = input as u8 - start;
    ret
}

pub fn shift_cipher_encode(text: &str, code: char) -> String {
    let shift = char_offset(code);
    let mut cipher_text = String::new();
    for c in text.chars()
    {
        cipher_text.push(shift_cipher_encode_char(c, shift))
    }
    cipher_text
}
pub fn shift_cipher_encode_char(c: char, shift: u8) -> char{
    if c.is_alphabetic() {
        let start = match c  {
            'A'..='Z' => b'A' as u16,
            'a'..='z' => b'a' as u16,
            _ => c as  u8 as u16
        };
        let adjusted_char= (c as u8 as u16 + shift as u16 - start) % 26u16;
        let adjusted_char_back = adjusted_char + start;
        adjusted_char_back as u8 as char
    } else {
        c
    }
}

pub fn shift_cipher_decode(text: &str, code: char) -> String {
    let shift = char_offset(code);
    let mut cipher_text = String::new();
    for c in text.chars()
    {
        cipher_text.push(shift_cipher_decode_char(c, shift))
    }
    cipher_text
}
pub fn shift_cipher_decode_char(c: char, shift: u8) -> char{
    if c.is_alphabetic() {
        let start = match c  {
            'A'..='Z' => 'A',
            'a'..='z' => 'a',
            _ => c
        } as  u8 as u16;
        let adjusted_char = c as u8 as u16 - start;
        let shifted_char = adjusted_char + 26u16 - shift as u16;
        let mod_char  = shifted_char % 26u16;
        let adjusted_char_back = (mod_char + start) as u8 as char;
        adjusted_char_back
    } else {
        c
    }
}
