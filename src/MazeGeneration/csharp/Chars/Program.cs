using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chars
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.ASCII;
            Console.Clear();
            for (var x = 0; x < 16; x++)
            {
                Console.Write(x);
                Console.Write('\t');

                for (var y = 0; y < 16; y++)
                {
                    //Console.Write(x * 16 + y);
                    //Console.Write('\t');
                    Console.Write((char)(x * 16 + y));
                }
                Console.WriteLine();
            }
        }
    }
}
