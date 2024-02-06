@ECHO OFF

PUSHD rust
ECHO '-- hello_world.rs'
CALL cargo run --quiet hello_world.rs
POPD

PUSHD python
ECHO '-- hello_world.py'
CALL python hello_world.py
POPD

PUSHD csharp
ECHO '-- hello_world.cs'
CALL dotnet run
POPD

PUSHD fsharp
ECHO '-- hello_world.fs'
CALL dotnet run
POPD

PUSHD java
ECHO '-- hello_world.java'
REM javac HelloWorld.java && java HelloWorld
CALL java HelloWorld.java
POPD

PUSHD go
ECHO '-- hello_world.go'
CALL go run hello_world.go
POPD

PUSHD php
ECHO '-- hello_world.php'
CALL php hello_world.php
POPD

PUSHD typescript
ECHO '-- hello_world.ts'
CALL node hello_world.ts
POPD

@REM PUSHD haskell
@REM ECHO '-- hello_world.hs'
@REM CALL ghc helloworld.hs && helloworld.exe
@REM POPD
