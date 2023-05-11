
@ECHO OFF

pushd rust
ECHO '-- rust'
cargo test 
popd

REM pushd python
REM ECHO '-- python'
REM python -m doctest -v caesar.py
REM python -m doctest -v vigenere.py
REM popd

pushd csharp
ECHO '-- csharp'
dotnet test
popd