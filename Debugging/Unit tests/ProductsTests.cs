// <copyright file="ProductsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using ProductTemplate;

    /// <summary>
    /// Unit tests class.
    /// </summary>
    [TestFixture]
    public class ProductsTests
    {
        /// <summary>
        /// Test method Sort.
        /// </summary>
        [Test]
        public void Sort_WhenDataIsValid_ShouldAscendingSorted()
        {
            // Arrange
            var numbers = new[] { 4, 2, 1, 3, -5 };

            // Act
            Utilities.Sort(numbers);

            CollectionAssert.AreEqual(new[] { -5, 1, 2, 3, 4 }, numbers);
        }

        /// <summary>
        /// Test method Sort.
        /// </summary>
        [Test]
        public void Sort_WhenParameterIsNull_ShouldThrowsArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => Utilities.Sort(null), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test method Sort.
        /// </summary>
        [Test]
        public void Sort_WhenEmptyArray_ShouldReturnsEmptyArray()
        {
            // Arrange
            var numbers = Array.Empty<int>();

            // Act
            Utilities.Sort(numbers);

            // Assert
            CollectionAssert.AreEqual(Array.Empty<int>(), numbers);
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        public void IndexOf_WhenDataIsValid_ShouldReturnsProduct()
        {
            // Arrange
            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = new Product("Product 3", 30.0d);

            // Act
            var index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            // Assert
            Assert.That(index, Is.EqualTo(2));
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        public void IndexOf_WhenNoMatch_ShouldReturnMinusOne()
        {
            // Arrange
            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = new Product("Product 4", 30.0d);

            // Act
            var index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            // Assert
            Assert.That(index, Is.EqualTo(-1));
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        public void IndexOf_WhenEqualsWithNull_ShouldReturnMinusOne()
        {
            // Arrange
            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };

            // Act
            var index = Utilities.IndexOf(products, product => product.Equals(null));

            // Assert
            Assert.That(index, Is.EqualTo(-1));
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        public void IndexOf_WhenProductHasIncorrectType_ShouldReturnsMinusOne()
        {
            // Arrange
            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = 42;

            // Act
            var index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            // Assert
            Assert.That(index, Is.EqualTo(-1));
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "It's a normal test validation")]
        public void IndexOf_WhenProductsIsNull_ShouldThrowsArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(
                () =>
            {
                var productToFind = new Product("Product 3", 30.0d);
                var index = Utilities.IndexOf(null, product => product.Equals(productToFind));
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "It's a normal test validation")]
        public void IndexOf_WhenPredicateIsNull_ShouldThrowsArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(
                () =>
            {
                var products = new Product[] { new Product("Product 1", 10.0d) };
                var index = Utilities.IndexOf(products, null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test method IndexOf.
        /// </summary>
        [Test]
        public void IndexOf_WhenArrayIsEmpty_ShouldReturnsMinusOne()
        {
            // Arrange
            var products = Array.Empty<Product>();
            var productToFind = new Product("Product 3", 30.0d);

            // Act
            var index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            // Assert
            Assert.That(index, Is.EqualTo(-1));
        }
    }
}