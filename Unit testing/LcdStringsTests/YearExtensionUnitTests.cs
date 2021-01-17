// <copyright file="YearExtensionUnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KatasTests
{
    using System;
    using FluentAssertions;
    using Katas;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains all Year Extension unit tests.
    /// </summary>
    public class YearExtensionUnitTests
    {
        /// <summary>
        /// Test with valid years.
        /// </summary>
        /// <param name="year">TestCase year int.</param>
        /// <returns>Is year leap or not.</returns>
        [TestCase(0, ExpectedResult = false)]
        [TestCase(4, ExpectedResult = true)]
        [TestCase(900, ExpectedResult = false)]
        [TestCase(1988, ExpectedResult = true)]
        [TestCase(1994, ExpectedResult = false)]
        [TestCase(2020, ExpectedResult = true)]
        public bool IsLeap_ValidYear_ReturnsTrueOrFalse(int year)
        {
            return YearExtension.IsLeap(year);
        }

        /// <summary>
        /// Test case when year less than zero.
        /// </summary>
        [Test]
        public void IsLeap_WhenYearBC_ShouldThrowException()
        {
            // Arrange
            var randomizer = new Random();
            var year = randomizer.Next(int.MinValue, default);

            // Act
            Action action = () => YearExtension.IsLeap(year);

            // Assert
            action.Should()
                  .Throw<ArgumentException>()
                  .WithMessage("We started our chronology from the year 0.");
        }
    }
}
