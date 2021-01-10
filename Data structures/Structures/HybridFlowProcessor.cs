// <copyright file="HybridFlowProcessor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures
{
    using System;
    using Structures.DoNotChange;

    /// <summary>
    /// One of implementation for my own HybridFlowProcessor.
    /// </summary>
    /// <typeparam name="T">Every structure in C#.</typeparam>
    public class HybridFlowProcessor<T> : ParentEnumerable<T>, IHybridFlowProcessor<T>
    {
        /// <inheritdoc/>
        public T Dequeue()
        {
            if (this.Length == default)
            {
                throw new InvalidOperationException();
            }

            var needItem = this.Root;
            this.RemoveNode(needItem);

            return needItem.Data;
        }

        /// <inheritdoc/>
        public void Enqueue(T item) => this.Push(item);

        /// <inheritdoc/>
        public T Pop()
        {
            if (this.Length == default)
            {
                throw new InvalidOperationException();
            }

            var needItem = this.Head;
            this.RemoveNode(needItem);

            return needItem.Data;
        }
    }
}
