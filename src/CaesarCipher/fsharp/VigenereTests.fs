namespace Cipher

open Cipher
open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type VigenereTests () =

    [<DataTestMethod>]    
    [<DataRow("Hello World", "HelloWorld")>]
    [<DataRow("Hello, World","HelloWorld")>]
    [<DataRow("hello, world","helloworld")>]
    [<DataRow("hello world", "helloworld")>]
    member this.cleanKeyTest (input: string, expected: string) =
        let result = Vigenere.cleanKey input
        Assert.AreEqual( expected, result)

    [<DataTestMethod>]    
    [<DataRow("Hello World", "World", "Dscwr Kfcoz")>]
    [<DataRow("Hello, World", "world", "Dscwr, Nzuhr")>]
    [<DataRow("hello, world", "World", "dscwr, nzuhr")>]
    [<DataRow("hello world", "Hello", "oiwwc azczk")>]
    member this.encodeTest (message: string, key: string, expected: string ) =
        let result = Vigenere.encode message key
        Assert.AreEqual( expected, result)
        
    [<DataTestMethod>]    
    [<DataRow("Dscwr Kfcoz", "World", "Hello World")>]
    [<DataRow("Dscwr, Nzuhr", "World", "Hello, World")>]
    [<DataRow("dscwr, nzuhr", "World", "hello, world")>]
    [<DataRow("oiwwc azczk", "Hello", "hello world")>]
    member this.decodeTest (message: string, key: string, expected: string ) =
        let result = Vigenere.decode message key
        Assert.AreEqual( expected, result)
