// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProductTemplate
{
    using System;

    /// <summary>
    /// Product class.
    /// </summary>
    public sealed class Product : IEquatable<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="price">Price of product.</param>
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets name of product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price of product.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Override equals method.
        /// </summary>
        /// <param name="obj">Input object.</param>
        /// <returns>True/false.</returns>
        public override bool Equals(object obj)
        {
            // STEP 1: Check for null
            if (obj == null)
            {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Product)obj);
        }

        /// <summary>
        /// Additional equals method.
        /// </summary>
        /// <param name="other"> Input object.</param>
        /// <returns>True/false.</returns>
        public bool Equals(Product other)
        {
            // STEP 1: Check for null if nullable (e.g., a reference type)
            if (other == null)
            {
                return false;
            }

            // STEP 2: Check for ReferenceEquals if this is a reference type
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // STEP 4: Possibly check for equivalent hash codes
            if (this.GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            // STEP 5: Compare identifying fields for equality.
            return this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) && this.Price.Equals(other.Price);
        }

        /// <summary>
        /// Overrides GetHashCode method.
        /// </summary>
        /// <returns> Hash value.</returns>
        public override int GetHashCode()
        {
            var additionalVariale = 375;
            return this.Price.GetHashCode() + this.Name.GetHashCode(StringComparison.OrdinalIgnoreCase) + additionalVariale.GetHashCode();
        }
    }
}
