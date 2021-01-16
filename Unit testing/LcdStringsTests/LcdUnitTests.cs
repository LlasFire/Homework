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
        [TestCase(0, ExpectedResult = "._.\r\n|.|\r\n|_|\r\n")]
        [TestCase(7, ExpectedResult = "._.\r\n..|\r\n..|\r\n")]
        [TestCase(10, ExpectedResult = "...._.\r\n..||.|\r\n..||_|\r\n")]
        [TestCase(-0, ExpectedResult = "._.\r\n|.|\r\n|_|\r\n")]
        [TestCase(1750, ExpectedResult = "...._.._.._.\r\n..|..||_.|.|\r\n..|..|._||_|\r\n")]
        [TestCase(-5581, ExpectedResult = "...._.._.._....\r\n._.|_.|_.|_|..|\r\n...._|._||_|..|\r\n")]
        [TestCase(int.MinValue, ExpectedResult = "...._........_....._.._.._....._.\r\n._.._|..||_|..||_||_|._||_.|_||_|\r\n...|_...|..|..|..||_|._||_|..||_|\r\n")]
        public string Translate_ValidNumber_ReturnsLcdStringValue(int value)
        {
            return this.translator.Translate(value);
        }
    }
}
