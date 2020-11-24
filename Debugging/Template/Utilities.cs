// <copyright file="Utilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProductTemplate
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Practices.Unity.Utility;

    /// <summary>
    /// Utilities for product class.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Sorts an array in ascending order using bubble sort.
        /// </summary>
        /// <param name="numbers">Numbers to sort.</param>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.ArgumentNotNull throwing exception")]
        public static void Sort(int[] numbers)
        {
            Guard.ArgumentNotNull(numbers, nameof(numbers));

            var initialIndex = 0;
            for (int i = initialIndex; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        var temporaryContainer = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temporaryContainer;
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the index of a product in an <paramref name="products"/>
        /// based on a <paramref name="predicate"/>.
        /// </summary>
        /// <param name="products">Products used for searching.</param>
        /// <param name="predicate">Product predicate.</param>
        /// <returns>If match found then returns index of product in <paramref name="products"/>
        /// otherwise -1.</returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Guard.ArgumentNotNull throwing exception")]
        public static int IndexOf(Product[] products, Predicate<Product> predicate)
        {
            Guard.ArgumentNotNull(products, nameof(products));
            Guard.ArgumentNotNull(predicate, nameof(predicate));
            var wrongAnswer = -1;

            for (int i = 0; i < products.Length; i++)
            {
                var product = products[i];
                if (predicate(product))
                {
                    return i;
                }
            }

            return wrongAnswer;
        }
    }
}
