// <copyright file="ILcdTranslator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Katas
{
    /// <summary>
    /// Interface that contains methods for translate numbers in LCD strings.
    /// </summary>
    public interface ILcdTranslator
    {
        /// <summary>
        /// Translate number in string.
        /// </summary>
        /// <param name="value">Value for translating.</param>
        /// <returns>LCD output string.</returns>
        string Translate(int value);
    }
}
