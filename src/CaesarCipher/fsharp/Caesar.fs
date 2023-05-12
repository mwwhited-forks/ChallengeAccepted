namespace Cipher

module Caesar = 
    let getOffset (input: char) : int = 
        match input with
        | x when x >= 'A' && x <= 'Z' -> int (input - 'A')
        | x when x >= 'a' && x <= 'z' -> int (input - 'a')
        | _ -> failwith("\"input\" must be between A and Z")

    let encodeOffset (input: char) (offset: int) : char =
        match (input) with
        | c when c >= 'A' && c <= 'Z' -> char(int 'A' + ((int c - int 'A' + offset) % 26))
        | c when c >= 'a' && c <= 'z' -> char(int 'a' + ((int c - int 'a' + offset) % 26))
        | _ -> input

    let encodeChar (input: char) (code: char) : char = 
        encodeOffset input (getOffset code)

    let encodeString (input: string) (code: char) : string =
        match input with 
        | null -> ""
        | _ -> 
            let charArray = input.ToCharArray()
            new string(Array.map (fun c -> encodeOffset c (getOffset code)) charArray)

    let decodeOffset (input: char) (offset: int) : char =
        match (input) with
        | c when c >= 'A' && c <= 'Z' -> char(int 'A' + ((int c + 26 - int 'A' - offset) % 26))
        | c when c >= 'a' && c <= 'z' -> char(int 'a' + ((int c + 26 - int 'a' - offset) % 26))
        | _ -> input

    let decodeChar (input: char) (code: char) : char = 
        decodeOffset input (getOffset code)

    let decodeString (input: string) (code: char) : string =
        match input with 
        | null -> ""
        | _ -> 
            let charArray = input.ToCharArray()
            new string(Array.map (fun c -> decodeOffset c (getOffset code)) charArray)
