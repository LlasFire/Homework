// <copyright file="NumberParserTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParserTests
{
    using System;
    using NUnit.Framework;
    using Parser;

    /// <summary>
    /// tests for parser methods.
    /// </summary>
    public class NumberParserTests
    {
        private readonly INumberParser parser = new NumberParser();

        /// <summary>
        /// Test by valid values.
        /// </summary>
        /// <param name="stringValue">TestCase string.</param>
        /// <returns>Int value.</returns>
        [TestCase("0", ExpectedResult = 0)]
        [TestCase("+0", ExpectedResult = 0)]
        [TestCase("-0", ExpectedResult = 0)]
        [TestCase("+13230", ExpectedResult = 13230)]
        [TestCase("163042", ExpectedResult = 163042)]
        [TestCase("-10", ExpectedResult = -10)]
        [TestCase("007", ExpectedResult = 7)]
        [TestCase("+007", ExpectedResult = 7)]
        [TestCase("-007", ExpectedResult = -7)]
        [TestCase("-2147483648", ExpectedResult = int.MinValue)]
        [TestCase("2147483647", ExpectedResult = int.MaxValue)]
        [TestCase("-12034", ExpectedResult = -12034)]
        [TestCase("-12034    ", ExpectedResult = -12034)]
        public int Parse_ValidNumberString_ReturnsInt32Value(string stringValue)
        {
            return this.parser.Parse(stringValue);
        }

        /// <summary>
        /// Test by null value.
        /// </summary>
        [Test]
        public void Parse_Null_ThrowArgumentNullException()
        {
            string stringValue = null;

            Assert.That(() => this.parser.Parse(stringValue), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Test by incorrect format values.
        /// </summary>
        /// <param name="stringValue">TestCase string.</param>
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("1,390,146")]
        [TestCase("$190,235,421,127")]
        [TestCase("0xFA1B")]
        [TestCase("0xFA1B")]
        [TestCase("16e07")]
        [TestCase("134985.0")]
        [TestCase("-+12034")]
        [TestCase("+-12034")]
        [TestCase("0-12034")]
        public void Parse_InvalidNumberFormat_ThrowFormatException(string stringValue)
        {
            Assert.That(() => this.parser.Parse(stringValue), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        /// Test by large input values.
        /// </summary>
        /// <param name="stringValue">TestCase string.</param>
        [TestCase("2147483648")]
        [TestCase("-2147483649")]
        [TestCase("9999999999999999")]
        [TestCase("-9999999999999999")]
        public void Parse_NumberOutOfInt32Range_ThrowFormatException(string stringValue)
        {
            Assert.That(() => this.parser.Parse(stringValue), Throws.InstanceOf<OverflowException>());
        }
    }
}
