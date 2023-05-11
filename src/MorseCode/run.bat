@ECHO OFF

PUSHD rust
ECHO '-- morse_code.rs'
rustc morse_code.rs -o morse_code-rust.exe && morse_code-rust.exe "Hello, World"
POPD

REM PUSHD python
REM ECHO '-- morsecode.py'
REM python caesar.py "Hello, World"
REM POPD

PUSHD csharp
ECHO '-- morsecode.cs'
dotnet run "Hello World"
POPD

PUSHD java
ECHO '-- MorseCode.java'
javac *.java && java Program "Hello World"
POPD