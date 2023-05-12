namespace MorseCode

open System

module Program = 
    let inputs(args: string[]) =
        if args.Length >= 1 then
            args.[0]
        else
            printf "message? "
            let message = Console.ReadLine().TrimEnd()
            message

    let getCipher (message: string) = 
        let encoded = MorseCode.encode message
        let decoded = MorseCode.decode encoded
        "MorseCode", encoded, decoded
            
    let [<EntryPoint>] main args = 
        let message = inputs args
        let cipher, encoded, decoded = getCipher message
        printfn "Command: \"FSharp\"(%O)" cipher
        printfn "Text: %s" message
        printfn "Encoded: %s" encoded
        printfn "Decoded: %s" decoded
        0

