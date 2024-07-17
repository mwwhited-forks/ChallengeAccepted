
@ECHO OFF

PUSHD rust
ECHO '-- rust'
CALL cargo test 
POPD

PUSHD python
ECHO '-- python'
CALL python -m doctest -v caesar.py
CALL python -m doctest -v vigenere.py
POPD

PUSHD csharp
ECHO '-- csharp'
dotnet test
POPD

PUSHD fsharp
ECHO '-- fsharp'
dotnet test
POPD

PUSHD go
ECHO '-- go'
CALL test
POPD