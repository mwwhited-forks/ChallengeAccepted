using static CardiacComputer.Cli.Opcodes;

namespace CardiacComputer.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        // https://www.cs.drexel.edu/~bls96/museum/cardiac.html

        var processor = Multiply();

        while (true)
        {
            foreach (var result in processor.Resume())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{result} ");
            }

            Console.WriteLine("again?");
            var ret = Console.ReadLine();
            if (ret == "") break;
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("fin!");
        Console.WriteLine(processor);
    }

    public static CardiacProcessor AddNumbers() => new(
        17,
        (INP, _a),      // get input a
        (INP, _b),      // get input b
        (CLA, _a),      // set accumulator to a
        (ADD, _b),      // add b to accumulator
        (STO, _result), // store to s
        (OUT, _result), // output s
        (HRS, 0)        // halt and reset
    );

    public static CardiacProcessor CountNumbers() => new CardiacProcessor(
        20,        //set entry point offset
        (CLA, 01), //set accumulator to value in 1

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3
        (ADD, 01), // increment 

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3
        (ADD, 01), // increment 

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3
        (ADD, 01), // increment 

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3
        (ADD, 01), // increment 

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3

        (HRS, 0)   // halt and reset
    ).Set(1, 1);   // set data value 1 to 1

    public static CardiacProcessor CountNumbersWithLoop() => new CardiacProcessor(
        20,
        (CLA, 01), //set accumulator to value in 1

        (STO, 03), // store accumulator to 3
        (OUT, 03), // output value in 3
        (ADD, 01), // increment 

        (JMP, 21)  // halt and reset
    ).Set(1, 1);   // set data value 1 to 1

    public static CardiacProcessor CountNumbersWithEnding() => new CardiacProcessor(
        20,

        (CLA, 17), // set accumulator to value from 17
        (ADD, 01), // add value from 1
        (STO, 17), // store value to 17 
        (OUT, 17), // output value in 17
        (ADD, 19), // add value from 1
        (TAC, 20), // if accumulator is < 0 then jump

        (HRS, 0)   // halt and reset
    ) 
    .Set(1, 1)     // seed data 1 as 1
    .Set(17, 0)    // seed data 17 as 0
    .Set(19, -4)   // see data 19 as -4
    ;

    public static CardiacProcessor CountNumbersWithEndingLong() => new CardiacProcessor(
        20,
        (CLA, 19), // set accumulator to value from 19
        (STO, 18), // store value to 18 

        (CLA, 18), // set accumulator to value from 18
        (ADD, 01), // add value from 1
        (STO, 18), // store value to 18 

        (CLA, 17), // set accumulator to value from 17
        (ADD, 01), // add value from 1
        (STO, 17), // store value to 18 
        (OUT, 17), // output value in 18

        (CLA, 18), // set accumulator to value from 18
        (TAC, 21), // if accumulator is < 0 then jump
        (HRS, 0)   // halt and reset
    )
    .Set(1, 1)     // seed data 1 as 1
    .Set(17, 0)    // seed data 17 as 0
    .Set(19, -4)   // see data 19 as -4
    ;

    const int _inc = 1;
    const int _zero = _inc + 1;
    const int _counter = _zero + 1;
    const int _result = _counter + 1;

    const int _a = _result + 1;
    const int _b = _a + 1;
    const int _temp = _b + 1;
    const int _c = _temp + 1;
    const int _d = _c + 1;

    public static CardiacProcessor CountNumbersTo() => new CardiacProcessor(
        20,

        /* 20 */(INP, _counter), // read value into counter (5)
        /* 21 */(CLA, _zero),    // set accumulator 0
        /* 22 */(STO, _result),  // set result to 0
        /* 23 */(SUB, _counter), // negate counter 
        /* 24 */(STO, _counter), // store counter 

        /* 25 */(CLA, _result),  // set accumulator to value from 4
        /* 26 */(ADD, _inc),     // add value from 1
        /* 27 */(STO, _result),  // store value to 4 
        /* 28 */(ADD, _counter), // add value from 1
        /* 29 */(TACoB, 5),      // if accumulator is < 0 then jump back 5

        /* 30 */(OUT, _result),  // output value in 4

        /* 31 */(HRS, 0)         // halt and reset
    )
    .Set(_inc, 1)                // seed data 1 as 1
    .Set(_zero, 0)               // seed data 2 as 0
    ;


    public static CardiacProcessor Multiply() => new CardiacProcessor(
        20,

        //read inputs 
        (INP, _a),          // 20: read A
        (INP, _b),          // 21: read B

        // if a < b then swap a and b
        (CLA, _b),          // 22: set accumulator b
        (SUB, _a),          // 23: subtract a 
        (TACoF, 6),         // 24: if a < b then swap
        (CLA, _a),          // 25: set accumulator to a
        (STO, _temp),       // 26: store a to temp
        (CLA, _b),          // 27: load b
        (STO, _a),          // 28: store b to a
        (CLA, _temp),       // 29: load temp
        (STO, _b),          // 30: store temp to b

        // clear result
        (CLA, _zero),       // 31: set accumulator 0
        (STO, _result),     // 32: set result to 0

        // setup counter
        (SUB, _b),          // 33: negate counter                          
        (STO, _counter),    // 34: store counter 

        // multiple a * b
        (CLA, _result),     // 35: set accumulator to value from 4
        (ADD, _a),          // 36: add value from 1
        (STO, _result),     // 37: store value to 4 
        (CLA, _counter),    // 38: set accumulator to value from 4
        (ADD, _inc),        // 39: add value from 1
        (STO, _counter),    // 40: store value to 4 
        (TACoB, 7),         // 41: if accumulator is < 0 then loop back

        // output result
        (OUT, _result),     // 42: output value in 4

        //(CLA, _result),
        //(SFT, 10),          // shift left
        //(STO, _c),          // store to c
        //(SFT, 02),          // shift right
        //(STO, _d),          // store to d
        //(OUT, _c),          // 42: output c
        //(OUT, _d),          // 42: output d

        // end
        (HRS, 0)            // 43: halt and reset
    )
    .Set(_inc, 1)           // seed data 1 as 1
    .Set(_zero, 0)          // seed data 2 as 0
    ;


    public static CardiacProcessor MultiplySimple() => new CardiacProcessor(
        20,

        //read inputs 
        (INP, _a),      // 20: read A
        (CLA, _a),      // 29: load temp
        (INP, _a),      // 20: read A
        (MUL, _a),      // 21: read B
        (STO, _result), // 32: set result to 0
        (OUT, _result), // 42: output value in 4
        (HRS, 00)       // 43: halt and reset
    )                   
    .Set(_inc, 1)       // seed data 1 as 1
    .Set(_zero, 0)      // seed data 2 as 0
    ;
}
