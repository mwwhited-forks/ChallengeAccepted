@ECHO OFF

pushd rust
ECHO '-- morse_code.rs'
rustc morse_code.rs -o morse_code-rust.exe && morse_code-rust.exe "Hello, World"
popd

REM pushd python
REM ECHO '-- morsecode.py'
REM python caesar.py "Hello, World"
REM popd


pushd csharp
ECHO '-- morsecode.cs'
dotnet run "Hello World"
popd