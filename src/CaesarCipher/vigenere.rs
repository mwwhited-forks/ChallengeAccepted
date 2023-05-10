#![allow(unused)]

mod caesar;
use std::env;

fn main() {
    let (cmd, text, code) = inputs();
    let encoded =  shift_cipher_encode(&text, &code);
    let decoded =  shift_cipher_decode(&encoded, &code);

    println!("Command: {}", cmd);
    println!("Text: {}", text);
    println!("Key: {}", code);
    println!("Encode: {}", encoded);
    println!("Decode: {}", decoded);
}

pub fn inputs() -> (String, String, String) {
    let args: Vec<String> = std::env::args().collect();
    if args.len() >= 3 {
        return (args[0].clone(), args[1].clone(), args[2].clone());
    } else {
        let mut message = String::new();
        let mut code = String::new();
        
        return (args[0].clone(), caesar::input("message? "), caesar::input("key? "))
    }
}

pub fn clean_key(code: &str) -> String {
    let mut out_text = String::new();
    for c in code.chars()
    {
        if c.is_alphabetic() {
            out_text.push(c)
        }
    }
    out_text
}

pub fn shift_cipher_encode(text: &str, code:  &str) -> String {
    let mut cipher_text = String::new();
    let code_chars = clean_key(code);

    for i in 0..text.len(){
        let c = text.chars().nth(i).unwrap();
        let k = code_chars.chars().nth(i % code_chars.len()).unwrap();
        let o = caesar::char_offset(k);
        cipher_text.push(caesar::shift_cipher_encode_char(c, o));
    }
    cipher_text
}

pub fn shift_cipher_decode(text:  &str, code:  &str) -> String {
    let mut cipher_text = String::new();
    let code_chars = clean_key(code);

    for i in 0..text.len(){
        let c = text.chars().nth(i).unwrap();
        let k = code_chars.chars().nth(i % code_chars.len()).unwrap();
        let o = caesar::char_offset(k);
        cipher_text.push(caesar::shift_cipher_decode_char(c, o));
    }
    cipher_text
}
