
@ECHO OFF

PUSHD rust
ECHO '-- rust'
cargo test 
POPD

PUSHD python
ECHO '-- python'
python -m doctest -v caesar.py
python -m doctest -v vigenere.py
POPD

PUSHD csharp
ECHO '-- csharp'
dotnet test
POPD

PUSHD csharp
ECHO '-- csharp'
dotnet test
POPD