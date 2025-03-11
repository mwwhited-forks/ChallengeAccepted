using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMaze
{
    [Flags]
    public enum CellTypes
    {
        Open = 0x00,
        North = 0x01,
        South = 0x02,
        East = 0x04,
        West = 0x08,
        Visted = 0x10,
    }


    // http://www.pinvoke.net/default.aspx/kernel32/ConsoleFunctions.html
    class Program
    {
        // https://www.howtobuildsoftware.com/index.php/how-do/bbch/c-performance-console-application-pinvoke-tetris-pinvoke-speed-up-consolewrite
        static void Main(string[] args)
        {
            Console.Clear();

            var (top, left) = (0, 0);
            var (width, height) = (30, 8);
            var stroke = 2;

            var stack = new Stack<(int x, int y)>();
            var cells = new CellTypes[width, height];

            var rand = new Random();

            var current = (x: 0, y: 0);
            stack.Push(current);
            while (true)
            {
                cells[current.x, current.y] |= CellTypes.Visted;
               // draw();

                var openNeighbors = from n in new[]
                 {
                    new { x = current.x + 0, y = current.y + 1, dir = CellTypes.South },
                    new { x = current.x + 0, y = current.y - 1, dir = CellTypes.North },
                    new { x = current.x + 1, y = current.y + 0, dir = CellTypes.East },
                    new { x = current.x - 1, y = current.y + 0, dir = CellTypes.West },
                }
                                    where 0 <= n.x && n.x < width
                                    where 0 <= n.y && n.y < height
                                    let cell = cells[n.x, n.y]
                                    where !cell.HasFlag(CellTypes.Visted)
                                    orderby rand.Next()
                                    select new { postion = n, state = cell };
                var selectedNeighbor = openNeighbors.FirstOrDefault();

                if (selectedNeighbor == null)
                {
                    if (stack.Count == 0) break;
                    //backtrack
                    current = stack.Pop();
                }
                else
                {
                    var next = (selectedNeighbor.postion.x, selectedNeighbor.postion.y);
                    cells[current.x, current.y] |= selectedNeighbor.postion.dir;
                    cells[next.x, next.y] |= (selectedNeighbor.postion.dir) switch
                    {
                        CellTypes.North => CellTypes.South,
                        CellTypes.South => CellTypes.North,
                        CellTypes.East => CellTypes.West,
                        CellTypes.West => CellTypes.East,
                        _ => throw new ApplicationException("oopz")
                    };
                    current = next;
                    stack.Push(current);
                    continue;
                }
            }

            void draw()
            {
                Console.Clear();
                for (var x = 0; x < width; x++)
                {
                    for (var y = 0; y < height; y++)
                    {
                        var cell = cells[x, y];
                        if ((x,y) == current)
                        {
                            Console.SetCursorPosition((left + x) * stroke + 1, (top + y) * stroke + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write('@');
                        }

                        //Draw corners
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition((left + x) * stroke + 0, (top + y) * stroke + 0);
                        Console.Write('+');
                        Console.SetCursorPosition((left + x) * stroke + 2, (top + y) * stroke + 2);
                        Console.Write('+');
                        Console.SetCursorPosition((left + x) * stroke + 2, (top + y) * stroke + 0);
                        Console.Write('+');
                        Console.SetCursorPosition((left + x) * stroke + 0, (top + y) * stroke + 2);
                        Console.Write('+');

                        //draw visited or not
                        Console.SetCursorPosition((left + x) * stroke + 1, (top + y) * stroke + 1);
                        if (cell.HasFlag(CellTypes.Visted))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('#');
                        }

                        //draw sides
                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (!cell.HasFlag(CellTypes.West))
                        {
                            Console.SetCursorPosition((left + x) * stroke + 0, (top + y) * stroke + 1);
                            Console.Write('|');
                        }
                        if (!cell.HasFlag(CellTypes.North))
                        {
                            Console.SetCursorPosition((left + x) * stroke + 1, (top + y) * stroke + 0);
                            Console.Write('-');
                        }
                        if (!cell.HasFlag(CellTypes.East))
                        {
                            Console.SetCursorPosition((left + x) * stroke + 2, (top + y) * stroke + 1);
                            Console.Write('|');
                        }
                        if (!cell.HasFlag(CellTypes.South))
                        {
                            Console.SetCursorPosition((left + x) * stroke + 1, (top + y) * stroke + 2);
                            Console.Write('-');
                        }
                    }
                }
               // Console.ReadKey();
            }
            draw();
            //Console.Read();
        }
    }
}
/*
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
|       |   |                         |         | |         |
+-+-+-+ + + + +-+ +-+-+-+-+-+-+-+-+-+ +-+-+-+ + + + + +-+-+ +
|   |   | |   |   |     |     |     |       | |   | |   | | |
+-+ + +-+-+-+-+ +-+ +-+-+ + +-+ + +-+-+-+-+ + +-+-+ +-+ + + +
|   | |       | |   |   | | |   |       |   |   |     | | | |
+ +-+ + +-+-+ + + + + + + + + +-+-+-+-+ + +-+-+ + +-+-+ + + +
| |   | | |   | | | | |   |     |   |   |     |   |   | | | |
+ + +-+ + + +-+ + + + +-+-+-+-+ + +-+ +-+-+-+ +-+-+ + + + + +
|   |   |   |   | |     |   |     |       | |       | | |   |
+ +-+ +-+ +-+ +-+-+-+-+-+ + +-+-+ + +-+ + + +-+-+-+-+ + + +-+
| |   | | |             | |     | | |   |   |   |     | |   |
+ +-+ + + +-+-+-+-+-+ + + +-+-+ +-+ +-+-+ +-+ + + +-+-+ +-+ +
|     | |   |   |   | |   |     |   |   | |   | | |     | | |
+-+-+-+ +-+ + + + + +-+-+-+ +-+-+ +-+ + +-+ +-+ + + +-+-+ + +
|             |   |         |         |       |     |       |
+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
*/