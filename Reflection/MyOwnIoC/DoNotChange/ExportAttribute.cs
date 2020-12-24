// <copyright file="ExportAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoC.DoNotChange
{
    using System;

    /// <summary>
    /// Export attribute for class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportAttribute"/> class.
        /// </summary>
        public ExportAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportAttribute"/> class.
        /// </summary>
        /// <param name="contract">Type of contract.</param>
        public ExportAttribute(Type contract)
        {
            this.Contract = contract;
        }

        /// <summary>
        /// Gets contract for Io container.
        /// </summary>
        public Type Contract { get; }
    }
}
