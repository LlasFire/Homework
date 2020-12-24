// <copyright file="CustomerDal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests.Entities
{
    using MyOwnIoC.DoNotChange;

    /// <summary>
    /// Test entity customer data access layer logic.
    /// </summary>
    [Export(typeof(ICustomerDal))]
    public class CustomerDal : ICustomerDal
    {
    }
}
