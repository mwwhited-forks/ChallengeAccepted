#!/bin/bash

pushd rust
echo '-- hello_world.rs'
cargo run --quiet hello_world.rs
popd

pushd python
echo '-- hello_world.py'
python hello_world.py
popd

pushd csharp
echo '-- hello_world.cs'
dotnet run
popd

pushd fsharp
echo '-- hello_world.fs'
dotnet run
popd

pushd java
echo '-- hello_world.java'
# javac HelloWorld.java && java HelloWorld
java HelloWorld.java
popd

pushd go
echo '-- hello_world.go'
go run hello_world.go
popd

pushd php
echo '-- hello_world.php'
php hello_world.php
popd

pushd typescript
echo '-- hello_world.ts'
node hello_world.ts
popd

pushd ruby
echo '-- hello_world.rb'
ruby hello_world.rb
popd

# Haskell part commented out as in original script
# pushd haskell
# echo '-- hello_world.hs'
# ghc helloworld.hs && ./helloworld
# popd
