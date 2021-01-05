// <copyright file="IDoublyLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures.DoNotChange
{
    using System.Collections.Generic;

    /// <summary>
    /// My own LinkedList.
    /// </summary>
    /// <typeparam name="T">All type of classes or structures.</typeparam>
    public interface IDoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets number of length of list.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Add item in the list.
        /// </summary>
        /// <param name="item">Adding item.</param>
        void Add(T item);

        /// <summary>
        /// Method for inserting an element in at a specific index.
        /// </summary>
        /// <param name="index">Index for inserting an element.</param>
        /// <param name="e">The element for inserting.</param>
        void AddAt(int index, T e);

        /// <summary>
        /// Remove item from list.
        /// </summary>
        /// <param name="item">Removing item.</param>
        void Remove(T item);

        /// <summary>
        /// Method for removing item by index.
        /// </summary>
        /// <param name="index">Index for removing.</param>
        /// <returns>Element for removing.</returns>
        T RemoveAt(int index);

        /// <summary>
        /// Get element by index.
        /// </summary>
        /// <param name="index">Index for search element.</param>
        /// <returns>Item in list by index.</returns>
        T ElementAt(int index);
    }
}
