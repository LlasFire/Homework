// <copyright file="CustomerBll.cs" company="PlaceholderCompany">
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
    public class CustomerBll
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBll"/> class.
        /// </summary>
        /// <param name="dal">DAL interface.</param>
        /// <param name="logger">Logger class.</param>
        [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "This parameters using for tests")]
        public CustomerBll(ICustomerDal dal, Logger logger)
        {
        }
    }
}
