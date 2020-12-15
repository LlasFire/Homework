// <copyright file="INumberParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Parser
{
    /// <summary>
    /// Interface for number parsing class.
    /// </summary>
    public interface INumberParser
    {
        /// <summary>
        /// Parce from string to int method.
        /// </summary>
        /// <param name="stringValue">Source string.</param>
        /// <returns>int value.</returns>
        int Parse(string stringValue);
    }
}
