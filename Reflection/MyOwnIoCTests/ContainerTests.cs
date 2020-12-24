// <copyright file="ContainerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyOwnIoCTests
{
    using System.Reflection;
    using MyOwnIoC;
    using MyOwnIoCTests.Entities;
    using NUnit.Framework;

    /// <summary>
    /// Container tests class.
    /// </summary>
    [TestFixture]
    public class ContainerTests
    {
        private Container container;

        /// <summary>
        /// Set up data for tests.
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
        public void AddTypeT_SingleLoggerRegistration_ReturnLogger()
        {
            this.container.AddType(typeof(Logger));

            var logger = this.container.Get<Logger>();

            Assert.That(logger, Is.Not.Null);
            Assert.That(logger, Is.InstanceOf<Logger>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_SingleICustomerDALRegistration_ReturnICustomerDAL()
        {
            this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));

            var customerDAL = this.container.Get<ICustomerDal>();

            Assert.That(customerDAL, Is.Not.Null);
            Assert.That(customerDAL, Is.InstanceOf<ICustomerDal>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_ImportConstructor_ReturnCustomerBLL()
        {
            this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));
            this.container.AddType(typeof(Logger));
            this.container.AddType(typeof(CustomerBll));

            var ñustomerBLL = this.container.Get<CustomerBll>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<CustomerBll>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddTypeTandTBase_Import_ReturnCustomerBLL2()
        {
            this.container.AddType(typeof(CustomerDal), typeof(ICustomerDal));
            this.container.AddType(typeof(Logger));
            this.container.AddType(typeof(CustomerBll2));

            var ñustomerBLL = this.container.Get<CustomerBll2>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<CustomerBll2>());
            Assert.That(ñustomerBLL.CustomerDAL, Is.Not.Null);
            Assert.That(ñustomerBLL.CustomerDAL, Is.InstanceOf<ICustomerDal>());
            Assert.That(ñustomerBLL.Logger, Is.Not.Null);
            Assert.That(ñustomerBLL.Logger, Is.InstanceOf<Logger>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void GetT_NotRegistred_ThrowsError()
        {
            Assert.That(() => this.container.Get<ICustomerDal>(), Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void GetT_NoDependencies_ThrowsError()
        {
            Assert.That(() => this.container.Get<CustomerBll>(), Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void GetT_NotEnoughDependenciesForImportConstructor_ThrowsError()
        {
            this.container.AddType(typeof(Logger));
            Assert.That(() => this.container.Get<CustomerBll>(), Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void GetT_NotEnoughDependenciesForImport_ThrowsError()
        {
            this.container.AddType(typeof(Logger));
            Assert.That(() => this.container.Get<CustomerBll2>(), Throws.Exception);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_ImportConstructor_ReturnCustomerBLL()
        {
            this.container.AddAssembly(Assembly.GetExecutingAssembly());

            var ñustomerBLL = this.container.Get<CustomerBll>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<CustomerBll>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_Import_ReturnCustomerBLL2()
        {
            this.container.AddAssembly(Assembly.GetExecutingAssembly());

            var ñustomerBLL = this.container.Get<CustomerBll2>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<CustomerBll2>());
            Assert.That(ñustomerBLL.CustomerDAL, Is.Not.Null);
            Assert.That(ñustomerBLL.CustomerDAL, Is.InstanceOf<ICustomerDal>());
            Assert.That(ñustomerBLL.Logger, Is.Not.Null);
            Assert.That(ñustomerBLL.Logger, Is.InstanceOf<Logger>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_GetLogger_ReturnLogger()
        {
            this.container.AddAssembly(Assembly.GetExecutingAssembly());

            var ñustomerBLL = this.container.Get<Logger>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<Logger>());
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void AddAssembly_GetICustomerDAL_ReturnICustomerDAL()
        {
            this.container.AddAssembly(Assembly.GetExecutingAssembly());

            var ñustomerBLL = this.container.Get<ICustomerDal>();

            Assert.That(ñustomerBLL, Is.Not.Null);
            Assert.That(ñustomerBLL, Is.InstanceOf<ICustomerDal>());
        }
    }
}
