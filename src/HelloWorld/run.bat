@ECHO OFF

PUSHD rust
ECHO '-- hello_world.rs'
rustc hello_world.rs -o hello_world.exe && hello_world.exe
POPD

PUSHD python
ECHO '-- hello_world.py'
python hello_world.py
POPD

PUSHD csharp
ECHO '-- hello_world.cs'
dotnet run
POPD

PUSHD java
ECHO '-- hello_world.java'
REM javac HelloWorld.java && java HelloWorld
java HelloWorld.java
POPD

PUSHD go
ECHO '-- hello_world.go'
go run hello_world.go
POPD
