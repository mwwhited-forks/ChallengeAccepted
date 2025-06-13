# Mini Compiler / Interpreter

## Summary

Build a miniature compiler or interpreter for a simple programming language. You’ll implement the core 
stages—tokenization, parsing, and execution—to turn text source code into running behavior.

## Challenge

- **Lexer**: Read source text and split into tokens (identifiers, literals, operators, punctuation)
- **Parser**: Consume tokens and build an Abstract Syntax Tree (AST) using either:

  - Recursive descent
  - Pratt parsing

- **Evaluator/Compiler**:

  - **Interpreter**: Walk the AST to execute statements and expressions
  - **Compiler**: Generate bytecode or a stack‑machine representation and execute it on a virtual machine

- **Language Features**:

  - Integer and string literals
  - Arithmetic expressions (`+`, `-`, `*`, `/`) with correct precedence
  - Variable declarations and assignments
  - Control flow: `if` statements, `while` or `for` loops
  - Function definitions and calls (optional: first‑class or closures)

## Bonus

- Add a **REPL** (Read‑Eval‑Print Loop) that reads lines of code interactively
- Implement **error reporting** with line numbers and helpful messages
- Include **optimizations** such as constant folding or dead‑code elimination
- Support **scopes** and **closures** for nested functions
- Generate and output **bytecode** or **AST dumps** for debugging

## Notes and References

- [Compiler – Wikipedia](https://en.wikipedia.org/wiki/Compiler)
- [Interpreter – Wikipedia](https://en.wikipedia.org/wiki/Interpreter_%28computing%29)
- [Recursive Descent Parser](https://en.wikipedia.org/wiki/Recursive_descent_parser)
- [Pratt Parser](https://en.wikipedia.org/wiki/Pratt_parser)
- [Abstract Syntax Tree](https://en.wikipedia.org/wiki/Abstract_syntax_tree)
