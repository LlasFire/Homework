// <copyright file="SelectExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkWithLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using WorkWithLinq.DoNotChange;

    /// <summary>
    /// Static class for work with select specific collection.
    /// </summary>
    public static class SelectExtensions
    {
        /// <summary>
        /// First task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <param name="limit">Limit of orders.</param>
        /// <returns>List of customers whose total turnover exceeds some limit.</returns>
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit).ToList();
        }

        /// <summary>
        /// Second task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <param name="suppliers">List of suppliers.</param>
        /// <returns>A list of customers and a list of suppliers located in the same country and city as the customer.</returns>
        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            if (suppliers is null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }

            var resultSet = new List<(Customer customer, IEnumerable<Supplier> suppliers)>();

            foreach (var customer in customers)
            {
                var resultSuppliers = suppliers.Where(s => s.Country == customer.Country && s.City == customer.City).ToList();
                resultSet.Add((customer, resultSuppliers));
            }

            return resultSet;
        }

        /// <summary>
        /// Second task method (+ using Linq GroupMethod).
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <param name="suppliers">List of suppliers.</param>
        /// <returns>A list of customers and a list of suppliers located in the same country and city as the customer.</returns>
        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            if (suppliers is null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }

            return (from cust in customers
                    join sup in suppliers on new { cust.City, cust.Country }
                                          equals new { sup.City, sup.Country } into leftSup
                    from sup in leftSup.DefaultIfEmpty()
                    group (cust, sup) by cust into gr
                    select (gr.Key, (IEnumerable<Supplier>)gr.Select(item => item.sup).ToList()))
                   .ToList();
        }

        /// <summary>
        /// Third task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <param name="limit">Limit of orders.</param>
        /// <returns>A list of customers who have had orders that exceed limit in total.</returns>
        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(cust => cust.Orders.Any(order => order.Total > limit)).ToList();
        }

        /// <summary>
        /// Fourth task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <returns>A list of clients with an indication of the date on which they became clients.</returns>
        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return (from cust in customers
                    where cust.Orders.Any()
                    select (cust, cust.Orders.First().OrderDate))
                   .ToList();
        }

        /// <summary>
        /// Fifth task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <returns>A list of clients with an indication of the date on which they became clients
        /// sorted by year, month, total orders and name.</returns>
        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return (from cust in customers
                    where cust.Orders.Any()
                    orderby cust.Orders.FirstOrDefault()?.OrderDate.Year,
                            cust.Orders.FirstOrDefault()?.OrderDate.Month,
                            cust.Orders.Sum(o => o.Total) descending,
                            cust.CompanyName
                    select (cust, cust.Orders.First().OrderDate))
                   .ToList();
        }

        /// <summary>
        /// Sixth task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <returns>A selected list of clients where postal code is not digital
        /// or empty region or phone number does not contains operator code.</returns>
        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            // That format when string contains only numbers
            var numberFormatExpression = new Regex(@"^[0-9]+$");

            // That format when string contains () symbols with numbers between them
            var phoneCodeFormatExpression = new Regex(@"\(\s*\d+\s*\)");

            return customers.Where(cust => !numberFormatExpression.IsMatch(cust.PostalCode.Trim()) ||
                                           string.IsNullOrEmpty(cust.Region) ||
                                           !phoneCodeFormatExpression.IsMatch(cust.Phone))
                            .ToList();
        }

        /// <summary>
        /// Seventh task method.
        /// </summary>
        /// <param name="products">List of products.</param>
        /// <returns>Grouped list of products.</returns>
        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return (from prod in products
                        group prod by prod.Category into category
                        select new Linq7CategoryGroup
                        {
                            Category = category.Key,
                            UnitsInStockGroup = (from exist in (IEnumerable<Product>)category.Select(cat => cat).ToList()
                                                 group exist by exist.UnitsInStock into stock
                                                 select new Linq7UnitsInStockGroup
                                                 {
                                                     UnitsInStock = stock.Key,
                                                     Prices = stock.Select(s => s.UnitPrice)
                                                                   .OrderBy(price => price)
                                                                   .ToList(),
                                                 })
                                                .ToList(),
                        }).ToList();
        }

        /// <summary>
        /// Eighth task method.
        /// </summary>
        /// <param name="products">List of products.</param>
        /// <param name="cheap">Cheap category price.</param>
        /// <param name="middle">Middle category price.</param>
        /// <param name="expensive">Expensive category price.</param>
        /// <returns>A list of product grouped by category price.</returns>
        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var categories = new List<decimal> { cheap, middle, expensive };

            return from prod in products
                       group prod by categories.First(cat => prod.UnitPrice <= cat) into output
                       select (output.Key, (IEnumerable<Product>)output.Select(product => product).ToList());
        }

        /// <summary>
        /// Ninth task method.
        /// </summary>
        /// <param name="customers">List of customers.</param>
        /// <returns>The list of average income and average intensity every cities.</returns>
        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return (from cust in customers
                    group cust by cust.City into result
                    select (result.Key,
                            (int)Math.Round(result.SelectMany(customer => customer.Orders).Average(order => order.Total), MidpointRounding.ToEven),
                            (int)Math.Round(result.Select(customer => customer.Orders).Average(orders => orders.Length), MidpointRounding.ToEven)))
                    .ToList();
        }

        /// <summary>
        /// Tenth task method.
        /// </summary>
        /// <param name="suppliers">List of suppliers.</param>
        /// <returns>Csv string unique sorted supplier city names.</returns>
        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            return string.Join(string.Empty, suppliers.Select(sup => sup.Country)
                                                      .Distinct()
                                                      .OrderBy(country => country.Length)
                                                      .ThenBy(country => country)
                                                      .ToList());
        }
    }
}