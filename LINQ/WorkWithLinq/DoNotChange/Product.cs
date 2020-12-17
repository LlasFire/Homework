// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq.DoNotChange
{
    /// <summary>
    /// Product model.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets product identity.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets cathegory.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets number of units in stocs.
        /// </summary>
        public int UnitsInStock { get; set; }
    }
}
