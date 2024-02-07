#!/bin/bash

pushd rust
echo '-- hello_world.rs (Rust)'
cargo run --quiet hello_world.rs
popd

pushd python
echo '-- hello_world.py (Python)'
python hello_world.py
popd

pushd csharp
echo '-- hello_world.cs (C#)'
dotnet run
popd

pushd fsharp
echo '-- hello_world.fs (F#)'
dotnet run
popd

pushd java
echo '-- hello_world.java (Java)'
java HelloWorld.java
popd

pushd go
echo '-- hello_world.go (Go)'
go run hello_world.go
popd

pushd php
echo '-- hello_world.php (PHP)'
php hello_world.php
popd

# pushd typescript
# echo '-- hello_world.ts (TypeScript)'
# CALL npm install --global ts-node typescript '@types/node'
# CALL ts-node hello_world.ts
# popd

pushd javascript
echo '-- hello_world.js (JavaScript)'
CALL node hello_world.js
popd

pushd ruby
echo '-- hello_world.rb (Ruby)'
ruby hello_world.rb
popd

pushd haskell
echo '-- hello_world.hs (Haskell)'
runhaskell helloworld.hs
popd
