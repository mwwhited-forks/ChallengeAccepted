namespace Cipher

open Caesar

//Note, this file must be after "Caesar.fs" to compile correctly
module Vigenere = 

    let cleanKey code: string =
        new string(
            code 
            |> Seq.map (fun c -> 
                match c with 
                | x when x >= 'A' && x <= 'Z' -> x
                | x when x >= 'a' && x <= 'z' -> x
                | _ -> char(0)
                )
            |> Seq.filter (fun c -> int c <> 0)
            |> Seq.toArray
        )

    let encode (message: string) (code: string) = 
        let cleaned = cleanKey code
        new string(
            Seq.mapi (fun idx c -> encodeChar c cleaned.[idx % cleaned.Length]) message
            |> Seq.toArray
        )

    let decode (message: string) (code: string) = 
        let cleaned = cleanKey code
        new string(
            Seq.mapi (fun idx c -> decodeChar c cleaned.[idx % cleaned.Length]) message
            |> Seq.toArray
        )
            
                
    