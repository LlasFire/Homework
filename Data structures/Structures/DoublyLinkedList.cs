// <copyright file="DoublyLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Structures.DoNotChange;

    /// <summary>
    /// Implementation of my owm DoublyLinkedList.
    /// </summary>
    /// <typeparam name="T">Every structure in C#.</typeparam>
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        /// <inheritdoc/>
        public int Length => throw new NotImplementedException();

        /// <inheritdoc/>
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void AddAt(int index, T e)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public T ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
