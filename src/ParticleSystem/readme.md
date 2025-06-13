# Particle System

## Summary

Particle systems simulate large numbers of small particles to create effects like fire, smoke, fountains, 
hair, or gravitational N-body interactions. Each particle follows simple rules and is rendered collectively
to produce complex, chaotic visuals.

## Challenge

- Design a particle emitter that spawns particles over time
- Define particle properties such as position, velocity, lifetime, size, and color
- Implement an update loop that:

  - Applies forces (gravity, wind, attraction/repulsion)
  - Updates particle position and velocity each frame
  - Decreases particle lifetime and removes expired particles

- Render particles as simple shapes (points, circles, lines) in a text-based or graphical output
- Allow user parameters for:

  - Emission rate and burst size
  - Initial velocity range and direction
  - Lifespan and fade-out behavior

## Bonus

- Add collision detection so particles bounce off boundaries or interact with obstacles
- Simulate special effects:

  - Fire and smoke with color gradients and fading
  - Water fountain with gravity and splash particles
  - Hair or string as linked particles with spring constraints

- Implement an N-body gravity simulator where particles attract each other under Newtonian gravity
- Provide an interactive UI to tweak parameters in real time

## Notes and References

- [Particle System – Wikipedia](https://en.wikipedia.org/wiki/Particle_system)
- [N-body Simulation – Wikipedia](https://en.wikipedia.org/wiki/N-body_simulation)
