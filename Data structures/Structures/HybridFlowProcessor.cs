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
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        /// <inheritdoc/>
        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public T Pop()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Push(T item)
        {
            throw new NotImplementedException();
        }
    }
}
