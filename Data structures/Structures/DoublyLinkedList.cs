// <copyright file="DoublyLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using Structures.DoNotChange;

    /// <summary>
    /// Implementation of my owm DoublyLinkedList.
    /// </summary>
    /// <typeparam name="T">Every structure in C#.</typeparam>
    public class DoublyLinkedList<T> : ParentEnumerable<T>, IDoublyLinkedList<T>
    {
        /// <inheritdoc/>
        public void Add(T item) => this.Push(item);

        /// <inheritdoc/>
        public void AddAt(int index, T item)
        {
            if (index == this.Length)
            {
                this.Push(item);
                return;
            }

            var currentNode = this.FindNodeByIndex(index);
            var newNode = new Node<T>(item, currentNode.PreviousNode, currentNode);

            currentNode.PreviousNode = newNode;
            this.Length++;
        }

        /// <inheritdoc/>
        public T ElementAt(int index)
        {
            var needNode = this.FindNodeByIndex(index);
            return needNode.Data;
        }

        /// <inheritdoc/>
        public void Remove(T item)
        {
            this.ValidateIfListEmpty();

            var currentItem = this.Root;
            var counter = default(int);

            while (!currentItem.Data.Equals(item))
            {
                currentItem = currentItem.NextNode;
                counter++;

                if (counter == this.Length)
                {
                    return;
                }
            }

            if (currentItem.Data.Equals(item))
            {
                this.RemoveNode(currentItem);
            }
        }

        /// <inheritdoc/>
        public T RemoveAt(int index)
        {
            var needNode = this.FindNodeByIndex(index);

            this.RemoveNode(needNode);

            return needNode.Data;
        }
    }
}
