#!/usr/bin/env python

import sys

class Caesar:
    "https://en.wikipedia.org/wiki/Caesar_cipher"

    @staticmethod
    def encode(input_str, key):
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
        offset = Caesar.get_offset(key)
        ret = ""
        for c in input_str:         
            ret += Caesar.encode_char(c, offset)     
        return ret
    
    @staticmethod
    def decode(input_str, key):
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
        offset = Caesar.get_offset(key)
        ret = ""
        for c in input_str:         
            ret += Caesar.decode_char(c, offset)     
        return ret

    @staticmethod
    def encode_char(input_char, offset):
        if 'A' <= input_char <= 'Z':
            return chr(ord('A') + ((ord(input_char) - ord('A') + offset) % 26))
        elif 'a' <= input_char <= 'z':
            return chr(ord('a') + ((ord(input_char) - ord('a') + offset) % 26))
        else:
            return input_char
        
    @staticmethod
    def decode_char(input_char, offset):
        if 'A' <= input_char <= 'Z':
            return chr(ord('A') + ((ord(input_char) - ord('A') - offset + 26) % 26))
        elif 'a' <= input_char <= 'z':
            return chr(ord('a') + ((ord(input_char) - ord('a') - offset + 26) % 26))
        else:
            return input_char    
    
    @staticmethod
    def get_offset(code):
        if 'A' <= code <= 'Z':
            return ord(code) - ord('A')
        elif 'a' <= code <= 'z':
            return ord(code) - ord('a')
        else:
            raise Exception('Pick a code between A and Z')

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
