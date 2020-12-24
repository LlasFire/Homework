// <copyright file="Container.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoC
{
    using System;
    using System.Reflection;

    /// <summary>
    /// My own IoC.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Method for adding assembly.
        /// </summary>
        /// <param name="assembly">Input assembly.</param>
        public void AddAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for adding type.
        /// </summary>
        /// <param name="type">Input type.</param>
        public void AddType(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for adding type based on parent type.
        /// </summary>
        /// <param name="type">Input type.</param>
        /// <param name="baseType">Input base type.</param>
        public void AddType(Type type, Type baseType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get implementation of dependency.
        /// </summary>
        /// <typeparam name="T">Type of interface.</typeparam>
        /// <returns>Type of implementation.</returns>
        public T Get<T>()
        {
            throw new NotImplementedException();
        }
    }
}