// <copyright file="CustomEnumerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// My custom Enumerator.
    /// </summary>
    /// <typeparam name="T">Every type in C#.</typeparam>
    internal class CustomEnumerator<T> : IEnumerator<T>
    {
        private readonly DoublyLinkedList<T> list;
        private readonly Node<T> root;
        private bool disposedValue;
        private int iterator = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEnumerator{T}"/> class.
        /// </summary>
        /// <param name="list">Implemented list.</param>
        /// <param name="root">The root node of list.</param>
        public CustomEnumerator(DoublyLinkedList<T> list, Node<T> root)
        {
            this.list = list;
            this.root = root;
        }

        /// <inheritdoc/>
        public T Current
        {
            get
            {
                var currentNode = this.root;
                var startIndex = default(int);

                while (this.iterator != startIndex)
                {
                    currentNode = currentNode.NextNode;
                    startIndex++;
                }

                return currentNode.Data;
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            this.iterator++;
            return this.iterator < this.list.Length;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Redefinition of Dispose method.
        /// </summary>
        /// <param name="disposing">Disposing flag.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                this.disposedValue = true;
            }
        }
    }
}
