@ECHO OFF

PUSHD rust
ECHO '-- caesar.rs'
CALL rustc caesar.rs -o caesar-rust.exe && caesar-rust.exe "Hello, World" H
ECHO '-- vigenere.rs'
CALL rustc vigenere.rs -o vigenere-rust.exe && vigenere-rust.exe "Hello, World" "Hello, World"
POPD

PUSHD python
ECHO '-- caesar.py'
CALL python caesar.py "Hello, World" H
ECHO '-- vigenere.py'
CALL python vigenere.py "Hello, World" "Hello, World"
POPD

PUSHD csharp
ECHO '-- caesar.cs'
dotnet run "Hello World" H 
ECHO '-- vigenere.cs'
dotnet run "Hello, World" "Hello, World"
POPD

PUSHD java
ECHO '-- CaesarCipher.java'
CALL javac *.java && java Program "Hello World" H
ECHO '-- VigenereCipher.java'
CALL javac *.java && java Program "Hello, World" "Hello, World"
POPD

PUSHD fsharp
ECHO '-- caesar.fs'
dotnet run "Hello World" H 
ECHO '-- vigenere.fs'
dotnet run "Hello, World" "Hello, World"
POPD

PUSHD go
ECHO '-- caesar.go'
CALL run
POPD
