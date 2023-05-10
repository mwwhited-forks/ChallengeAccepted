#!/usr/bin/env python

import sys

class Caesar:
    "https://en.wikipedia.org/wiki/Caesar_cipher"

    def encode(input, key):
        """ 
        >>> Caesar.encode('Hello World', 'H')
        'Olssv Dvysk'
        >>> Caesar.encode('hello world', 'H')
        'olssv dvysk'
        >>> Caesar.encode('Hello, World!', 'H')
        'Olssv, Dvysk!'
        >>> Caesar.encode('hello world', 'C')
        'jgnnq yqtnf'
        """
        offset = Caesar.getOffset(key)
        ret = ""
        for c in input:         
            ret += Caesar.encodeChar(c, offset)     
        return ret
    
    def decode(input, key):
        """ 
        >>> Caesar.decode('Olssv Dvysk', 'H')
        'Hello World'
        >>> Caesar.decode('olssv dvysk', 'H')
        'hello world'
        >>> Caesar.decode('Olssv, Dvysk!', 'H')
        'Hello, World!'
        >>> Caesar.decode('jgnnq yqtnf', 'C')
        'hello world'
        """
        offset = Caesar.getOffset(key)
        ret = ""
        for c in input:         
            ret += Caesar.decodeChar(c, offset)     
        return ret

    def encodeChar(input, offset):
        if input >= 'A' and input <= 'Z':
            return chr(ord('A') + ((ord(input) - ord('A') + offset) % 26))
        elif input >= 'a' and input <= 'z':
            return chr(ord('a') + ((ord(input) - ord('a') + offset) % 26))
        else:
            return input
        
    def decodeChar(input, offset):
        if input >= 'A' and input <= 'Z':
            return chr(ord('A') + ((ord(input) - ord('A') - offset + 26) % 26))
        elif input >= 'a' and input <= 'z':
            return chr(ord('a') + ((ord(input) - ord('a') - offset + 26) % 26))
        else:
            return input    
    
    def getOffset(code):
        if code >= 'A' and code <= 'Z':
            return ord(code) - ord('A')
        elif code >= 'a' and code <= 'z':
            return ord(code) - ord('a')
        else:
            raise Exception('pick a code between A and Z')

if __name__ == '__main__':
    def inputs():
        if len(sys.argv) >= 3:
            return (sys.argv[1], sys.argv[2])
        else:
            return (input('message? '), input('key? '))

    (message, code) = inputs()

    encoded = Caesar.encode(message, code)
    print(f"Command: {sys.argv[0]}")
    print(f"Text: {message}")
    print(f"Key: {code}")
    print(f"Encoded: {encoded}")
    decoded = Caesar.decode(encoded, code)
    print(f"Decoded: {decoded}")
