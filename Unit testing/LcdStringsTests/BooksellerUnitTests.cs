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
        public void TotalSumWithDiscount_ValidList_TotalSumShouldBeCorrect(List<HarryPotterBook> value, decimal expectedSum)
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
                16M,
            };

            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.PrisonerOfAzkaban,
                    HarryPotterBook.GobletOfFire,
                    HarryPotterBook.OrderOfThePhoenix,
                    HarryPotterBook.HalfBloodPrince,
                    HarryPotterBook.DeathlyHallows,
                },
                42M,
            };

            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.PrisonerOfAzkaban,
                    HarryPotterBook.PrisonerOfAzkaban,
                    HarryPotterBook.GobletOfFire,
                    HarryPotterBook.OrderOfThePhoenix,
                },
                51.6M,
            };

            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.PrisonerOfAzkaban,
                    HarryPotterBook.GobletOfFire,
                    HarryPotterBook.OrderOfThePhoenix,
                    HarryPotterBook.HalfBloodPrince,
                    HarryPotterBook.DeathlyHallows,
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.PrisonerOfAzkaban,
                    HarryPotterBook.GobletOfFire,
                    HarryPotterBook.OrderOfThePhoenix,
                    HarryPotterBook.HalfBloodPrince,
                    HarryPotterBook.DeathlyHallows,
                },
                84M,
            };

            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                },
                56M,
            };

            yield return new object[]
            {
                new List<HarryPotterBook>
                {
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.PhilosophersStone,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                    HarryPotterBook.ChamberOfSecrets,
                },
                38.4M,
            };
        }
    }
}
