@ECHO OFF

PUSHD rust
ECHO '-- caesar.rs'
rustc caesar.rs -o caesar-rust.exe && caesar-rust.exe "Hello, World" H
ECHO '-- vigenere.rs'
rustc vigenere.rs -o vigenere-rust.exe && vigenere-rust.exe "Hello, World" "Hello, World"
POPD

PUSHD python
ECHO '-- caesar.py'
python caesar.py "Hello, World" H
ECHO '-- vigenere.py'
python vigenere.py "Hello, World" "Hello, World"
POPD

PUSHD csharp
ECHO '-- caesar.cs'
dotnet run "Hello World" H 
ECHO '-- vigenere.cs'
dotnet run "Hello, World" "Hello, World"
POPD

PUSHD java
ECHO '-- CaesarCipher.java'
javac *.java && java Program "Hello World" H
ECHO '-- VigenereCipher.java'
javac *.java && java Program "Hello, World" "Hello, World"
POPD

PUSHD fsharp
ECHO '-- caesar.fs'
dotnet run "Hello World" H 
ECHO '-- vigenere.fs'
dotnet run "Hello, World" "Hello, World"
POPD
