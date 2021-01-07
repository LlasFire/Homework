// <copyright file="IHybridFlowProcessor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Structures.DoNotChange
{
    /// <summary>
    /// Interface for hybrid flow processor.
    /// </summary>
    /// <typeparam name="T">All types in C# language.</typeparam>
    public interface IHybridFlowProcessor<T>
    {
        /// <summary>
        /// Method for pushing item in a structure.
        /// </summary>
        /// <param name="item">Item for pushing.</param>
        void Push(T item);

        /// <summary>
        /// Get the last item and delete them from queue.
        /// </summary>
        /// <returns>Last element.</returns>
        T Pop();

        /// <summary>
        /// Add item in queue.
        /// </summary>
        /// <param name="item">Added item.</param>
        void Enqueue(T item);

        /// <summary>
        /// Get last item from queue.
        /// </summary>
        /// <returns>Last item.</returns>
        T Dequeue();
    }
}
