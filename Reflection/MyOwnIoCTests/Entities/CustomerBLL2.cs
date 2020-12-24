// <copyright file="CustomerBll2.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests.Entities
{
    using MyOwnIoC.DoNotChange;

    /// <summary>
    /// Customer business logic implementation for tests.
    /// </summary>
    public class CustomerBll2
    {
        /// <summary>
        /// Gets or sets customer DAL interface.
        /// </summary>
        [Import]
        public ICustomerDal CustomerDAL { get; set; }

        /// <summary>
        /// Gets or sets logger class.
        /// </summary>
        [Import]
        public Logger Logger { get; set; }
    }
}
