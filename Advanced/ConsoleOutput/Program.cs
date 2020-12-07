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
            var rightNumbersOfArguments = 2;
            args = args == null || !args.Any() || args.Length < rightNumbersOfArguments
                ? new string[rightNumbersOfArguments]
                : args;

            try
            {
                var visitor = new FileSystemVisitor
                {
                    SourcePath = args[0],
                    FilterPattern = args[1],
                };

                Subscribe(visitor);

                var output = string.Join("\r\n", visitor.Search());

                Console.WriteLine(output);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void OutputVisitorMessages(string message)
        {
            Console.WriteLine(message);
        }

        private static void Subscribe(FileSystemVisitor visitor)
        {
            visitor.Start += OutputVisitorMessages;
            visitor.Finish += OutputVisitorMessages;
            visitor.DirectorysFiltered += OutputVisitorMessages;
            visitor.FilesFiltered += OutputVisitorMessages;
            visitor.DirectorysFinded += OutputVisitorMessages;
            visitor.FilesFinded += OutputVisitorMessages;
        }
    }
}
