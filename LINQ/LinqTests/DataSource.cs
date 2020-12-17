﻿// <copyright file="DataSource.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LinqTests.Tests
{
    using System;
    using System.Collections.Generic;
    using WorkWithLinq.DoNotChange;

    /// <summary>
    /// Data source class for test methods.
    /// </summary>
    internal static class DataSource
    {
        /// <summary>
        /// List of products, prepared for testing.
        /// </summary>
        public static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                ProductID = 1,
                ProductName = "Chai",
                Category = "Beverages",
                UnitPrice = 19.0000M,
                UnitsInStock = 39,
            },
            new Product
            {
                ProductID = 2,
                ProductName = "Chang",
                Category = "Beverages",
                UnitPrice = 18.0000M,
                UnitsInStock = 17,
            },
            new Product
            {
                ProductID = 3,
                ProductName = "Aniseed Syrup",
                Category = "Condiments",
                UnitPrice = 30.0000M,
                UnitsInStock = 13,
            },
            new Product
            {
                ProductID = 7,
                ProductName = "Uncle Bob's Organic Dried Pears",
                Category = "Condiments",
                UnitPrice = 10.0000M,
                UnitsInStock = 15,
            },
            new Product
            {
                ProductID = 8,
                ProductName = "Northwoods Cranberry Sauce",
                Category = "Condiments",
                UnitPrice = 40.0000M,
                UnitsInStock = 15,
            },
        };

        /// <summary>
        /// List of suppliers, prepared for testing.
        /// </summary>
        public static readonly List<Supplier> Suppliers = new List<Supplier>
        {
            new Supplier
            {
                SupplierName = "Exotic Liquids",
                Address = "49 Gilbert St.",
                City = "London",
                Country = "UK",
            },
            new Supplier
            {
                SupplierName = "New Orleans Cajun Delights",
                Address = "P.O. Box 78934",
                City = "New Orleans",
                Country = "USA",
            },
            new Supplier
            {
                SupplierName = "Grandma Kelly's Homestead",
                Address = "707 Oxford Rd.",
                City = "Ann Arbor",
                Country = "USA",
            },
            new Supplier
            {
                SupplierName = "Tokyo Traders",
                Address = "9-8 Sekimai Musashino-shi",
                City = "Tokyo",
                Country = "Japan",
            },
            new Supplier
            {
                SupplierName = "Cooperativa de Quesos 'Las Cabras'",
                Address = "Calle del Rosal 4",
                City = "Oviedo",
                Country = "Spain",
            },
            new Supplier
            {
                SupplierName = "Mayumi's",
                Address = "92 Setsuko Chuo-ku",
                City = "Osaka",
                Country = "Japan",
            },
            new Supplier
            {
                SupplierName = "Pavlova, Ltd.",
                Address = "74 Rose St. Moonie Ponds",
                City = "Melbourne",
                Country = "Australia",
            },
            new Supplier
            {
                SupplierName = "Specialty Biscuits, Ltd.",
                Address = "29 King's Way",
                City = "Manchester",
                Country = "UK",
            },
            new Supplier
            {
                SupplierName = "PB Knäckebröd AB",
                Address = "Kaloadagatan 13",
                City = "Göteborg",
                Country = "Sweden",
            },
            new Supplier
            {
                SupplierName = "Refrescos Americanas LTDA",
                Address = "Av. das Americanas 12.890",
                City = "Sao Paulo",
                Country = "Brazil",
            },
            new Supplier
            {
                SupplierName = "Heli Süßwaren GmbH & Co. KG",
                Address = "Tiergartenstraße 5",
                City = "Berlin",
                Country = "Germany",
            },
        };

        /// <summary>
        /// List of customers, prepared for testing.
        /// </summary>
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                CustomerID = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                Address = "Obere Str. 57",
                City = "Berlin",
                PostalCode = "12209",
                Country = "Germany",
                Phone = "030-0074321",
                Fax = "030-0076545",
                Orders = new[]
                {
                    new Order
                    {
                        OrderID = 10643,
                        OrderDate = DateTime.Parse("1997-08-25T00:00:00"),
                        Total = 814.50m,
                    },
                    new Order
                    {
                        OrderID = 10692,
                        OrderDate = DateTime.Parse("1997-10-03T00:00:00"),
                        Total = 878.00m,
                    },
                    new Order
                    {
                        OrderID = 10702,
                        OrderDate = DateTime.Parse("1997-10-13T00:00:00"),
                        Total = 330m,
                    },
                },
            },
            new Customer
            {
                CustomerID = "ANATR",
                CompanyName = "Ana Trujillo Emparedados y helados",
                Address = "Avda. de la Constitución 2222",
                City = "Mexico D.F.",
                PostalCode = "05021",
                Country = "Mexico",
                Phone = "(5) 555-4729",
                Fax = "(5) 555-3745",
                Orders = new[]
                {
                    new Order
                    {
                        OrderID = 10308,
                        OrderDate = DateTime.Parse("1996-09-18T00:00:00"),
                        Total = 88.80m,
                    },
                    new Order
                    {
                        OrderID = 10625,
                        OrderDate = DateTime.Parse("1997-08-08T00:00:00"),
                        Total = 479.75m,
                    },
                    new Order
                    {
                        OrderID = 10759,
                        OrderDate = DateTime.Parse("1997-11-28T00:00:00"),
                        Total = 320m,
                    },
                },
            },
            new Customer
            {
                CustomerID = "ANTON2",
                CompanyName = "Antonio Moreno Taquería",
                Address = "Mataderos  2312",
                City = "Mexico D.F.",
                PostalCode = "05023",
                Country = "Mexico",
                Phone = "(5) 555-3932",
                Orders = new[]
                {
                    new Order
                    {
                        OrderID = 10365,
                        OrderDate = DateTime.Parse("1996-11-27T00:00:00"),
                        Total = 403.20m,
                    },
                    new Order
                    {
                        OrderID = 10507,
                        OrderDate = DateTime.Parse("1997-04-15T00:00:00"),
                        Total = 749.06m,
                    },
                },
            },
            new Customer
            {
                CustomerID = "AROUT",
                CompanyName = "Around the Horn",
                Address = "120 Hanover Sq.",
                City = "London",
                PostalCode = "WA1 1DP",
                Country = "UK",
                Phone = "555-7788",
                Fax = "(171) 555-6750",
                Orders = new[]
                {
                    new Order
                    {
                        OrderID = 10355,
                        OrderDate = DateTime.Parse("1996-11-15T00:00:00"),
                        Total = 480.00m,
                    },
                    new Order
                    {
                        OrderID = 10383,
                        OrderDate = DateTime.Parse("1996-12-16T00:00:00"),
                        Total = 899m,
                    },
                },
            },
            new Customer
            {
                CustomerID = "ANTON",
                CompanyName = "Antonio Moreno Taquería",
                Address = "Mataderos  2312",
                City = "Mexico D.F.",
                PostalCode = "05f023",
                Country = "Mexico",
                Phone = "(5) 555-3932",
                Orders = new[]
                {
                    new Order
                    {
                        OrderID = 10365,
                        OrderDate = DateTime.Parse("1996-11-27T00:00:00"),
                        Total = 0.1m,
                    },
                    new Order
                    {
                        OrderID = 10507,
                        OrderDate = DateTime.Parse("1997-04-15T00:00:00"),
                        Total = 0.3m,
                    },
                },
            },
            new Customer
            {
                CustomerID = "AROUT123",
                CompanyName = "Around the Horn",
                Address = "1220 Hanover Sq.",
                City = "London",
                PostalCode = "12374",
                Country = "UK",
                Phone = "(171) 555-7789",
                Fax = "(171) 555-6720",
                Orders = Array.Empty<Order>(),
                Region = "London",
            },
        };
    }
}