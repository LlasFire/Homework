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

        /// <summary>
        /// Gets the last index of list.
        /// </summary>
        public int LastIndex => this.Length - 1;

        /// <inheritdoc/>
        public void Add(T item)
        {
            if (this.Length == default)
            {
                var newNode = new Node<T>(item);
                this.root = newNode;
                this.head = newNode;
            }
            else if (this.Length == SecondIndex)
            {
                var newNode = new Node<T>(item, this.root);
                this.head = newNode;
                this.root.NextNode = this.head;
            }
            else
            {
                var newNode = new Node<T>(item, this.head);
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

            var currentNode = this.head;
            var counter = this.LastIndex;
            while (counter > index)
            {
                currentNode = currentNode.PreviousNode;
                counter--;
            }

            var newNode = new Node<T>(item, currentNode.PreviousNode, currentNode);
            currentNode.PreviousNode = newNode;
            this.Length++;
        }

        /// <inheritdoc/>
        public T ElementAt(int index)
        {
            this.ValidateIndex(index, this.LastIndex);

            Node<T> needNode;
            int counter;
            if (this.StartNodeIsHead(index))
            {
                needNode = this.head;
                counter = this.LastIndex;

                while (counter != index)
                {
                    needNode = needNode.PreviousNode;
                    counter--;
                }
            }
            else
            {
                needNode = this.root;
                counter = default;

                while (counter != index)
                {
                    needNode = needNode.NextNode;
                    counter++;
                }
            }

            return needNode.Data;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>(this, this.root);
        }

        /// <inheritdoc/>
        [SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "It's need for test case")]
        public void Remove(T item)
        {
            if (this.root is null)
            {
                throw new IndexOutOfRangeException();
            }

            var currentItem = this.root;

            while (!currentItem.Data.Equals(item))
            {
                currentItem = currentItem.NextNode;

                if (currentItem is null)
                {
                    return;
                }
            }

            if (currentItem.Data.Equals(item))
            {
                if (this.Length == SecondIndex)
                {
                    this.root = null;
                    this.head = null;
                }
                else if (this.Length == 2)
                {
                    this.head.PreviousNode = null;
                    this.root = this.head;
                }
                else
                {
                    if (currentItem.PreviousNode is null)
                    {
                        this.root = currentItem.NextNode;
                        this.root.PreviousNode = null;
                    }
                    else if (currentItem.NextNode is null)
                    {
                        this.head = currentItem.PreviousNode;
                        this.head.NextNode = null;
                    }
                    else
                    {
                        currentItem.NextNode.PreviousNode = currentItem.PreviousNode;
                        currentItem.PreviousNode.NextNode = currentItem.NextNode;
                    }
                }

                this.Length--;
            }
        }

        /// <inheritdoc/>
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index, this.LastIndex);

            Node<T> needNode;
            int counter;
            if (this.StartNodeIsHead(index))
            {
                needNode = this.head;
                counter = this.LastIndex;

                while (counter != index)
                {
                    needNode = needNode.PreviousNode;
                    counter--;
                }
            }
            else
            {
                needNode = this.root;
                counter = default;

                while (counter != index)
                {
                    needNode = needNode.NextNode;
                    counter++;
                }
            }

            if (needNode.PreviousNode is null)
            {
                this.root = needNode.NextNode;
                this.root.PreviousNode = null;
            }
            else if (needNode.NextNode is null)
            {
                this.head = needNode.PreviousNode;
                this.head.NextNode = null;
            }
            else
            {
                needNode.NextNode.PreviousNode = needNode.PreviousNode;
                needNode.PreviousNode.NextNode = needNode.NextNode;
            }

            this.Length--;

            return needNode.Data;
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
