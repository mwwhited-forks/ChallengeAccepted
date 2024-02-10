#!/bin/bash

pushd rust > /dev/null
echo '-- hello_world.rs (Rust)'
cargo run --quiet hello_world.rs
popd > /dev/null

pushd python > /dev/null
echo '-- hello_world.py (Python)'
python hello_world.py
popd > /dev/null

pushd csharp > /dev/null
echo '-- hello_world.cs (C#)'
dotnet run
popd > /dev/null

pushd fsharp > /dev/null
echo '-- hello_world.fs (F#)'
dotnet run
popd > /dev/null

pushd java > /dev/null
echo '-- hello_world.java (Java)'
java HelloWorld.java
popd > /dev/null

pushd go > /dev/null
echo '-- hello_world.go (Go)'
go run hello_world.go
popd > /dev/null

pushd php > /dev/null
echo '-- hello_world.php (PHP)'
php hello_world.php
popd > /dev/null

pushd typescript > /dev/null
echo '-- hello_world.ts (TypeScript)'
npm install typescript --save-dev && npx tsc *.ts --outDir ./compiled/ && node ./compiled/hello_world.js
popd > /dev/null

pushd javascript > /dev/null
echo '-- hello_world.js (JavaScript)'
node hello_world.js
popd > /dev/null

pushd ruby > /dev/null
echo '-- hello_world.rb (Ruby)'
ruby hello_world.rb
popd > /dev/null

pushd haskell > /dev/null
echo '-- hello_world.hs (Haskell)'
runhaskell helloworld.hs
popd > /dev/null

pushd cobol > /dev/null
echo '-- hello_world.cbl (Cobol)'
cobc -x hello_world.cbl -j
rm hello_world
popd > /dev/null
