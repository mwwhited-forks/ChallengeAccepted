namespace MorseCode

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type MorseCodeTests () =

    [<DataTestMethod>]
    [<DataRow("Hello, World!", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")>]
    [<DataRow("hello world", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")>]
    [<DataRow("abcdefghijklmnopqrstuvwxyz1234567890", ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----")>]
    member this.encodeTest(input: string, expected: string) =
        let result = MorseCode.encode input
        Assert.AreEqual( expected, result)

    [<DataTestMethod>]
    [<DataRow(".... . .-.. .-.. ---  .-- --- .-. .-.. -..", "HELLO WORLD")>]
    [<DataRow( ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----", "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890")>]
    member this.decodeTest(input: string, expected: string) =
        let result = MorseCode.decode input
        Assert.AreEqual( expected, result)