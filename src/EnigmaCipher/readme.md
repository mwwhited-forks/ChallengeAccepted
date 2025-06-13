# Enigma Cipher

## Summary

Create a simulator for the Enigma Machine, a historical rotor‑based block cipher device used to encrypt and decrypt messages during World War II.

## Challenge

- Model the core components of the Enigma Machine:

  - **Rotors** with configurable wiring and ring settings
  - **Reflector** wiring
  - **Plugboard** pairings
  - **Stepping mechanism** that advances rotors with each key press

- Write functions to:

  - Encrypt a single character
  - Encrypt and decrypt an entire message using the same machine settings

- Allow users to specify:

  - Rotor types and their initial positions
  - Ring (ringstellung) settings for each rotor
  - Reflector type (e.g., A, B, C)
  - Plugboard wiring pairs

## Bonus

- Build a simple UI to visualize rotor positions and stepping as you type
- Support historical variants (e.g., four‑rotor M4, Abwehr Enigma)
- Implement automated key‐setting generation from daily key sheets

## Notes and References

- [Enigma machine – Wikipedia](https://en.wikipedia.org/wiki/Enigma_machine)
