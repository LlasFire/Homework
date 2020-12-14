// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ShowFirstInputSymbol
{
    using System;
    using System.Text;

    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// End read key.
        /// </summary>
        public const string Key = "\"End\"";

        /// <summary>
        /// The start index in string for remove symbols.
        /// </summary>
        public const int StartIndex = 1;

        /// <summary>
        /// Start method.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine($"Enter the text, then type {Key} (with quotes)");
            Console.WriteLine("If you enter an empty string, the app will not output the first character of that string.");

            var input = new StringBuilder();
            var cancelFlag = false;

            while (!cancelFlag)
            {
                var source = Console.ReadLine();
                var firstSymbol = source.Length > 1 ? source.Remove(StartIndex) : source;

                if (source.Contains(Key))
                {
                    cancelFlag = true;

                    if (!source.StartsWith(Key))
                    {
                        input.AppendLine(firstSymbol);
                    }
                }
                else
                {
                    input.AppendLine(firstSymbol);
                }
            }

            Console.WriteLine("--------------- Output ---------------");
            Console.WriteLine(input.ToString());
            Console.ReadKey();
        }
    }
}
