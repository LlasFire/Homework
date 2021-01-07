// <copyright file="DoublyLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Structures.DoNotChange;

    /// <summary>
    /// Implementation of my owm DoublyLinkedList.
    /// </summary>
    /// <typeparam name="T">Every structure in C#.</typeparam>
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private const int SecondIndex = 1;
        private Node<T> head;
        private Node<T> root;

        /// <inheritdoc/>
        public int Length { get; private set; }

        /// <inheritdoc/>
        public void Add(T item)
        {
            if (this.Length == default)
            {
                var newNode = new Node<T>(item, this.Length);
                this.root = newNode;
                this.head = newNode;
            }
            else if (this.Length == SecondIndex)
            {
                var newNode = new Node<T>(item, this.Length, this.root);
                this.head = newNode;
                this.root.NextNode = this.head;
            }
            else
            {
                var newNode = new Node<T>(item, this.Length, this.head);
                this.head.NextNode = newNode;
                this.head = newNode;
            }

            this.Length++;
        }

        /// <inheritdoc/>
        public void AddAt(int index, T item)
        {
            this.ValidateIndex(index, this.Length);

            if (index == this.Length)
            {
                this.Add(item);
                return;
            }

            this.head.Index++;
            var currentNode = this.head;

            while (currentNode.Index > index + 1)
            {
                currentNode = currentNode.PreviousNode;
                currentNode.Index++;
            }

            var newNode = new Node<T>(item, index, currentNode.PreviousNode, currentNode);
            currentNode.PreviousNode = newNode;
        }

        /// <inheritdoc/>
        public T ElementAt(int index)
        {
            this.ValidateIndex(index, this.Length - 1);

            Node<T> needNode;
            if (this.StartNodeIsHead(index))
            {
                needNode = this.head;

                while (needNode.Index != index)
                {
                    needNode = needNode.PreviousNode;
                }
            }
            else
            {
                needNode = this.root;

                while (needNode.Index != index)
                {
                    needNode = needNode.NextNode;
                }
            }

            return needNode.Data;
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
            this.ValidateIndex(index, this.Length - 1);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private bool StartNodeIsHead(int index)
        {
            return Math.Abs(index - this.Length) >= Math.Abs(index - default(int));
        }

        [SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "It's need for test case")]
        private void ValidateIndex(int index, int length)
        {
            if (index > length ||
                index < default(int) ||
                (this.head is null && this.root is null))
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
