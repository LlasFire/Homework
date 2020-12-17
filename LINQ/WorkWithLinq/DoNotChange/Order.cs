// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq.DoNotChange
{
    using System;

    /// <summary>
    /// Order model.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets order identity.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets order date.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets total sum.
        /// </summary>
        public decimal Total { get; set; }
    }
}
