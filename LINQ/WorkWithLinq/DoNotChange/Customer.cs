// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq.DoNotChange
{
    /// <summary>
    /// Customer model.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets customer identificator.
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets customer address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets customer city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets customer region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets customer postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets customer country name.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets customer phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets customer fax number.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets customer orders.
        /// </summary>
        public Order[] Orders { get; set; }
    }
}
