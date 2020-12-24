// <copyright file="TestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Class for help prepare data for tests.
    /// </summary>
    internal static class TestHelper
    {
        /// <summary>
        /// Get IoC assembly for tests.
        /// </summary>
        /// <returns>Test assembly.</returns>
        public static Assembly GetIoCAssembly() => GetAssemblyByName("MyOwnIoC");

        private static Assembly GetAssemblyByName(string name)
        {
            var assemblyName = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Single(a => a.Name == name);

            return Assembly.Load(assemblyName);
        }
    }
}
