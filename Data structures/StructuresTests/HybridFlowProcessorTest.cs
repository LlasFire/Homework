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
    /// Class for all of HybridFlowProcessor tests.
    /// </summary>
    public class HybridFlowProcessorTest
    {
        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Pop_Item_From_The_Top_Of_Processing_Items()
        {
            var processor = new HybridFlowProcessor<int>();
            processor.Push(5);
            processor.Push(6);

            var actualElement = processor.Pop();

            actualElement.Should().Be(6);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Throw_InvalidOperationExceptiong_If_Processor_Queue_Is_Empty_And_Pop_Called()
        {
            var processor = new HybridFlowProcessor<int>();

            Action action = () => processor.Pop();

            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Dequeue_Item_From_The_Beginning_Of_Processing_Items()
        {
            var processor = new HybridFlowProcessor<int>();
            processor.Enqueue(5);
            processor.Enqueue(6);

            processor.Dequeue().Should().Be(5);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Throw_InvalidOperationExceptiong_If_Processor_Queue_Is_Empty_And_Dequeue_Called()
        {
            var processor = new HybridFlowProcessor<int>();

            Action action = () => processor.Dequeue();

            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Dequeue_Item_From_The_Beginning_Of_Processing_Items_With_Mix_Add()
        {
            var processor = new HybridFlowProcessor<int>();
            processor.Push(5);
            processor.Enqueue(6);

            processor.Dequeue().Should().Be(5);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public void Should_Pop_Item_From_The_Beginning_Of_Processing_Items_With_Mix_Add()
        {
            var processor = new HybridFlowProcessor<int>();
            processor.Enqueue(6);
            processor.Push(5);

            processor.Pop().Should().Be(5);
        }
    }
}
