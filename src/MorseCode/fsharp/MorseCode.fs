namespace MorseCode

open System

module MorseCode =

    let private encodeChar input =
        match input with
        | 'A'  -> ".-"   
        | 'B'  -> "-..." 
        | 'C'  -> "-.-." 
        | 'D'  -> "-.."  
        | 'E'  -> "."    
        | 'F'  -> "..-." 
        | 'G'  -> "--."  
        | 'H'  -> "...." 
        | 'I'  -> ".."   
        | 'J'  -> ".---" 
        | 'K'  -> "-.-"  
        | 'L'  -> ".-.." 
        | 'M'  -> "--"   
        | 'N'  -> "-."   
        | 'O'  -> "---"  
        | 'P'  -> ".--." 
        | 'Q'  -> "--.-" 
        | 'R'  -> ".-."  
        | 'S'  -> "..."  
        | 'T'  -> "-"    
        | 'U'  -> "..-"  
        | 'V'  -> "...-" 
        | 'W'  -> ".--"  
        | 'X'  -> "-..-" 
        | 'Y'  -> "-.--" 
        | 'Z'  -> "--.." 
        | '1'  -> ".----"
        | '2'  -> "..---"
        | '3'  -> "...--"
        | '4'  -> "....-"
        | '5'  -> "....."
        | '6'  -> "-...."
        | '7'  -> "--..."
        | '8'  -> "---.."
        | '9'  -> "----."
        | '0'  -> "-----"
        | '\n' -> "\r\n" 
        | ' '  -> " "    
        | _    -> "" 
        
    let private decodeChar input = 
        match input with 
        | ".-"    -> 'A'
        | "-..."  -> 'B'
        | "-.-."  -> 'C'
        | "-.."   -> 'D'
        | "."     -> 'E'
        | "..-."  -> 'F'
        | "--."   -> 'G'
        | "...."  -> 'H'
        | ".."    -> 'I'
        | ".---"  -> 'J'
        | "-.-"   -> 'K'
        | ".-.."  -> 'L'
        | "--"    -> 'M'
        | "-."    -> 'N'
        | "---"   -> 'O'
        | ".--."  -> 'P'
        | "--.-"  -> 'Q'
        | ".-."   -> 'R'
        | "..."   -> 'S'
        | "-"     -> 'T'
        | "..-"   -> 'U'
        | "...-"  -> 'V'
        | ".--"   -> 'W'
        | "-..-"  -> 'X'
        | "-.--"  -> 'Y'
        | "--.."  -> 'Z'
        | ".----" -> '1'
        | "..---" -> '2'
        | "...--" -> '3'
        | "....-" -> '4'
        | "....." -> '5'
        | "-...." -> '6'
        | "--..." -> '7'
        | "---.." -> '8'
        | "----." -> '9'
        | "-----" -> '0'
        | "\r\n"  -> '\n'
        | " "     -> ' '
        | _       -> ' '

    let encode (message: string) =
        match message with
        | null -> ""
        | _ ->
            String.Join(" ", 
                message.ToUpper() 
                |> Seq.map (fun c -> encodeChar c)
                |> Seq.filter (fun c -> c <> "")
                ).Replace("  ", " ")

    let decode (message: string) =
        match message with
        | null -> ""
        | _ ->
            new string(
                message.ToUpper().Split(" ")
                |> Seq.map (fun c -> decodeChar c)
                |> Seq.filter (fun c -> c <> char 0)
                |> Seq.toArray
            )