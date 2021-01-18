// <copyright file="NumberParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Parser
{
    using System;
    using System.Text.RegularExpressions;

    /// <inheritdoc/>
    public class NumberParser : INumberParser
    {
        private const int MaxLength = 11;
        private readonly Regex correctIntFormat = new Regex(@"^(\+|-){0,1}[0-9]+$");

        /// <inheritdoc/>
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            stringValue = stringValue.Trim();

            if (!this.correctIntFormat.IsMatch(stringValue))
            {
                throw new FormatException("The input value has incorrect format");
            }

            if (stringValue.Length > MaxLength)
            {
                throw new OverflowException("The input parameter is very large.");
            }

            var charArray = stringValue.ToCharArray();
            long intermediateValue = 0;
            var level = 0;

            for (var i = charArray.Length; i > 0; i--)
            {
                long tempValue;

                // Defining a character from the end of the array.
                switch (charArray[i - 1])
                {
                    case '0':
                        tempValue = 0;
                        break;
                    case '1':
                        tempValue = 1;
                        break;
                    case '2':
                        tempValue = 2;
                        break;
                    case '3':
                        tempValue = 3;
                        break;
                    case '4':
                        tempValue = 4;
                        break;
                    case '5':
                        tempValue = 5;
                        break;
                    case '6':
                        tempValue = 6;
                        break;
                    case '7':
                        tempValue = 7;
                        break;
                    case '8':
                        tempValue = 8;
                        break;
                    case '9':
                        tempValue = 9;
                        break;
                    default:
                        continue;
                }

                intermediateValue += tempValue * (long)Math.Pow(10, level);
                level++;
            }

            // Invert numder if first symbol is -
            if (charArray[0] == '-')
            {
                intermediateValue = -intermediateValue;
            }

            if (intermediateValue > int.MaxValue || intermediateValue < int.MinValue)
            {
                throw new OverflowException("The number is very large or very small for int format.");
            }

            return (int)intermediateValue;
        }
    }
}
