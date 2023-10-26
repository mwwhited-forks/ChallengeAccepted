# ![CARDIAC](./cardlogo.jpg)

## Source

This was copied from [CARDiac Museum](https://www.cs.drexel.edu/~bls96/museum/cardiac.html).  Conversion to Markdown, minor corrections and updated done by [Matthew Whited](https://github.com/mwwhited)

* [System Notes](./notes.md)
* [Example Applications](./notes-examples.md)

## Simulator

We have developed a [CARDIAC simulator](https://www.cs.drexel.edu/~bls96/museum/cardsim.html) suitable for running the code discussed on this page. All of the examples in the next section have been tested using this simulator.

To avoid any unnecessary requirements on screen layout, the simulator is laid out a little differently than the physical CARDIAC. At the top of the screen is the CARDIAC logo from a photograph of the actual unit. This picture is also a link back to this page. The next section of the screen is the CARDIAC memory space as appears on the right hand side of the physical device. When the simulator starts up, the value 001 in location 00 and the value 8-- in location 99 are preloaded. As a simplification, we don't use a picture of a ladybug for the program counter, but instead highlight the memory location to which the PC points with a light green background. Each memory location is editable (including the ones that are intended to be fixed), and the tab key moves focus down each column in memory address order.

The bottom section of the simulator is the I/O and CPU. Input is divided into two text areas. The first is the card deck and is editable. The second area is the card reader, and as cards are consumed by the reader they are removed from the listing in the reader. Cards in the deck are loaded into the reader with the Load button. Output cards appear in the Output text area as they are generated with the OUT instruction.

### Simulator Control 

The CPU section of the simulator has four parts showing the status of the CPU and buttons for control. On the top of the CPU section, the Program Counter is shown in an editable text box. Below that is the instruction decoder with non-editable text boxes showing the contents of the Instruction Register and a breakdown of the instruction decoding in the form of an opcode mnemonic and numeric operand. The Accumulator is shown below the instruction decoder. Below the register display are six buttons that control the operation of the simulator:

#### Reset

The Reset button clears the instruction register, resets the PC and accumulators to 0 and clears the output card deck.

#### Clear Mem

This button resets all memory locations to blank and re-initializes location 00 to 001 and location 99 to 8--.

#### Step

Clicking on the Step button causes the simulator to execute the single instruction highlighted in the memory space as pointed to by the program counter. Upon completion of the instruction, the screen is updated to show the state of the computer after the instruction.

#### Slow

The Slow button causes the simulator to begin executing code starting at the current PC. Instructions are executed at the rate of 10 per second with the screen being updated after each instruction. When the program is run in this way, the movement of the highlighted memory shows the flow of control in the program very clearly.

#### Run

In the current version of the simulator, the Run button causes the program to be executed beginning from the current PC at the full speed of the JavaScript interpreter. Because of the way JavaScript is typically implemented, the screen contents will not show the effects of code execution until the simulator executes the HRS instruction and the program halts.

#### Halt

Pressing the Halt button while the program is running in slow mode causes the simulator to stop after the current instruction. The state of the machine remains intact and can be continued with any of the Step, Slow, or Run buttons.

## Original Material 

This was copied from [CARDiac Museum](https://www.cs.drexel.edu/~bls96/museum/cardiac.html).  

* [Brian L. Stuart](http://cs.drexel.edu/~bls96/) 
* [Department of Computer Science](http://cs.drexel.edu/)
* [Drexel University](http://www.drexel.edu/)

## Updates and Corrections

Conversion to Markdown, minor corrections and updated done by [Matthew Whited](https://github.com/mwwhited)

* [System Notes](./notes.md)