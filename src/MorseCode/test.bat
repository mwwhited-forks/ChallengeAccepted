
@ECHO OFF

REM pushd rust
REM ECHO '-- rust'
REM cargo test 
REM popd
REM 
REM pushd python
REM ECHO '-- python'
REM python -m doctest -v caesar.py
REM python -m doctest -v vigenere.py
REM popd

pushd csharp
ECHO '-- csharp'
dotnet test
popd