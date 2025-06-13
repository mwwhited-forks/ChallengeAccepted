# Grid Layout

## Summary

Create a rectangular grid of size **X × Y** filled with **C** different colors such that the number of adjacent 
cells sharing the same color is minimized. This can be used to design quilt patterns, mosaics, or any tiled
artwork where you want to avoid large blocks of the same color.

## Challenge

- Generate an empty grid with dimensions `X` (columns) and `Y` (rows\`.

- Assign to each cell one of `C` colors.

- Define adjacency as cells sharing an edge (up, down, left, right).

- Calculate the total “conflicts” as the count of adjacent cell pairs with identical colors.

- Implement an algorithm to fill or iteratively adjust the grid to **minimize** these conflicts. Possible approaches:

  - Greedy coloring with local swaps
  - Backtracking search with pruning
  - Simulated annealing or hill‑climbing
  - Constraint programming

- Your program should take three inputs:

  1. `X` (number of columns)
  2. `Y` (number of rows)
  3. `C` (number of colors)

- Output the final grid and the conflict count.

## Bonus

- Visualize the grid (ASCII art, GUI, or export to an image).
- Support diagonal adjacency rules (8‑neighborhood).
- Allow weighted adjacency costs (e.g., penalize certain color pairs more heavily).
- Compare different optimization strategies and report their conflict counts and runtimes.
- Extend to non‑rectangular or hexagonal grids.

## Notes and References

- [Graph coloring – Wikipedia](https://en.wikipedia.org/wiki/Graph_coloring)
- [Simulated annealing – Wikipedia](https://en.wikipedia.org/wiki/Simulated_annealing)
- Quilt design inspiration: mosaic and tiling patterns.
