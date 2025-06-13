# Expression Plotter

## Summary

Create a program that takes a mathematical function of one variable (for example, `f(x) = sin(x) + 0.5*x`) and draws its graph as a continuous line over a specified domain—**without** relying on any external plotting libraries.

## Challenge

- Parse a user‑provided function of `x` from a string
- Let the user specify:

  - The domain: start and end values for `x`
  - The resolution: number of sample points (or step size)
  - The output canvas size in pixels (width × height)

- Evaluate the function at evenly spaced `x` values to get `(x, y)` pairs
- Map the `(x, y)` coordinates to pixel coordinates on your canvas
- Implement a line‑drawing algorithm (e.g., Bresenham’s or Digital Differential Analyzer) to connect successive sample points
- Render the result to a simple image format you write yourself (for example, PPM) or draw into a pixel buffer and display via a minimal windowing API

## Bonus

- Plot multiple functions in different shades by varying pixel intensity
- Draw axes with tick marks and labels by manually rasterizing text or simple tick‑marks
- Allow panning and zooming by recalculating samples and redrawing on demand
- Extend to parametric plots: take `x(t), y(t)` over a `t` range and draw the curve

## Notes and References

- [Expression Parser](../ExpressionParser/readme.md)
- [Bresenham’s line algorithm – Wikipedia](https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm)
- [Digital Differential Analyzer – Wikipedia](https://en.wikipedia.org/wiki/Digital_differential_analyzer_%28graphics_algorithm%29)
- Consider outputting a plain‑text PPM image for simplicity.
