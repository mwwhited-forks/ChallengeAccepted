using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(args.Length == 0 ? "Hello, World!" : string.Join(";", args));
        }
    }
}