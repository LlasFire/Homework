// <copyright file="ContainerTestsComplex.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests
{
    using System.Reflection;
    using MyOwnIoC;
    using MyOwnIoCTests.Entities;
    using NUnit.Framework;

    /// <summary>
    /// Class for complex testing my this.container.
    /// </summary>
    [TestFixture]
    public class ContainerTestsComplex
    {
        private Container container;

        /// <summary>
        /// Set up data before all tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.container = new Container();
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeT_TryRegisterLoggerTwice_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddType(typeof(Logger));
                this.container.AddType(typeof(Logger));
                this.container.Get<Logger>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeT_TryRegisterInterface_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddType(typeof(ICustomerDal));
                this.container.Get<ICustomerDal>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_SingleCustomerDALRegistration_ReturnCustomerDAL()
        {
            this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));

            var customerDAL = this.container.Get<CustomerDal>();

            Assert.That(customerDAL, Is.Not.Null);
            Assert.That(customerDAL, Is.InstanceOf<CustomerDal>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_TryRegisterICustomerDALTwice_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));
                this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));
                this.container.Get<ICustomerDal>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_TryRegisterInterface_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddType(typeof(ICustomerDal), typeof(ICustomerDal));
                this.container.Get<ICustomerDal>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_AssemblyWithDependenciesTwice_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddAssembly(Assembly.GetExecutingAssembly());
                this.container.AddAssembly(Assembly.GetExecutingAssembly());
                this.container.Get<ICustomerDal>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_AssemblyWithoutDependencies_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddAssembly(TestHelper.GetIoCAssembly());
                this.container.Get<ICustomerDal>();
            }, Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_AssemblyWithNotEnoughDependencies_ThrowsError()
        {
            Assert.That(
                () =>
            {
                this.container.AddAssembly(Assembly.GetExecutingAssembly());
                this.container.Get<CustomerBll3>();
            }, Throws.Exception);
        }
    }
}
