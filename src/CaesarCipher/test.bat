
pushd rust
cargo test 
popd

pushd python
python -m doctest -v caesar.py
python -m doctest -v vigenere.py
popd
