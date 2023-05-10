@ECHO OFF

REM pushd rust
REM ECHO '-- morsecode.rs'
REM rustc morsecode.rs -o morsecode-rust.exe && morsecode-rust.exe "Hello, World"
REM popd
REM 
REM pushd python
REM ECHO '-- morsecode.py'
REM python caesar.py "Hello, World"
REM popd


pushd csharp
ECHO '-- morsecode.cs'
dotnet run "Hello World"
popd