// <copyright file="Linq7UnitsInStockGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq.DoNotChange
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of stock groups.
    /// </summary>
    public class Linq7UnitsInStockGroup
    {
        /// <summary>
        /// Gets or sets number of units in stock.
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets list of prices.
        /// </summary>
        public IEnumerable<decimal> Prices { get; set; }
    }
}
