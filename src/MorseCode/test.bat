
@ECHO OFF

PUSHD rust
ECHO '-- rust'
cargo test 
POPD

PUSHD csharp
ECHO '-- csharp'
dotnet test
POPD

PUSHD fsharp
ECHO '-- fsharp'
dotnet test
POPD