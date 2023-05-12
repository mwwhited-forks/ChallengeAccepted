@ECHO OFF

PUSHD rust
ECHO '-- morse_code.rs'
rustc morse_code.rs -o morse_code-rust.exe && morse_code-rust.exe "Hello, World"
POPD

PUSHD csharp
ECHO '-- morsecode.cs'
dotnet run "Hello World"
POPD

PUSHD java
ECHO '-- MorseCode.java'
javac *.java && java Program "Hello World"
POPD

PUSHD fsharp
ECHO '-- morsecode.fs'
dotnet run "Hello World"
POPD