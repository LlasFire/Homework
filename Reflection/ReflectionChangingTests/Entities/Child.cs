// <copyright file="Child.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReflectionChangingTests.Entities
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Child test class.
    /// </summary>
    internal class Child : Parent
    {
        /// <summary>
        /// Public readonly test field.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "It's test field")]
        public readonly string ChildField = "321";

        /// <summary>
        /// Gets public test property.
        /// </summary>
        public int ChildProperty { get; } = 3;
    }
}
