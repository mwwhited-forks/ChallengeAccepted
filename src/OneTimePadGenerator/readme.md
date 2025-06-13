# One‑time Pad

## Summary

A one‑time pad (OTP) is an encryption technique that uses a key (pad) that is as long as the message itself, 
composed of truly random values, and used only once. When combined with the plaintext via bitwise XOR (or
modular addition), it provides information‑theoretic security—ciphertext gives no information about the 
original message without the pad.

## Challenge

- Write a function to generate a random pad of a specified length, using a cryptographically secure source of randomness
- Implement encryption:

  - Take a plaintext message (as bytes or characters)
  - XOR (or modular‑add) each plaintext element with the corresponding pad element
  - Output the ciphertext

- Implement decryption by applying the same operation between ciphertext and pad
- Ensure the pad is never reused: pad length must be ≥ message length and pads must be tracked or discarded after use
- Provide a simple interface to:

  - Generate a pad and save it securely
  - Encrypt a message with a chosen pad
  - Decrypt a ciphertext with the matching pad

## Bonus

- Add support for one‑time pad generation and storage in files, ensuring secure deletion after use
- Build a command‑line tool with flags, e.g.:

  - `--gen-pad <length> --out pad.bin`
  - `--encrypt <pad> <message>`
  - `--decrypt <pad> <ciphertext>`
- Visualize pad usage statistics (e.g., how many bytes used) to prevent reuse

## Notes and References

- [One‑Time Pad – Wikipedia](https://en.wikipedia.org/wiki/One-time_pad)
- [How a One Time Pad Works – CIA Instructions](https://www.numbers-stations.com/articles/how-a-one-time-pad-works-cia-instructions/)
- [One Time Pad Encryption Proof (PDF)](https://cryptomuseum.com/manuf/mils/files/mils_otp_proof.pdf)
