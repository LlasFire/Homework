// <copyright file="ImportAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoC.DoNotChange
{
    using System;

    /// <summary>
    /// Import attribute for propertys and fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ImportAttribute : Attribute
    {
    }
}
