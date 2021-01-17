// <copyright file="IBookseller.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Katas
{
    using System.Collections.Generic;
    using Katas.Models;

    /// <summary>
    /// Interface for work with book shops.
    /// </summary>
    public interface IBookseller
    {
        /// <summary>
        /// Get total sum with discount for buying some books.
        /// </summary>
        /// <param name="bookList">Lisst of books in basket.</param>
        /// <returns>Total sum value.</returns>
        public decimal TotalSumWithDiscount(List<HarryPotterBook> bookList);
    }
}
