// <copyright file="ImportConstructorAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoC.DoNotChange
{
    using System;

    /// <summary>
    /// Import attribute for constructor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ImportConstructorAttribute : Attribute
    {
    }
}
