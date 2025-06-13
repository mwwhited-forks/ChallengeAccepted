# Roman Numerals

## Summary

Roman numerals are an ancient numeral system used throughout the Roman Empire and still seen today for 
aesthetic and traditional purposes (e.g., clock faces, chapter headings). They represent numbers using 
combinations of letters from the Latin alphabet.

## Challenge

- Write a function that takes a positive integer and returns its Roman numeral representation as a string
- Follow standard rules for subtractive notation (e.g., `IV` for 4, `IX` for 9)
- Support values up to 3,999 using the basic symbols

## Bonus

- Write a function that parses a valid Roman numeral string and returns its integer value
- Validate input and handle invalid or malformed Roman numerals gracefully

## Double Secret Bonus

- Extend both conversion functions to support the **vinculum** (overbar) notation, where placing an overbar 
  above a symbol multiplies its value by 1,000 (e.g., an overbar `V` = 5,000)
- Design a text‑based convention for input and output (for example, prefixing with `_` to denote the overbar)

## Notes and References

- [Roman numerals – Wikipedia](https://en.wikipedia.org/wiki/Roman_numerals)

### Value Map

| Character | Arabic Value |
| --------- | ------------ |
| I         | 1            |
| V         | 5            |
| X         | 10           |
| L         | 50           |
| C         | 100          |
| D         | 500          |
| M         | 1000         |

### Usage Notes

- Place smaller values before larger ones to subtract (e.g., `IV` = 4, `XL` = 40).
- Otherwise, place values in descending order and sum (e.g., `XII` = 12, `LXX` = 70).
- Do not repeat the same symbol more than three times in a row.
