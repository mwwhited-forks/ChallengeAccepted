#!/usr/bin/env python
from caesar import Caesar
import sys


class Vigenere:
    """Implements Vigenere Cipher.

    https://en.wikipedia.org/wiki/Vigen%C3%A8re_cipher
    """

    @staticmethod
    def encode(message: str, key: str) -> str:
        """Encodes message using Vigenere Cipher with given key.

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
        key = Vigenere.clean_key(key)
        for idx in range(len(message)):
            c = message[idx]
            code = key[idx % len(key)]
            offset = Caesar.get_offset(code)
            enc = Caesar.encode_char(c, offset)
            ret += enc
        return ret

    @staticmethod
    def decode(message: str, key: str) -> str:
        """Decodes message using Vigenere Cipher with given key.

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
        key = Vigenere.clean_key(key)
        for idx in range(len(message)):
            c = message[idx]
            code = key[idx % len(key)]
            offset = Caesar.get_offset(code)
            enc = Caesar.decode_char(c, offset)
            ret += enc
        return ret

    @staticmethod
    def clean_key(key: str) -> str:
        """Removes all non-alphabetic characters from key.

        >>> Vigenere.clean_key('Hello World')
        'HelloWorld'
        >>> Vigenere.clean_key('Hello, World!')
        'HelloWorld'
        """
        return "".join(c for c in key if c.isalpha())


if __name__ == '__main__':
    def inputs():
        if len(sys.argv) >= 3:
            return (sys.argv[1], sys.argv[2])
        else:
            return (input('message? '), input('key? '))

    message, key = inputs()

    encoded = Vigenere.encode(message, key)
    print(f"Command: {sys.argv[0]}")
    print(f"Text: {message}")
    print(f"Key: {key}")
    print(f"Encoded: {encoded}")
    decoded = Vigenere.decode(encoded, key)
    print(f"Decoded: {decoded}")
