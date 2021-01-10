// <copyright file="DoublyLinkedListTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StructuresTests
{
    using System;
    using FluentAssertions;
    using Structures;
    using Xunit;

    /// <summary>
    /// Class that conntains all of tests for my own DoublyLinkedList class.
    /// </summary>
    public class DoublyLinkedListTests
    {
        /// <summary>
        /// Test for Lehgth property.
        /// </summary>
        [Fact]
        public void Should_Increment_Length_Of_The_List_When_Element_Added()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
            };

            // Act
            var actualLength = list.Length;

            // Assert
            actualLength.Should()
                        .Be(2);
        }

        /// <summary>
        /// Test for ElementAt method.
        /// </summary>
        [Fact]
        public void Should_Return_Element_At_The_Specified_Position()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                5,
                6,
            };

            // Act
            var actualElement = list.ElementAt(1);

            // Assert
            actualElement.Should()
                         .Be(6);
        }

        /// <summary>
        /// Negative test for ElementAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_If_List_Is_Empty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            Action action = () => list.ElementAt(0);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Negative test for ElementAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_If_Index_Bigger_Or_Equal_Than_Length()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                3,
            };

            // Act
            Action action = () => list.ElementAt(2);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Negative test for ElementAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_If_Index_Less_Than_Zero()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                3,
            };

            // Act
            Action action = () => list.ElementAt(-2);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Test for AddAt method.
        /// </summary>
        [Fact]
        public void Should_Insert_Element_At_Specified_Position()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                3,
            };

            // Act
            list.AddAt(1, 5);

            // Assert
            var actualElement = list.ElementAt(1);

            actualElement.Should()
                         .Be(5);
        }

        /// <summary>
        /// Test for AddAt method.
        /// </summary>
        [Fact]
        public void Should_Increment_Length()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
            };

            // Act
            list.AddAt(1, 5);

            // Assert
            var actualElement = list.Length;

            actualElement.Should()
                         .Be(2);
        }

        /// <summary>
        /// Test for AddAt method.
        /// </summary>
        [Fact]
        public void Should_Insert_Element_At_The_End_Of_The_List()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                6,
            };

            // Act
            list.AddAt(2, 8);

            // Assert
            var actualElement = list.ElementAt(2);

            actualElement.Should()
                         .Be(8);
        }

        /// <summary>
        /// Test for AddAt method.
        /// </summary>
        [Fact]
        public void Should_Insert_Element_At_The_Beginning_Of_The_List()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                6,
            };

            // Act
            list.AddAt(0, 8);

            // Assert
            var actualElement = list.ElementAt(0);

            actualElement.Should()
                         .Be(8);
        }

        /// <summary>
        /// Test for Remove method.
        /// </summary>
        [Fact]
        public void Should_Remove_First_Occurance_In_The_List()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
                1,
            };

            // Act
            list.Remove(1);

            // Assert
            list.Should()
                .BeEquivalentTo(new[] { 2, 1 });
        }

        /// <summary>
        /// Test for Remove method.
        /// </summary>
        [Fact]
        public void Should_Decrement_Length_Of_The_List_If_Element_Removed()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
            };

            // Act
            list.Remove(2);

            // Assert
            list.Length.Should()
                       .Be(1);
        }

        /// <summary>
        /// Test for Remove method.
        /// </summary>
        [Fact]
        public void Should_Not_Change_Collection_If_It_Does_Not_Contain_Specified_Item()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
            };

            // Act
            list.Remove(4);

            // Assert
            list.Should()
                .BeEquivalentTo(new[] { 1, 2 });
        }

        /// <summary>
        /// Test for Lehgth property.
        /// </summary>
        [Fact]
        public void Should_Not_Decrement_Length_Of_The_List_If_It_Does_Not_Contain_Specified_Item()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
            };

            // Act
            list.Remove(4);

            // Assert
            list.Length.Should()
                       .Be(2);
        }

        /// <summary>
        /// Test for RemoveAt method.
        /// </summary>
        [Fact]
        public void Should_Remove_Element_At_The_Specified_Position()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                5,
                6,
            };

            // Act
            list.RemoveAt(1);

            // Assert
            list.Should()
                .BeEquivalentTo(new[] { 5 });
        }

        /// <summary>
        /// Test for RemoveAt method.
        /// </summary>
        [Fact]
        public void Should_Return_Removing_Item()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                2,
                5,
            };

            // Act
            var removedItem = list.RemoveAt(1);

            // Assert
            removedItem.Should()
                       .Be(5);
        }

        /// <summary>
        /// Test for Lehgth property.
        /// </summary>
        [Fact]
        public void Should_Decrement_Length_Of_The_List_If_Element_Removed_Using_RemoveAt()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                1,
                2,
            };

            // Act
            list.RemoveAt(1);

            // Assert
            list.Length.Should()
                       .Be(1);
        }

        /// <summary>
        /// Negative test for RemoveAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_For_RemoveAt_If_List_Is_Empty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            Action action = () => list.RemoveAt(0);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Negative test for RemoveAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_If_Index_For_RemoveAt_Bigger_Or_Equal_Than_Length()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                2,
                5,
            };

            // Act
            Action action = () => list.RemoveAt(2);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Negative test for RemoveAt method.
        /// </summary>
        [Fact]
        public void Should_Throw_IndexOutOfRangeException_If_Index_For_RemoveAt_Less_Than_Zero()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                2,
                5,
            };

            // Act
            Action action = () => list.RemoveAt(-1);

            // Assert
            action.Should()
                  .ThrowExactly<IndexOutOfRangeException>();
        }

        /// <summary>
        /// Test method checked ability foreach loop for my collection.
        /// </summary>
        [Fact]
        public void Should_Iterate_In_ForEach_Loop()
        {
            // Arrange
            var list = new DoublyLinkedList<int>
            {
                2,
                5,
                42,
            };

            int i = 0;

            // Act
            foreach (var item in list)
            {
                var checkItem = list.ElementAt(i);
                i++;

                // Assert
                item.Should()
                    .Be(checkItem);
            }
        }
    }
}
