// <copyright file="BooksellerUnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KatasTests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Katas;
    using Katas.Models;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains all Bookseller unit tests.
    /// </summary>
    public class BooksellerUnitTests
    {
        private readonly IBookseller seller = new Bookseller();

        /// <summary>
        /// Test by valid values.
        /// </summary>
        /// <param name="value">TestCase string.</param>
        /// <param name="expectedSum">Expected sum for assert.</param>
        [TestCaseSource(nameof(GetTestCases))]
        public void Translate_ValidNumber_ReturnsLcdStringValue(List<HarryPotterBook> value, decimal expectedSum)
        {
            // Act
            var totalSum = this.seller.TotalSumWithDiscount(value);

            // Assert
            totalSum.Should()
                    .Be(expectedSum);
        }

        /// <summary>
        /// Arrange data for tests.
        /// </summary>
        /// <returns>List of books and expected price for assert.</returns>
        private static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                },
                15.2M,
            };
        }
    }
}
