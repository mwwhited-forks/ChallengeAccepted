@ECHO OFF

ECHO '-- caesar.rs'
rustc caesar.rs -o caesar-rust.exe && caesar-rust.exe "Hello, World" H
ECHO '-- vigenere.rs'
rustc vigenere.rs -o vigenere-rust.exe && vigenere-rust.exe "Hello, World" "Hello, World"

ECHO '-- caesar.py'
python caesar.py "Hello, World" H
ECHO '-- vigenere.py'
python vigenere.py "Hello, World" "Hello, World"
