// <copyright file="Linq7CategoryGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq.DoNotChange
{
    using System.Collections.Generic;

    /// <summary>
    /// Category group model.
    /// </summary>
    public class Linq7CategoryGroup
    {
        /// <summary>
        /// Gets or sets category name.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets list of Units in stock group.
        /// </summary>
        public IEnumerable<Linq7UnitsInStockGroup> UnitsInStockGroup { get; set; }
    }
}
