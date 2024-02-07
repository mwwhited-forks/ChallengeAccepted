@ECHO OFF

pushd rust
echo '-- hello_world.rs (Rust)'
CALL cargo run --quiet hello_world.rs
popd

pushd python
echo '-- hello_world.py (Python)'
CALL python hello_world.py
popd

pushd csharp
echo '-- hello_world.cs (C#)'
CALL dotnet run
popd

pushd fsharp
echo '-- hello_world.fs (F#)'
CALL dotnet run
popd

pushd java
echo '-- hello_world.java (Java)'
CALL java HelloWorld.java
popd

pushd go
echo '-- hello_world.go (Go)'
CALL go run hello_world.go
popd

pushd php
echo '-- hello_world.php (PHP)'
CALL php hello_world.php
popd

@REM pushd typescript
@REM echo '-- hello_world.ts (TypeScript)'
@REM CALL npm install ts-node typescript '@types/node' >NUL 2>&1
@REM CALL ts-node hello_world.ts
@REM popd

pushd javascript
echo '-- hello_world.js (JavaScript)'
CALL node hello_world.js
popd

pushd ruby
echo '-- hello_world.rb (Ruby)'
CALL ruby hello_world.rb
popd

pushd haskell
echo '-- hello_world.hs (Haskell)'
CALL runhaskell helloworld.hs
popd
