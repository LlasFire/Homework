// <copyright file="Bookseller.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Katas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Katas.Models;

    /// <inheritdoc/>
    public class Bookseller : IBookseller
    {
        /// <summary>
        /// Price of one book.
        /// </summary>
        public const decimal BookCost = 8;

        /// <summary>
        /// Discount for purchase 2 different books.
        /// </summary>
        public const decimal Discount5 = 0.05M;

        /// <summary>
        /// Discount for purchase 3 different books.
        /// </summary>
        public const decimal Discount10 = 0.1M;

        /// <summary>
        /// Discount for purchase 4 different books.
        /// </summary>
        public const decimal Discount20 = 0.2M;

        /// <summary>
        /// Discount for purchase 5 and more different books.
        /// </summary>
        public const decimal Discount25 = 0.25M;

        /// <inheritdoc/>
        public decimal TotalSumWithDiscount(List<HarryPotterBook> bookList)
        {
            if (bookList is null)
            {
                throw new ArgumentNullException(nameof(bookList));
            }

            var discountList = GetListUniqueSetsOfBook(bookList);

            var totalsum = default(decimal);
            foreach (var bookcount in discountList)
            {
                var groupCost = bookcount * BookCost;

                switch (bookcount)
                {
                    case 2:
                        groupCost -= groupCost * Discount5;
                        break;
                    case 3:
                        groupCost -= groupCost * Discount10;
                        break;
                    case 4:
                        groupCost -= groupCost * Discount20;
                        break;
                    case 5:
                    case 6:
                    case 7:
                        groupCost -= groupCost * Discount25;
                        break;
                    default:
                        break;
                }

                totalsum += groupCost;
            }

            return totalsum;
        }

        private static List<int> GetListUniqueSetsOfBook(List<HarryPotterBook> bookList)
        {
            var uniqueSetList = new List<List<HarryPotterBook>>();
            while (bookList.Any())
            {
                var setList = bookList.GroupBy(item => item)
                                      .Select(item => item.Key)
                                      .ToList();

                foreach (var item in setList)
                {
                    bookList.Remove(item);
                }

                uniqueSetList.Add(setList);
            }

            return uniqueSetList.Select(item => item.Count)
                                .ToList();
        }
    }
}
