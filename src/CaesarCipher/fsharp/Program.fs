namespace Cipher

open System

module Program = 
    let inputs(args: string[]) =
        if args.Length >= 2 then
            (args.[0], args.[1])
        else
            printf "message? "
            let message = Console.ReadLine().TrimEnd()
            printf "key? "
            let key = Console.ReadLine().TrimEnd()
            (message, key)

    let getCipher (message: string) (key: string) = 
        match key.Length with 
        | 0 -> "None", "", ""
        | 1 -> 
            let encoded = Caesar.encodeString message key.[0]
            let decoded = Caesar.decodeString encoded key.[0]
            "Caesar", encoded, decoded
        | n -> 
            let encoded = Vigenere.encode message key
            let decoded = Vigenere.decode encoded key
            "Vigenere", encoded, decoded
            
    let [<EntryPoint>] main args = 
        let message, key = inputs args
        let cipher, encoded, decoded = getCipher message key
        printfn "Command: \"FSharp\"(%O)" cipher
        printfn "Text: %s" message
        printfn "Key: %s" key
        printfn "Encoded: %s" encoded
        printfn "Decoded: %s" decoded
        0

