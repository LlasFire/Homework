// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework
{
    using System;
    using System.Linq;

    /// <summary>
    /// The main class of programm.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main program method.
        /// </summary>
        /// <param name="args">The list of arguments.</param>
        public static void Main(string[] args)
        {
            var nameIndex = 0;

            // Test if input arguments were supplied.
            if (!args.Any() || args == null)
            {
                var output = $" You didn't enter your name.{Environment.NewLine} Hello, unknown user!";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(output);
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Hello, {args[nameIndex]}!");
            Console.ReadKey();
        }
    }
}
