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
            var name = string.Empty;

            // Test if input arguments were supplied.
            if (!args.Any() || args == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter your name and press the Enter button.");

                while (string.IsNullOrEmpty(name))
                {
                    name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("You should enter your name!");
                    }
                }

                Console.WriteLine($"Hello, {name}!");
                Console.ReadKey();
                return;
            }

            name = string.Join(" ", args);
            Console.WriteLine($"Hello, {name}!");
            Console.ReadKey();
        }
    }
}
