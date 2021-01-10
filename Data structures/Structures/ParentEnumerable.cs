// <copyright file="ParentEnumerable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Parent class for my own Enumerable structures.
    /// </summary>
    /// <typeparam name="T">Every type in C#.</typeparam>
    public class ParentEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// Constant for internal logic.
        /// </summary>
        protected const int SecondIndex = 1;

        /// <summary>
        /// Gets or sets the length of structure.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets the last index of list.
        /// </summary>
        protected int LastIndex => this.Length - 1;

        /// <summary>
        /// Gets or sets root node.
        /// </summary>
        protected Node<T> Root { get; set; }

        /// <summary>
        /// Gets or sets head node.
        /// </summary>
        protected Node<T> Head { get; set; }

        /// <summary>
        /// Add element in head of list.
        /// </summary>
        /// <param name="item">Adding item.</param>
        public void Push(T item)
        {
            if (this.Length <= SecondIndex)
            {
                this.CreateStructureWhenPushFirstItems(item);
            }
            else
            {
                var newNode = new Node<T>(item, this.Head);
                this.Head.NextNode = newNode;
                this.Head = newNode;
            }

            this.Length++;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>(this, this.Root);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Remove node from this structure.
        /// </summary>
        /// <param name="node">Node for removing.</param>
        protected void RemoveNode(Node<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (this.LastIndex == default)
            {
                this.Root = null;
                this.Head = null;
            }
            else if (this.LastIndex == SecondIndex)
            {
                if (this.Head.Equals(node))
                {
                    this.Root.NextNode = null;
                    this.Head = this.Root;
                }
                else
                {
                    this.Head.PreviousNode = null;
                    this.Root = this.Head;
                }
            }
            else
            {
                if (node.PreviousNode is null)
                {
                    this.Root = node.NextNode;
                    this.Root.PreviousNode = null;
                }
                else if (node.NextNode is null)
                {
                    this.Head = node.PreviousNode;
                    this.Head.NextNode = null;
                }
                else
                {
                    node.NextNode.PreviousNode = node.PreviousNode;
                    node.PreviousNode.NextNode = node.NextNode;
                }
            }

            this.Length--;
        }

        /// <summary>
        /// Find node in structure by input index.
        /// </summary>
        /// <param name="index">Index for search.</param>
        /// <returns>Finded index.</returns>
        /// <exception cref="IndexOutOfRangeException">If index is out of range.</exception>
        protected Node<T> FindNodeByIndex(int index)
        {
            this.ValidateIndex(index, this.LastIndex);

            Node<T> needNode;
            int counter;
            if (this.IndexCloseToHead(index))
            {
                needNode = this.Head;
                counter = this.LastIndex;

                while (counter != index)
                {
                    needNode = needNode.PreviousNode;
                    counter--;
                }
            }
            else
            {
                needNode = this.Root;
                counter = default;

                while (counter != index)
                {
                    needNode = needNode.NextNode;
                    counter++;
                }
            }

            return needNode;
        }

        /// <summary>
        /// Validate input index before search operations.
        /// </summary>
        /// <param name="index">Index for validation.</param>
        /// <param name="length">Maximum diapason for validation (by length of list or by last index for example).</param>
        [SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "It's need for test case")]
        protected void ValidateIndex(int index, int length)
        {
            this.ValidateIfListEmpty();

            if (index > length || index < default(int))
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Checking the list for emptiness before other operations.
        /// </summary>
        [SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "It's need for test case")]
        protected void ValidateIfListEmpty()
        {
            if (this.Head is null && this.Root is null)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void CreateStructureWhenPushFirstItems(T item)
        {
            if (this.Length == default)
            {
                var newNode = new Node<T>(item);
                this.Root = newNode;
                this.Head = newNode;
            }
            else if (this.Length == SecondIndex)
            {
                var newNode = new Node<T>(item, this.Root);
                this.Head = newNode;
                this.Root.NextNode = this.Head;
            }
        }

        private bool IndexCloseToHead(int index)
        {
            return Math.Abs(index - this.Length) >= Math.Abs(index - default(int));
        }
    }
}
