# Expression Parser

## Summary

Create a parser and evaluator for mathematical and logical expressions. Your program should read a string containing an expression, parse it according to operator precedence and associativity, and return the correct result.

## Challenge

- Support the following operators with correct precedence and associativity:

  - Addition `+`
  - Subtraction `-`
  - Multiplication `*`
  - Division `/`
  - Factorial `!` (postfix)
  - Logical And `&`
  - Logical Or `|`
  - Logical Not `~` (prefix)
  - Logical X‑Or `^`

- Handle parentheses for grouping, e.g. `(2 + 3) * 4`
- Implement parsing (e.g. using the shunting‑yard algorithm or recursive descent)
- Evaluate both integer and boolean contexts (e.g. `5 & 3`, `~0 | 1`)
- Detect and report syntax errors (e.g. unmatched parentheses, invalid tokens)

## Bonus

- Add support for unary minus (e.g. `-5 + 2`)
- Allow variables and simple assignments (e.g. `x = 3 * (2 + 1); x + 4`)
- Extend with additional functions like exponentiation `^` (power) or built‑in math functions (`sin`, `log`)
- Build a REPL interface that reads expressions until the user quits

## Notes and References

- [Shunting‑Yard Algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm)
- [Recursive Descent Parser](https://en.wikipedia.org/wiki/Recursive_descent_parser)
- [Operator precedence](https://en.wikipedia.org/wiki/Order_of_operations)
