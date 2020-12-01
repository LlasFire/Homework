// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleOutput
{
    using System;
    using System.IO;
    using System.Linq;
    using Logic;

    /// <summary>
    /// The main class of application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        public static void Main(string[] args)
        {
            args = args == null || !args.Any() || args.Length < 2 ? new string[2] : args;

            try
            {
                var visitor = new FileSystemVisitor
                {
                    FilterPattern = args[1],
                    SourcePath = args[0],
                };
                var output = string.Join("\r\n", visitor.Search());

                Console.WriteLine($"{output}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
