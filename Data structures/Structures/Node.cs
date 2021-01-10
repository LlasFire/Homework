// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    /// <summary>
    /// Node class for DoubleLinkedList.
    /// </summary>
    /// <typeparam name="T">Type of node.</typeparam>
    public sealed class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="data">Data of current node.</param>
        /// <param name="nextNode">Next node.</param>
        /// <param name="previousNode">Previous node.</param>
        public Node(T data, Node<T> previousNode = null, Node<T> nextNode = null)
        {
            this.Data = data;
            this.NextNode = nextNode;
            this.PreviousNode = previousNode;
        }

        /// <summary>
        /// Gets or sets the data of this node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the "pointer" on next node in List.
        /// </summary>
        public Node<T> NextNode { get; set; }

        /// <summary>
        /// Gets or sets the "pointer" on previous node in List.
        /// </summary>
        public Node<T> PreviousNode { get; set; }
    }
}
