// <copyright file="CustomerBll3.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests.Entities
{
    using System.Diagnostics.CodeAnalysis;
    using MyOwnIoC.DoNotChange;

    /// <summary>
    /// Test entity customer business logic.
    /// </summary>
    [ImportConstructor]
    public class CustomerBll3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBll3"/> class.
        /// </summary>
        /// <param name="dal">DAL interface.</param>
        /// <param name="logger">Logger class.</param>
        [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "This parameters using for tests")]
        public CustomerBll3(ICustomerDal2 dal, Logger logger)
        {
        }
    }
}
