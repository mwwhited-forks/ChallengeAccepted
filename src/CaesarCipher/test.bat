
pushd rust
ECHO '-- rust'
cargo test 
popd

pushd python
ECHO '-- python'
python -m doctest -v caesar.py
python -m doctest -v vigenere.py
popd

pushd csharp
ECHO '-- csharp'
dotnet test
popd