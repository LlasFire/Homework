// <copyright file="HybridFlowProcessorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StructuresTests
{
    using System;
    using FluentAssertions;
    using Structures;
    using Xunit;

    /// <summary>
    /// Class that contains all of HybridFlowProcessor tests.
    /// </summary>
    public class HybridFlowProcessorTest
    {
        /// <summary>
        /// Test for Pop method.
        /// </summary>
        [Fact]
        public void Should_Pop_Item_From_The_Top_Of_Processing_Items()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();
            processor.Push(5);
            processor.Push(6);

            // Act
            var actualElement = processor.Pop();

            // Assert
            actualElement.Should()
                         .Be(6);
        }

        /// <summary>
        /// Negative test for Pop method.
        /// </summary>
        [Fact]
        public void Should_Throw_InvalidOperationExceptiong_If_Processor_Queue_Is_Empty_And_Pop_Called()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();

            // Act
            Action action = () => processor.Pop();

            // Assert
            action.Should()
                  .Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test for Dequeue method.
        /// </summary>
        [Fact]
        public void Should_Dequeue_Item_From_The_Beginning_Of_Processing_Items()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();
            processor.Enqueue(5);
            processor.Enqueue(6);

            // Act
            var actualElement = processor.Dequeue();

            // Assert
            actualElement.Should()
                         .Be(5);
        }

        /// <summary>
        /// Negative test for Dequeue method.
        /// </summary>
        [Fact]
        public void Should_Throw_InvalidOperationExceptiong_If_Processor_Queue_Is_Empty_And_Dequeue_Called()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();

            // Act
            Action action = () => processor.Dequeue();

            // Assert
            action.Should()
                  .Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Dequeue_Item_From_The_Beginning_Of_Processing_Items_With_Mix_Add()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();
            processor.Push(5);
            processor.Enqueue(6);

            // Act
            var actualElement = processor.Dequeue();

            // Assert
            actualElement.Should()
                         .Be(5);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Pop_Item_From_The_Beginning_Of_Processing_Items_With_Mix_Add()
        {
            // Arrange
            var processor = new HybridFlowProcessor<int>();
            processor.Enqueue(6);
            processor.Push(5);

            // Act
            var actualElement = processor.Pop();

            // Assert
            actualElement.Should()
                         .Be(5);
        }
    }
}
