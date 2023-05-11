#![allow(unused)]

use std::env;
use std::io::{self, Write};

fn main() {
    let (cmd, text) = inputs();
    let encoded = morse_code_encode(&text);
    let decoded = morse_code_decode(&encoded);

    println!("Command: {}", cmd);
    println!("Text: {}", text);
    println!("Encode: {}", encoded);
    println!("Decode: {}", decoded);
}

fn inputs() -> (String, String) {
    let args: Vec<String> = env::args().collect();
    if args.len() >= 2 {
        (
            args[0].clone(),
            args[1].clone()
        )
    } else {
        (
            args[0].clone(),
            input("message? ")
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

pub fn morse_code_encode(input: &str) -> String {
    input.to_uppercase()
         .chars()
         .map(|c| map_to_string(c))
         .filter(|c| c != "")
         .collect::<Vec<String>>()
         .join(" ")
         .replace("  ", " ")
}

pub fn map_to_string(input: char) -> String {
    return String::from(match input {
        'A'  => ".-"   ,
        'B'  => "-..." ,
        'C'  => "-.-." ,
        'D'  => "-.."  ,
        'E'  => "."    ,
        'F'  => "..-." ,
        'G'  => "--."  ,
        'H'  => "...." ,
        'I'  => ".."   ,
        'J'  => ".---" ,
        'K'  => "-.-"  ,
        'L'  => ".-.." ,
        'M'  => "--"   ,
        'N'  => "-."   ,
        'O'  => "---"  ,
        'P'  => ".--." ,
        'Q'  => "--.-" ,
        'R'  => ".-."  ,
        'S'  => "..."  ,
        'T'  => "-"    ,
        'U'  => "..-"  ,
        'V'  => "...-" ,
        'W'  => ".--"  ,
        'X'  => "-..-" ,
        'Y'  => "-.--" ,
        'Z'  => "--.." ,
        '1'  => ".----",
        '2'  => "..---",
        '3'  => "...--",
        '4'  => "....-",
        '5'  => ".....",
        '6'  => "-....",
        '7'  => "--...",
        '8'  => "---..",
        '9'  => "----.",
        '0'  => "-----",
        '\n' => "\r\n" ,
        ' '  => " "    ,
        _    => ""     ,
    });
}

pub fn morse_code_decode(input: &str) -> String {
    return input
        .split(" ")
        .map(|c| map_to_char(c))         
        .collect::<Vec<char>>()
        .iter()
        .collect();
}

pub fn map_to_char(input: &str) -> char {
    return match input {
        ".-"    => 'A'  ,
        "-..."  => 'B'  ,
        "-.-."  => 'C'  ,
        "-.."   => 'D'  ,
        "."     => 'E'  ,
        "..-."  => 'F'  ,
        "--."   => 'G'  ,
        "...."  => 'H'  ,
        ".."    => 'I'  ,
        ".---"  => 'J'  ,
        "-.-"   => 'K'  ,
        ".-.."  => 'L'  ,
        "--"    => 'M'  ,
        "-."    => 'N'  ,
        "---"   => 'O'  ,
        ".--."  => 'P'  ,
        "--.-"  => 'Q'  ,
        ".-."   => 'R'  ,
        "..."   => 'S'  ,
        "-"     => 'T'  ,
        "..-"   => 'U'  ,
        "...-"  => 'V'  ,
        ".--"   => 'W'  ,
        "-..-"  => 'X'  ,
        "-.--"  => 'Y'  ,
        "--.."  => 'Z'  ,
        ".----" => '1'  ,
        "..---" => '2'  ,
        "...--" => '3'  ,
        "....-" => '4'  ,
        "....." => '5'  ,
        "-...." => '6'  ,
        "--..." => '7'  ,
        "---.." => '8'  ,
        "----." => '9'  ,
        "-----" => '0'  ,
        "\r\n"  => '\n' ,
        " "     => ' '  ,
        _       => ' '  ,
    };
}


#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_morse_code_encode() {
        assert_eq!(morse_code_encode("Hello, World!"), ".... . .-.. .-.. ---  .-- --- .-. .-.. -..");
        assert_eq!(morse_code_encode("hello world"), ".... . .-.. .-.. ---  .-- --- .-. .-.. -..");
        assert_eq!(morse_code_encode("abcdefghijklmnopqrstuvwxyz1234567890"), ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----");
    }
    
    #[test]
    fn test_morse_code_decode() {
        assert_eq!(morse_code_decode(".... . .-.. .-.. ---  .-- --- .-. .-.. -.."), "HELLO WORLD");
        assert_eq!(morse_code_decode(".... . .-.. .-.. ---  .-- --- .-. .-.. -.."), "HELLO WORLD");
        assert_eq!(morse_code_decode(".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----"), "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890");
    }

    // morse_code_decode

}

