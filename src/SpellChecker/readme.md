# Spell Checker

## Summary

Spell checking identifies and corrects misspelled words by comparing input text against a 
dictionary and suggesting the closest valid alternatives. Efficient checkers combine fast 
lookup structures with approximate string‑matching algorithms.

## Challenge

- Load or define a dictionary of valid words
- Implement a function to detect if a given word is in the dictionary
- When a word is not found, generate candidate corrections using one or more techniques:

  - Compute edit distances (insertions, deletions, substitutions, transpositions)
  - Use a BK‑tree or similar metric tree for fast nearest‑neighbor search
  - Apply heuristics like swapping adjacent letters or splitting/joining words

- Rank suggestions by likelihood (e.g., minimal edit distance, word frequency)
- Design an interface to input text and output misspellings with suggested corrections

## Bonus

- Use the Wagner–Fischer algorithm to compute Levenshtein distances efficiently
- Enhance suggestions with n‑gram language models or word frequency corpora
- Implement context‑aware correction by examining surrounding words
- Support real‑time suggestions as the user types (e.g., in a GUI or web form)

## Notes and References

- [Wagner–Fischer algorithm](https://en.wikipedia.org/wiki/Wagner%E2%80%93Fischer_algorithm)
- [BK‑tree](https://en.wikipedia.org/wiki/BK-tree)
- [Levenshtein distance](https://en.wikipedia.org/wiki/Levenshtein_distance)
- [Gestalt pattern matching](https://en.wikipedia.org/wiki/Gestalt_pattern_matching)
- [Approximate string matching](https://en.wikipedia.org/wiki/Approximate_string_matching)
