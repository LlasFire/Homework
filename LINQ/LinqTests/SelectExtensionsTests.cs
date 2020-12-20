// <copyright file="SelectExtensionsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LinqTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using WorkWithLinq;
    using WorkWithLinq.DoNotChange;

    /// <summary>
    /// SelectExtensions test class.
    /// </summary>
    [TestFixture]
    public class SelectExtensionsTests
    {
        /// <summary>
        /// Linq1 method test.
        /// </summary>
        /// <param name="limit">Order sum limit.</param>
        /// <returns>NUmber of customers.</returns>
        [TestCase(6250, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 5)]
        [TestCase(-1, ExpectedResult = 6)]
        [TestCase(1, ExpectedResult = 4)]
        public int Linq1_Limit_ReturnsCustomersCount(decimal limit)
        {
            return SelectExtensions.Linq1(DataSource.Customers, limit).Count();
        }

        /// <summary>
        /// Linq1 method test when customers are null.
        /// </summary>
        [Test]
        public void Linq1_NullSource_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq1(null, 42).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq2 method test.
        /// </summary>
        [Test]
        public void Linq2_CustomersAndSuppliers_2CustomersHaveSuppliers()
        {
            var result = SelectExtensions.Linq2(DataSource.Customers, DataSource.Suppliers).ToList();

            Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count));
            foreach (var (customer, suppliers) in result)
            {
                foreach (var supplier in suppliers)
                {
                    StringAssert.AreEqualIgnoringCase(customer.City, supplier.City);
                    StringAssert.AreEqualIgnoringCase(customer.Country, supplier.Country);
                }
            }
        }

        /// <summary>
        /// Linq2 method test when customers and suppliers are null.
        /// </summary>
        [Test]
        public void Linq2_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq2(null, null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq2UsingGroup method test.
        /// </summary>
        [Test]
        public void Linq2UsingGroup_CustomersAndSuppliers_2CustomersHaveSuppliers()
        {
            var result = SelectExtensions.Linq2UsingGroup(DataSource.Customers, DataSource.Suppliers).ToList();

            Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count));
            foreach (var (customer, suppliers) in result)
            {
                if (suppliers.All(x => x is null))
                {
                    continue;
                }

                foreach (var supplier in suppliers)
                {
                    StringAssert.AreEqualIgnoringCase(customer.City, supplier.City);
                    StringAssert.AreEqualIgnoringCase(customer.Country, supplier.Country);
                }
            }
        }

        /// <summary>
        /// Linq2UsingGroup method test when customers and suppliers are null.
        /// </summary>
        [Test]
        public void Linq2UsingGroup_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq2UsingGroup(null, null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq3 method test.
        /// </summary>
        /// <param name="limit">Limit value.</param>
        /// <returns>Expected result.</returns>
        [TestCase(800, ExpectedResult = 2)]
        [TestCase(0, ExpectedResult = 5)]
        [TestCase(-1, ExpectedResult = 5)]
        [TestCase(1, ExpectedResult = 4)]
        public int Linq3_Limit_ReturnsCustomersCount(decimal limit)
        {
            return SelectExtensions.Linq3(DataSource.Customers, limit).Count();
        }

        /// <summary>
        /// Linq3 method test when customers  are null.
        /// </summary>
        [Test]
        public void Linq3_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq3(null, 42).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq4 method test.
        /// </summary>
        [Test]
        public void Linq4_Customers_CustomersAndDateOfEntry()
        {
            var result = SelectExtensions.Linq4(DataSource.Customers).ToList();

            Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count - 1));
            foreach (var (customer, dateOfEntry) in result)
            {
                Assert.That(FindCustomerOrdersMinDate(customer), Is.EqualTo(dateOfEntry));
            }
        }

        /// <summary>
        /// Linq4 method test when customers are null.
        /// </summary>
        [Test]
        public void Linq4_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq4(null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq5 method test.
        /// </summary>
        [Test]
        public void Linq5_Customers_CustomersAndDateOfEntry()
        {
            var result = SelectExtensions.Linq5(DataSource.Customers).ToList();

            Assert.That(() => result.Count, Is.EqualTo(DataSource.Customers.Count - 1));
            foreach (var (customer, dateOfEntry) in result)
            {
                Assert.That(FindCustomerOrdersMinDate(customer), Is.EqualTo(dateOfEntry));
            }

            Assert.That(result[0].customer, Is.EqualTo(DataSource.Customers[1]));
            Assert.That(result[1].customer, Is.EqualTo(DataSource.Customers[3]));
            Assert.That(result[2].customer, Is.EqualTo(DataSource.Customers[2]));
            Assert.That(result[3].customer, Is.EqualTo(DataSource.Customers[4]));
            Assert.That(result[4].customer, Is.EqualTo(DataSource.Customers[0]));
        }

        /// <summary>
        /// Linq5 method test when customers are null.
        /// </summary>
        [Test]
        public void Linq5_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq5(null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq6 method test.
        /// </summary>
        [Test]
        public void Linq6_Customers_Returns5()
        {
            Assert.That(SelectExtensions.Linq6(DataSource.Customers).Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// Linq6 method test when customers are null.
        /// </summary>
        [Test]
        public void Linq6_NullCustomer_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq6(null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq7 method test.
        /// </summary>
        [Test]
        public void Linq7_Customers_Returns5()
        {
            var expectedResult = new[]
            {
                new Linq7CategoryGroup
                {
                    Category = "Beverages",
                    UnitsInStockGroup = new[]
                    {
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 39,
                            Prices = new[] { 19.0000M },
                        },
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 17,
                            Prices = new[] { 18.0000M },
                        },
                    },
                },
                new Linq7CategoryGroup
                {
                    Category = "Condiments",
                    UnitsInStockGroup = new[]
                    {
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 15,
                            Prices = new[] { 10.0000M, 40.0000M },
                        },
                        new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = 13,
                            Prices = new[] { 30.0000M },
                        },
                    },
                },
            };

            var result = SelectExtensions.Linq7(DataSource.Products);

            foreach (var categoryGroup in result)
            {
                var expectedCategoryGroup = expectedResult.Single(_ => _.Category == categoryGroup.Category);
                foreach (var unitInStockGroup in categoryGroup.UnitsInStockGroup)
                {
                    var expectedUnitInStockGroup = expectedCategoryGroup
                        .UnitsInStockGroup.Single(_ => _.UnitsInStock == unitInStockGroup.UnitsInStock);
                    CollectionAssert.AreEqual(expectedUnitInStockGroup.Prices, unitInStockGroup.Prices);
                }
            }
        }

        /// <summary>
        /// Linq7 method test when products are null.
        /// </summary>
        [Test]
        public void Linq7_NullProducts_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq7(null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq8 method test.
        /// </summary>
        [Test]
        public void Linq8_Products_ReturnsGroupedProducts()
        {
            decimal cheap = 10, middle = 30, expensive = 40;
            var result = SelectExtensions.Linq8(DataSource.Products, cheap, middle, expensive).ToList();

            var cheapProducts = result.Single(_ => _.category == cheap).products;
            Assert.That(cheapProducts.Count(), Is.EqualTo(1));
            var middleProducts = result.Single(_ => _.category == middle).products;
            Assert.That(middleProducts.Count(), Is.EqualTo(3));
            var expensiveProducts = result.Single(_ => _.category == expensive).products;
            Assert.That(expensiveProducts.Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// Linq8 method test when products are null.
        /// </summary>
        [Test]
        public void Linq8_NullProducts_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq8(null, 42, 42, 42).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq9 method test.
        /// </summary>
        [Test]
        public void Linq9_Customers_ReturnsGroupedProducts()
        {
            var expected = new List<(string city, int averageIncome, int averageIntensity)>
            {
                ("Berlin", 674, 3),
                ("Mexico D.F.", 292, 2),
                ("London", 690, 1),
            };

            var result = SelectExtensions.Linq9(DataSource.Customers).ToList();

            foreach (var valueTuple in result)
            {
                var expectedValue = expected.Single(_ => _.city == valueTuple.city);
                Assert.That(expectedValue.averageIncome, Is.EqualTo(valueTuple.averageIncome));
                Assert.That(expectedValue.averageIntensity, Is.EqualTo(valueTuple.averageIntensity));
            }
        }

        /// <summary>
        /// Linq9 method test when customers are null.
        /// </summary>
        [Test]
        public void Linq9_NullCustomers_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq9(null).ToList(), Throws.ArgumentNullException);
        }

        /// <summary>
        /// Linq9 method test.
        /// </summary>
        [Test]
        public void Linq10_Suppliers_ReturnsAggregateString()
        {
            string result = SelectExtensions.Linq10(DataSource.Suppliers);
            StringAssert.AreEqualIgnoringCase("UKUSAJapanSpainBrazilSwedenGermanyAustralia", result);
        }

        /// <summary>
        /// Linq10 method test when suppliers are null.
        /// </summary>
        [Test]
        public void Linq10_NullSuppliers_ThrowsArgumentNullException()
        {
            Assert.That(() => SelectExtensions.Linq10(null).ToList(), Throws.ArgumentNullException);
        }

        private static DateTime FindCustomerOrdersMinDate(Customer customer)
        {
            var min = DateTime.MaxValue;
            foreach (var order in customer.Orders)
            {
                if (order.OrderDate < min)
                {
                    min = order.OrderDate;
                }
            }

            return min;
        }
    }
}
