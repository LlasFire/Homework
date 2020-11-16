using System;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameIndex = 0;

            // Test if input arguments were supplied.
            if (!args.Any())
            {
                Console.WriteLine("You didn't enter your name.");
                Console.WriteLine("«Hello, unknown user!»");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"«Hello, {args[nameIndex]}!»");
            Console.ReadKey();
            return;
        }
    }
}
