# ![CARDIAC](./cardlogo.jpg)

## Source

This was copied from [CARDiac Museum](https://www.cs.drexel.edu/~bls96/museum/cardiac.html).  Conversion to Markdown, minor corrections and updated done by [Matthew Whited](https://github.com/mwwhited)

* [System Notes](./notes.md)
* [Simulator Notes](./notes-simulator.md)

## Examples

The remainder of this page are a number of examples of programs written for the CARDIAC. They have all been tested using the [simulator](./notes-simulator.md). Because the memory space of the CARDIAC is so limited, none of the programs are particularly complex. You won't find a compiler, operating system, or web browser here. However, we do have a few of more complexity than you might expect. There's a pretty simple program for generating a list of the powers of 2. There's one that recursively solves the Towers of Hanoi problem. For each of them, we include the assembly language source code with assembled machine language code and a card deck suitable for bootstrapping on the CARDIAC.

Note that most of these examples aren't the most compact way of solving the problem. Rather, they illustrate techniques as described through this page. The primary exception is the Towers of Hanoi solution which required some effort to squeeze it into the limited memory space of the CARDIAC.

When we take these programs and turn them into decks of cards to be bootstrapped on the CARDIAC, we get the card decks listed below the program listings. If you cut and paste the list into the input deck of the simulator, hit load, and hit slow, you can see the program get loaded into memory and run.

Count from 1 to 10
This is sort of our CARDIAC version of "Hello World." Our objective is simply to print out a set of output cards with the values 1 to 10. We keep two variables to control the process. One, called n keeps track of how many cards we still have left to print. At any point in time it represents that we need to print n+1 more cards. We also have a variable called cntr which is the number to print out. Each time through the loop, we check to see if n is negative and if so, we're done. If not, we decrement it, print cntr and then increment cntr.

#### Program Listing

```assembly
04  009  n       DATA  009
05  000  cntr    DATA  000

10  100          CLA   00    Initialize the counter
11  605          STO   cntr   
12  104  loop    CLA   n    If n < 0, exit
13  322          TAC   exit
14  505          OUT   cntr    Output a card
15  105          CLA   cntr    Increment the card
16  200          ADD   00
17  605          STO   cntr
18  104          CLA   n    Decrement n
19  700          SUB   00
20  604          STO   n
21  812          JMP   loop
22  900  exit    HRS   00
```

#### Card Deck

```input
002
800
010
100
011
605
012
104
013
322
014
505
015
105
016
200
017
605
018
104
019
700
020
604
021
812
022
900
004
009
002
810
```

### List Reversal

Our next example uses the [stack techniques](./notes.md#stacks) to take in a list of cards and output the same list in reverse order. The first card in the input deck (after the bootstrapping and the program code) is the count of how many cards we're operating on. The remainder of the input deck are the cards to reverse. In the example card deck, we are reversing the first seven [Fibonacci numbers](http://en.wikipedia.org/wiki/Fibonacci_number).

#### Program Listing

```assembly
04  600  storer  DATA  600  
05  100  loader  DATA  100  
06  089  tos     DATA  089     Stack pointer
07  000  acc     DATA  000     Temp for saving accumulator
08  000  n1      DATA  000     Write counter
09  000  n2      DATA  000     Read counter
   
10  008          INP   n1      Get the number of cards to reverse
11  108          CLA   n1      Initialize a counter
12  609          STO   n2      
13  109  rdlp    CLA   n2      Check to see if there are any more cards to read
14  700          SUB   00
15  327          TAC   wrlp
16  609          STO   n2
17  007          INP   acc     Read a card
18  106          CLA   tos     Push it onto the stack
19  204          ADD   storer
20  625          STO   stapsh
21  106          CLA   tos
22  700          SUB   00
23  606          STO   tos
24  107          CLA   acc
25  600  stapsh  STO   00
26  813          JMP   rdlp
27  108  wrlp    CLA   n1      Check to see if there are any more cards to write
28  700          SUB   00
29  339          TAC   done
30  608          STO   n1   
31  106          CLA   tos     Pop a card off the stack
32  200          ADD   00
33  606          STO   tos
34  205          ADD   loader
35  636          STO   stapop
36  100  stapop  CLA   00
37  890          JMP   aprint  Output a card
38  827          JMP   wrlp
39  900  done    HRS   00

90  696  aprint  STO   96      Write a card containing the contents of the accumulator
91  199          CLA   99
92  695          STO   aexit
93  596          OUT   96
94  196          CLA   96
95  800  aexit   JMP   00
```

Card Deck

```input 
002
800
004
600
005
100
006
089
007
000
008
000
009
000
010
008
011
108
012
609
013
109
014
700
015
327
016
609
017
007
018
106
019
204
020
625
021
106
022
700
023
606
024
107
025
600
026
813
027
108
028
700
029
339
030
608
031
106
032
200
033
606
034
205
035
636
036
100
037
890
038
827
039
900
090
696
091
199
092
695
093
596
094
196
095
800
002
810
007
001
001
002
003
005
008
013
```

### Powers of 2

This is a slightly more interesting version of the list from 1 to 10. In this case, we are printing the powers of 2 from 0 to 9. The main difference is that instead of incrementing the number to output, we call a subroutine that doubles it. The program illustrates the use of [multiple subroutines](./notes.md#multiple-subroutines).

#### Program Listing

```assembly
04  000  n       DATA  000
05  009  cntr    DATA  009
 
10  100          CLA   00      Initialize the power variable with 2^0
11  880          JMP   aprint
12  604  loop    STO   n
13  105          CLA   cntr    Decrement the counter
14  700          SUB   00
15  321          TAC   exit    Are we done yet?
16  605          STO   cntr
17  104          CLA   n
18  890          JMP   double  Double the power variable
19  880          JMP   aprint  Print it
20  812          JMP   loop
21  900  exit    HRS   00

80  686  aprint  STO   86      Print a card with the contents of the accumulator
81  199          CLA   99
82  685          STO   aexit
83  586          OUT   86
84  186          CLA   86
85  800  aexit   JMP   00

90  696  double  STO   96      Double the contents of the accumulator
91  199          CLA   99
92  695          STO   dexit
93  196          CLA   96
94  296          ADD   96
95  800  dexit   JMP   00
```

#### Card Deck

```input
002
800
005
009
010
100
011
880
012
604
013
105
014
700
015
321
016
605
017
104
018
890
019
880
020
812
021
900
080
686
081
199
082
685
083
586
084
186
090
696
091
199
092
695
093
196
094
296
002
810
```

### Towers of Hanoi

By far the most complex example we include is a solution to the Towers of Hanoi problem. The puzzle consists of three posts on which disks can be placed. We begin with a tower of disks on one post with each disk smaller than the one below it. The other two posts are empty. The objective is to move all of the disks from one post to another subject to the following rules:

Only one disk at a time may be moved.
No disk may be placed on top of a smaller disk.
According to legend, there is a set of 64 disks which a group of monks are responsible for moving from one post to another. When the puzzle with 64 disks is finally solved, the world will end.

Although the puzzle sounds like it would be difficult to solve, it's very easy if we think recursively. Moving n disks from Post a to Post b using Post c as a spare can be done as follows:

Move n−1 disks from Post a to Post c.
Move one disk from Post a to Post b.
Move n−1 disks from Post c to Post b.
The CARDIAC doesn't have enough memory to solve a 64-disk puzzle, but we can solve smaller instances of the problem. In particular, the program we show here can solve up to six disks. The actual number of disks to solve is given by the first data card, and the initial assignment of source destination and spare posts is given on the second data card. The post assignments as well as the output encoding are shown in the following table.

Output   Disk Move
000   1 → 3
001   2 → 3
002   3 → 2
003   3 → 1
004   2 → 1
005   1 → 2
For example, the post assignments indicated by a card with the value 3 are that Post 3 is a, Post 2 is c and Post 1 is b. Similarly, an output card with 3 indicates that we are to move a disk from Post 3 to Post 1.

Before trying to understand the details of this program, note that there are several tricks used to reduce the memory usage. The amount of memory available for the stack allows for a puzzle of up to six disks to be solved with this program. Be aware, however, that slow running this program on six disks takes the better part of a half hour to run.

#### Program Listing

```assembly
03  031  tos      DATA  031
04  100  loader   DATA  100
05  600  storer   DATA  600
06  107  r2ld     DATA  r2
07  001  r2       DATA  001
08  000           DATA  000
09  005  five     DATA  005
10  004           DATA  004
11  003  three    DATA  003
12  002           DATA  002
  
34  033           INP   32       Get the number of disks from the cards
35  032           INP   31       Get the column ordering from the cards
36  838           JMP   tower    Call the tower solver
37  900           HRS     
    
38  199  tower    CLA   99       Push the return address on the stack
39  890           JMP   push  
40  111           CLA   three    Fetch n from the stack
41  870           JMP   stkref  
42  700           SUB   00       Check for n=0
43  366           TAC   towdone
44  890           JMP   push     Push n-1 for a recursive call
45  111           CLA   three    Get the first recursive order
46  870           JMP   stkref
47  669           STO   t1
48  109           CLA   five
49  769           SUB   t1
50  890           JMP   push
51  838           JMP   tower    Make first recursive call
52  880           JMP   pop
53  111           CLA   three    Get move to output
54  870           JMP   stkref
55  669           STO   t1
56  569           OUT   t1
57  111           CLA   three    Get second recursive order
58  870           JMP   stkref
59  206           ADD   r2ld
60  661           STO   t2
61  100  t2       CLA   00
62  890           JMP   push
63  838           JMP   tower    Make second recursive call
64  880           JMP   pop
65  880           JMP   pop
66  880  towdone  JMP   pop
67  668           STO   towret
68  800  towret   JMP   00

70  679  stkref   STO   refsav   Replace the accumulator with the contents
71  199           CLA   99       of the stack indexed by the accumulator
72  678           STO   refret
73  179           CLA   refsav
74  203           ADD   tos
75  204           ADD   loader
76  677           STO   ref
77  100  ref      CLA   00
78  800  refret   JMP   00

80  199  pop      CLA   99       Pop the stack into the accumulator
81  688           STO   popret
82  103           CLA   tos
83  200           ADD   00
84  603           STO   tos
85  204           ADD   loader
86  687           STO   popa
87  100  popa     CLA   00
88  800  popret   JMP   00

90  689  push     STO   pshsav   Push the accumulator on to the stack
91  103           CLA   tos
92  205           ADD   storer
93  698           STO   psha
94  103           CLA   tos
95  700           SUB   00
96  603           STO   tos
97  189           CLA   pshsav
98  600  psha     STO   00
```

#### Card Deck

```input
002
800
003
031
004
100
005
600
006
107
007
001
008
000
009
005
010
004
011
003
012
002
034
033
035
032
036
838
037
900
038
199
039
890
040
111
041
870
042
700
043
366
044
890
045
111
046
870
047
669
048
109
049
769
050
890
051
838
052
880
053
111
054
870
055
669
056
569
057
111
058
870
059
206
060
661
061
100
062
890
063
838
064
880
065
880
066
880
067
668
068
800
070
679
071
199
072
678
073
179
074
203
075
204
076
677
077
100
078
800
080
199
081
688
082
103
083
200
084
603
085
204
086
687
087
100
088
800
090
689
091
103
092
205
093
698
094
103
095
700
096
603
097
189
098
600
002
834
003
000
```

### Pythagorean Triples

The next example comes courtesy of Mark and Will Tapley. It finds sets of three integers which satisfy the Pythagorean property of `x2 + y2 = z2`.

#### Discussion

There is much motivation and explanation for this program at: [What was up with Pythagoras?](https://www.khanacademy.org/math/math-for-fun-and-glory/vi-hart/vi-cool-stuff/v/what-was-up-with-pythagoras)

#### Subroutine to calculate square of a number 

In finding pythagorean triplets, the operation of squaring a number occurs very often, so the program uses a subroutine to perform this function.

* Addresses 076–099 are loaded with the subroutine to utilize the return function hard-wired at address 099.

* Addresses 072–075 are used for data storage for the subroutine.

* Address 072 is loaded with the value 32, one larger than the largest allowable input. The calling program can test an input by subtracting this value from the prospective input and branching if the result is negative. (Negative value means legal input.)

* Address 073 accepts the input to the subroutine. On return, the absolute value of the input will be in this location.

* Address 074 is used as a counter during routine execution.

* Address 075 will contain the calculated square, an integer between 0 and 961 inclusive.

#### Subroutine INPUT

Store the number to be squared in address 073
Jump to address 077 (label SQmem in assembly listing)

-OR-

Load the number to be squared into the accumulator
Jump to address 076 (label SQacc in assembly listing)

#### Subroutine OUTPUT

On return, the square of the input number is in address 075.

The subroutine has a single loop (addresses 090–098). In each loop, it subtracts one from a counter which is initially set to one greater than the input number N, then adds a copy of N into the output address. When the counter reaches 1, the output address contains the sum of N copies of `N=N^2` and the loop exits, returning program control to the location from which it was called (per the return capability special function of location 99).

#### Limitations
The square of the input number must have 3 or fewer digits to comply with cell storage limitations. Therefore the input number is checked to be 31 or less (since 32^2=1024). Violating this condition will cause the subroutine to terminate execution (HRS) with the program counter pointing at location 086. The input number is converted from negative to positive if it was negative, so if the calling program needs a copy of the input, it should store it in some location other than Address 073 (SQIN). After the subroutine executes, that location will contain the absolute value of the input.

#### Main Program 

The main program searches over all allowable lengths of the shortest side S of the right triangles corresponding to pythagorean triplets. For each shortest side, it then searches over all possible lengths of the intermediate side L. For each combination of short and intermediate sides, it checks whether there is a hypotenuse H that satisfies the condition `S2 + L2 = H2`. The short side (S) search starts at 0, to avoid missing any triplets with very small values. (This results in identifying the degenerate triplet (0,1,1) which does satisfy 02+12=12 but does not really correspond to a right triangle.) The long side (L) search for each value of S starts at S+1, because L cannot equal S for an integer triplet (see URL above) and if L<S, the corresponding triplet should already have been found with a smaller S. (So, this program will identify (3,4,5) but will not identify (4,3,5).) The hypotenuse (H) search starts at 1.4 times S, since the minimum possible length of the hypotenuse is greater than the square root of 2 (1.404...) times S. (Note: 1.4 times S is calculated by shifting S right and then adding four copies of the result, which is truncated to an integer, to S. For S<10, the result is just S, so the search takes needlessly long until S≥10.)

With the starting values for S, L, and H, the program calculates `S^2 + L^2 − H^2`. If the result is <0, H is too long. In this case, the program increments L and tries again. If the result is =0, a triplet has been found and is printed out. The program then increments L and tries again. If the result is >0, H is too short. In this case, H is incremented and the program tries again. When H is long enough that no more triplets can be found for this value of S, the value of S is incremented, new L and H starting values are calculated, and the loop repeats.

* Addresses 010–067 are loaded with the main program.

* Addresses 004–009 are used for data storage.

* Address 004 contains S, the smallest member of the triplet (length of the short leg of the triangle) and is initially set to 0.

* Address 005 contains S2, calculated each time S is changed.

* Address 006 contains L, the intermediate member of the triplet (length of the long "leg" of the triangle) and is re-initialized for each smallest member loop to one greater than the smallest member (which is always the minimum possible value for L; see above)

* Address 007 contains L2, calculated each time L is changed.

* Address 008 contains H, the largest member of the triplet (length of the hypotenuse of the triangle) and is initialized for each smallest member to a value <1.4×(the smallest value) (which is always shorter than the minimum possible value for H)

* Address 009 contains H2, calculated each time H is changed. The same address also contains S/10 (S shifted right by one place), used to initialize H each time S is changed. This value is used to set the initial value of H to 1.4 S, which is just less than √2S.

The "outside" loop of the program (addresses 010–067) tests for all possible sets of triplets with the smallest value S stored in 004. After each loop, it increments the value of S and tries again. This loop will terminate when the value of 1.4×S exceeds 31, since the subroutine will no longer be able to calculate correct squares for any possible hypotenuse value (H). The subroutine will halt execution when this input is sent to it. (The outer loop also contains a check to verify that the value of S itself doesn't exceed 31, but this check is never reached.)

The next-inner loop (addresses 032–061) starts with a value of `L=S+1`. Any smaller, and L would take the role of S (and hence, the resulting triplet would have already been found with a smaller S) or would be qual to S (and the length of the corresponding hypotenuse would be irrational). This loop terminates on one of two conditions: first, when the value of H exceeds 31 (in which case the subroutine to calculate squares can no longer work); or second, when 2L>S2. This latter condition applies because once L exceeds S2/2, L2 and H2 cannot differ by as little as S2 even if H=L+1. At that point, `H^2−L^2 = (L+1)^2−L^2=2L+1>S^2`.

The innermost section (addresses 032–044) calculates the difference `S^2+L^2−H^2`. If the difference is positive, H is incremented and the loop repeats. If the difference is zero, a triplet has been found and the values of S, L, and H are printed out. If the difference is negative or zero, L is then incremented and the loop repeats. In any case where H is incremented, its new value is checked against the limit for inputs to the subroutine, and if it exceeds that limit, the inner two loops terminate and the outer loop progresses to the next value of S.

#### Independent Verification

The code below is instructions to Mathematica (tested on versions 8 and 3) which should compute the same output as the above program, but using a more general (and slower) algorithm. It will also generate a plot of triplets by (short side) against (intermediate side).

```mathematica
candid = 
Table[
   Table[
        Table[
           {i, j, k}, 
           {k, j, i^2/2 + 2}
        ], 
        {j, i+1, i^2/2 + 1}
   ], 
    {i, 0, 31}
];

trips = Select[Flatten[candid, 2], #1[[1]]^2 + #1[[2]]^2 == #1[[3]]^2 & ];

smalltrips = Select[trips, #1[[3]] < 32 & ]

ListPlot[(Take[#1, 2] & ) /@ trips]
```

#### Program Listing

##### Symbol map

| Address | Variable | Description                            |
| ------- | -------- | -------------------------------------- |
| 04      | S        | short side = 0 initially               |
| 05      | S2       | square of short side                   |
| 06      | L        | long side                              |
| 07      | L2       | square of long side                    |
| 08      | H        | hypotenuse                             |
| 09      | H2       | square of hypotenuse. (Also used to store S/10 in picking initial value of H each loop.) |
| 72      | SQLIM    | maximum input to Square = 30 initially |
| 73      | SQIN     | input to square subroutine             |
| 74      | SQCNT    | counter for square subroutine          |
| 75      | SQOUT    | output for square subroutine           |

| Address |  Name (as referenced by JMP) |
| ------- | ---------------------------- |
| 00      | BootLp                       |
| 10      | S_Loop                       |
| 32      | L_Loop                       |
| 45      | Next_H                       |
| 49      | PrintTr                      |
| 52      | Inc_L                        |
| 62      | Next_S                       |
| 76      | SQacc                        |
| 77      | SQmem                        |
| 83      | SQpos                        |
| 87      | SQgood                       |
| 90      | SQloop                       |


```assembly
002  800  BootLp  JMP   BootLp   Bootstrap loop. Code self-modifies to load memory locations.
```

```assembly
002  810          JMP   S_Loop   Jump out of boot loop to 10 (skips initial increment to S)

004  000          DATA  S        Initial value for Short side = 0
072  032          DATA  SQLIM    Limit on input to square = 32

010  104  S_Loop  CLA   S       
011  673          STO   SQIN     Input to square subroutine
012  200          ADD   1        (Using ROM value)
013  606          STO   L        Save long side L
014  877          JMP   SQmem    Square subroutine (saved entry)
015  175          CLA   SQOUT    Retrieve result of subroutine
016  605          STO   S2       Store square of S
017  106          CLA   L        Load L
018  876          JMP   SQacc    Square subroutine, entry using ACC
019  175          CLA   SQOUT    Retrieve result of subroutine
020  607          STO   L2       Store square of L
021  104          CLA   S        Load S
022  401          SFT   01       Divide by 10
023  609          STO   H2       Save S/10 temporarily in H2 location
024  209          ADD   H2       Sum into accumulator
025  209          ADD   H2       Sum into accumulator
026  209          ADD   H2       Sum into accumulator
027  204          ADD   S        Sum is now between S and 1.4 S ~ S sqrt(2)
028  608          STO   H        Store initial hypotenuse H
029  876          JMP   SQacc    Square subroutine (accumulator entry)
030  175          CLA   SQOUT 
031  609          STO   H2       Store square of H

032  105  L_Loop  CLA   S2       Load short side squared
033  207          ADD   L2       Add long side squared
034  709          SUB   H2       Subtract hyp. squared
035  352          TAC   Inc_L    if H2 too big, increment L
036  700          SUB   1        Subtract 1 (ROM)
037  349          TAC   PrintTr  H was just right - print
038  108          CLA   H        H too small, so load H
039  200          ADD   1        Add 1 (ROM)
040  608          STO   H        Store back
041  673          STO   SQIN     Save in input to Square routine
042  772          SUB   SQLIM    Subtract limit for input
043  345          TAC   Next_H   Go on if negative (input < 32)
044  862          JMP   Next_S   Branch to next value of S if not.
  
045  877  Next_H  JMP   SQmem    (saved entry)
046  175          CLA   SQOUT    Get result
047  609          STO   H2
048  832          JMP   L_Loop   Try again
  
049  504  PrintTr OUT   S        Print S
050  506          OUT   L        Print L
051  508          OUT   H        Print H
  
052  106  Inc_L   CLA   L        Load L
053  200          ADD   1        Increment
054  606          STO   L        Store
055  876          JMP   SQacc    Square subr.
056  175          CLA   SQOUT    get result
057  607          STO   L2       Store new L squared
058  106          CLA   L        Load new L
059  206          ADD   L        Double it
060  705          SUB   S2       Subtract S^2
061  332          TAC   L_Loop   If S^2 still bigger, keep looking
  
062  104  Next_S  CLA   S        Load short side S
063  200          ADD   1        Increment
064  604          STO   S        Store short side S
065  772          SUB   SQLIM    Subtract upper limit for Square
066  310          TAC   S_Loop   If result is negative, new S is low enough to loop again
067  900          HRS   00       Else, S is longer than Square can handle, so Done - exit.
  
076  673  SQacc   STO   SQIN     Jump here if input value is in ACC
    
077  173  SQmem   CLA   SQIN     Jump here if input is already in SQIN
078  773          SUB   SQIN     Input was in both accumulator and SQIN, so this gets 0
079  675          STO   SQOUT    initialize output to 0 for use later
080  773          SUB   SQIN     This gets negative of SQIN
081  383          TAC   SQpos    If the negative is negative, SQIN is positive - good.
082  673          STO   SQIN     If the negative is positive, store that in SQIN.
  
083  173  SQpos   CLA   SQIN     Load Absolute value of input
084  772          SUB   SQLIM    Compare against limit value
085  387          TAC   SQgood   Quit if number to square > limit
086  986          HRS   00       Halt if error on input.
  
087  173  SQgood  CLA   SQIN     Retrieve number
088  200          ADD   0        Add one
089  674          STO   SQCNT    Count is input + 1
  
090  174  SQloop  CLA   SQCNT    load counter
091  700          SUB   0        subtract 1
092  674          STO   SQCNT    save new counter value
093  175          CLA   SQOUT    load output
094  273          ADD   SQIN     add a copy of input
095  675          STO   SQOUT    store cumulative sum
096  100          CLA   0        load 1 (from ROM)
097  774          SUB   SQCNT    subtract counter
098  390          TAC   SQloop   loop again if counter was > 1  
          
```

#### Card Deck

```input
002
800
004
000
072
032
010
104
011
673
012
200
013
606
014
877
015
175
016
605
017
106
018
876
019
175
020
607
021
104
022
401
023
609
024
209
025
209
026
209
027
204
028
608
029
876
030
175
031
609
032
105
033
207
034
709
035
352
036
700
037
349
038
108
039
200
040
608
041
673
042
772
043
345
044
862
045
877
046
175
047
609
048
832
049
504
050
506
051
508
052
106
053
200
054
606
055
876
056
175
057
607
058
106
059
206
060
705
061
332
062
104
063
200
064
604
065
772
066
310
067
900
076
673
077
173
078
773
079
675
080
773
081
383
082
673
083
173
084
772
085
387
086
986
087
173
088
200
089
674
090
174
091
700
092
674
093
175
094
273
095
675
096
100
097
774
098
390
002
810
```

## Original Material 

This was copied from [CARDiac Museum](https://www.cs.drexel.edu/~bls96/museum/cardiac.html).  

* [Brian L. Stuart](http://cs.drexel.edu/~bls96/) 
* [Department of Computer Science](http://cs.drexel.edu/)
* [Drexel University](http://www.drexel.edu/)

## Updates and Corrections

Conversion to Markdown, minor corrections and updated done by [Matthew Whited](https://github.com/mwwhited)

* [System Notes](./notes.md)