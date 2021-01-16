// <copyright file="LcdUnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LcdStringsTests
{
    using LcdDigits;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains all LCD unit tests.
    /// </summary>
    public class LcdUnitTests
    {
        private readonly ILcdTranslator translator = new LcdTranslator();

        /// <summary>
        /// Test by valid values.
        /// </summary>
        /// <param name="value">TestCase string.</param>
        /// <returns>Int value.</returns>
        [TestCase(0, ExpectedResult = "._./r/n|.|/r/n|_|")]
        public string Translate_ValidNumber_ReturnsLcdStringValue(int value)
        {
            return this.translator.Translate(value);
        }
    }
}
