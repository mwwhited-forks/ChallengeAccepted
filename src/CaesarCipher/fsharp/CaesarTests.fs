namespace Cipher

open Cipher
open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CaesarTests () =

    [<DataTestMethod>]    
    [<DataRow("Hello World", 'H', "Olssv Dvysk")>]
    [<DataRow("Hello, World", 'H', "Olssv, Dvysk")>]
    [<DataRow("hello, world", 'h', "olssv, dvysk")>]
    [<DataRow("hello world", 'C', "jgnnq yqtnf")>]
    member this.EncodeTest (message: string, key: char, expected: string ) =
        let result = Caesar.encodeString message key
        Assert.AreEqual( expected, result)
        
    [<DataTestMethod>]    
    [<DataRow("Olssv Dvysk", 'H', "Hello World")>]
    [<DataRow("Olssv, Dvysk", 'H', "Hello, World")>]
    [<DataRow("olssv, dvysk", 'h', "hello, world")>]
    [<DataRow("jgnnq yqtnf", 'C', "hello world")>]
    member this.DecodeTest (message: string, key: char, expected: string ) =
        let result = Caesar.decodeString message key
        Assert.AreEqual( expected, result)
