# Conway’s Game of Life

## Summary

Conway’s Game of Life is a zero-player cellular automaton where an initial pattern evolves over 
discrete time steps according to simple rules. Despite its simplicity, it can produce remarkably 
complex behaviors.

## Challenge

- Represent the game grid (infinite or bounded) and an initial set of live cells
- Implement the update rules for each generation:

  1. Any live cell with fewer than two live neighbors dies (underpopulation)
  2. Any live cell with two or three live neighbors lives on
  3. Any live cell with more than three live neighbors dies (overpopulation)
  4. Any dead cell with exactly three live neighbors becomes alive (reproduction)

- Advance the simulation step by step and display each generation
- Choose any interface: command‑line (ASCII), simple GUI, or graphical window

## Bonus

- Add controls to pause, step forward/backward, or adjust the simulation speed
- Support drawing or loading predefined patterns (e.g., gliders, pulsars, Gosper’s glider gun)
- Implement an “infinite” grid using a sparse data structure (e.g., hash set of live cells)
- Visualize population statistics over time (e.g., live‑cell count graph)

## Notes and References

- [Conway’s Game of Life – Wikipedia](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)
- [ConwayLife.com (pattern collections)](https://conwaylife.com/)
