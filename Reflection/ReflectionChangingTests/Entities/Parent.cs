// <copyright file="Parent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReflectionChangingTests.Entities
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Parent test class.
    /// </summary>
    internal class Parent
    {
        /// <summary>
        /// Public readonly test field.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "It's test field")]
        public readonly string Filed = "123";

        /// <summary>
        /// Gets public test property.
        /// </summary>
        public int Property { get; } = 1;
    }
}
