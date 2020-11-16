// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Homework
{
    using System;
    using Common;

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
            var output = NameFormatter.Format(args);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
