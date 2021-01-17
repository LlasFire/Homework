// <copyright file="LcdTranslator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Katas
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <inheritdoc/>
    public class LcdTranslator : ILcdTranslator
    {
        private readonly List<byte> numberList = new List<byte>();

        // Numbers in names are needed for more beautiful formatting of LCD strings
        // (look at TranslateNumberToLcdString method)
        private readonly StringBuilder line1 = new StringBuilder();

        private readonly StringBuilder line2 = new StringBuilder();

        private readonly StringBuilder line3 = new StringBuilder();

        /// <inheritdoc/>
        public string Translate(int value)
        {
            this.GetNumericValue(value);

            for (var i = 0; i < this.numberList.Count; i++)
            {
                this.TranslateNumberToLcdString(this.numberList[i]);

                // If it's not the last element
                if (i < this.numberList.Count - 1)
                {
                    this.AddSpaceLcdValue();
                }
            }

            return this.GetResultString();
        }

        private void GetNumericValue(long value)
        {
            if (value < default(long))
            {
                value = Math.Abs(value);
                this.AddMinusLcdValue();
            }

            if (value == default)
            {
                this.numberList.Add(default);
                return;
            }

            while (value != 0)
            {
                this.numberList.Add((byte)(value % 10L));
                value /= 10;
            }

            this.numberList.Reverse();
        }

        private string GetResultString()
        {
            var mainBuilder = new StringBuilder();
            mainBuilder.AppendLine(this.line1.ToString());
            mainBuilder.AppendLine(this.line2.ToString());
            mainBuilder.AppendLine(this.line3.ToString());

            this.line1.Clear();
            this.line2.Clear();
            this.line3.Clear();
            this.numberList.Clear();

            var output = mainBuilder.ToString();
            return output;
        }

        private void TranslateNumberToLcdString(long number)
        {
            switch (number)
            {
                case 0:
                    this.line1.Append("._.");
                    this.line2.Append("|.|");
                    this.line3.Append("|_|");
                    break;
                case 1:
                    this.line1.Append("...");
                    this.line2.Append("..|");
                    this.line3.Append("..|");
                    break;
                case 2:
                    this.line1.Append("._.");
                    this.line2.Append("._|");
                    this.line3.Append("|_.");
                    break;
                case 3:
                    this.line1.Append("._.");
                    this.line2.Append("._|");
                    this.line3.Append("._|");
                    break;
                case 4:
                    this.line1.Append("...");
                    this.line2.Append("|_|");
                    this.line3.Append("..|");
                    break;
                case 5:
                    this.line1.Append("._.");
                    this.line2.Append("|_.");
                    this.line3.Append("._|");
                    break;
                case 6:
                    this.line1.Append("._.");
                    this.line2.Append("|_.");
                    this.line3.Append("|_|");
                    break;
                case 7:
                    this.line1.Append("._.");
                    this.line2.Append("..|");
                    this.line3.Append("..|");
                    break;
                case 8:
                    this.line1.Append("._.");
                    this.line2.Append("|_|");
                    this.line3.Append("|_|");
                    break;
                case 9:
                    this.line1.Append("._.");
                    this.line2.Append("|_|");
                    this.line3.Append("._|");
                    break;
                default:
                    break;
            }
        }

        private void AddSpaceLcdValue()
        {
            this.line1.Append(string.Empty);
            this.line2.Append(string.Empty);
            this.line3.Append(string.Empty);
        }

        private void AddMinusLcdValue()
        {
            this.line1.Append("...");
            this.line2.Append("._.");
            this.line3.Append("...");
        }
    }
}
