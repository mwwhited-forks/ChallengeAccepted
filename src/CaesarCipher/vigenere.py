#!/usr/bin/env python
from caesar import Caesar
import sys

class Vigenere:
    "https://en.wikipedia.org/wiki/Vigen%C3%A8re_cipher"

    def encode(input, key):
        """ 
        >>> Vigenere.encode('Hello World', 'Hello World')
        'Oiwwc Kfcok'
        >>> Vigenere.encode('hello world', 'Hello World')
        'oiwwc kfcok'
        >>> Vigenere.encode('Hello, World!', 'Hello World')
        'Oiwwc, Nzush!'
        >>> Vigenere.encode('hello world', 'World')
        'dscwr kfcoz'
        """
        ret = ""
        key = Vigenere.cleanKey(key)
        for idx in range(len(input)):
            c = input[idx]
            code = key[idx % len(key)]
            offset = Caesar.getOffset(code)
            enc = Caesar.encodeChar(c, offset)  
            ret += enc
        return ret
    
    def decode(input, key):
        """ 
        >>> Vigenere.decode('Oiwwc Kfcok', 'Hello World')
        'Hello World'
        >>> Vigenere.decode('oiwwc kfcok', 'Hello World')
        'hello world'
        >>> Vigenere.decode('Oiwwc, Nzush!', 'Hello World')
        'Hello, World!'
        >>> Vigenere.decode('dscwr kfcoz', 'World')
        'hello world'
        """

        ret = ""
        key = Vigenere.cleanKey(key)
        for idx in range(len(input)):
            c = input[idx]
            code = key[idx % len(key)]
            offset = Caesar.getOffset(code)
            enc = Caesar.decodeChar(c, offset)  
            ret += enc
        return ret

    def cleanKey(key):
        ret = ""
        for c in key:
            if c >= 'A' and c <= 'Z':
                ret += c   
            if c >= 'a' and c <= 'z':
                ret += c   
        return ret

if __name__ == '__main__':   
    def inputs():
        if len(sys.argv) >= 3:
            return (sys.argv[1], sys.argv[2])
        else:
            return (input('message? '), input('key? '))

    (message, code) = inputs()

    encoded = Vigenere.encode(message, code)
    print(f"Command: {sys.argv[0]}")
    print(f"Text: {message}")
    print(f"Key: {code}")
    print(f"Encoded: {encoded}")
    decoded = Vigenere.decode(encoded, code)
    print(f"Decoded: {decoded}")

# Hello World
# Hello World
# Oiwwc Kfcok