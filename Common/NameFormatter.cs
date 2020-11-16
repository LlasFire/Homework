// <copyright file="NameFormatter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class for formatting name of user.
    /// </summary>
    public static class NameFormatter
    {
        /// <summary>
        /// Method for formatting name of user.
        /// </summary>
        /// <param name="names">List of name.</param>
        /// <returns>Formatted output string.</returns>
        public static string Format(params string[] names)
        {
            if (!names.Any() || names == null || string.IsNullOrEmpty(names.FirstOrDefault()))
            {
                return $" You didn't enter your name.{Environment.NewLine} Hello, unknown user!";
            }

            var nameIndex = 0;
            return $"Hello, {names[nameIndex]}!";
        }
    }
}
