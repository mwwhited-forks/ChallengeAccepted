# Pseudorandom Number Generators

## Summary

Pseudorandom Number Generators (PRNGs) are algorithms that produce sequences of numbers that approximate the
properties of random numbers. Although the sequences are not truly random (since they are generated 
deterministically), they are often sufficient for simulations, games, and procedural content generation.

A key advantage of PRNGs is reproducibility: the same initial "seed" value will always produce the same sequence 
of numbers, making it possible to recreate game worlds or test cases exactly. Understanding and implementing a 
PRNG helps in learning about randomness, entropy, and deterministic systems.

## Challenge

Implement a basic Linear Congruential Generator (LCG), one of the simplest types of PRNGs, using the formula:

```
X_{n+1} = (a * X_n + c) % m
```

Where:

* `X` is the sequence of pseudorandom values
* `a`, `c`, and `m` are constants
* `X_0` is the seed

Your task:

1. Write a function that generates the next number in the sequence.
2. Create a generator that yields a stream of pseudorandom numbers.
3. Visualize or print a few values to show their distribution.
4. (Optional) Use your PRNG to generate a simple procedural pattern (e.g., random terrain heights).

## Notes and References

* [Pseudorandom Number Generator](https://en.wikipedia.org/wiki/Pseudorandom_number_generator)
* [Linear Congruential Generator](https://en.wikipedia.org/wiki/Linear_congruential_generator)
