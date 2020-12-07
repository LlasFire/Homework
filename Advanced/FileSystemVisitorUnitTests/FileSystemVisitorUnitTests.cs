// <copyright file="FileSystemVisitorUnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileSystemVisitorUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using FluentAssertions;
    using Logic;
    using Xunit;

    /// <summary>
    /// Unit tests class.
    /// </summary>
    public class FileSystemVisitorUnitTests
    {
        private const string TestFolderPath = @"..\..\..\TestDirectory\";

        /// <summary>
        /// Test when search pattern is null or empty.
        /// </summary>
        /// <param name="template">String null or empty.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Search_PatternIsNull_ShouldThrowException(string template)
        {
            // Arrange
            var model = new FileSystemVisitor();

            // Act
            Action testAction = () => model.FilterPattern = template;

            // Assert
            testAction.Should()
                    .Throw<ArgumentException>()
                    .WithMessage("The value mustn't be null or empty. Default value is * (Parameter 'value')");
        }

        /// <summary>
        /// Test when source path is null or empty.
        /// </summary>
        /// <param name="template">String null or empty.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Search_SourcePathIsNull_ShouldThrowException(string template)
        {
            // Arrange
            var model = new FileSystemVisitor();

            // Act
            Action testAction = () => model.SourcePath = template;

            // Assert
            testAction.Should()
                    .Throw<ArgumentException>()
                    .WithMessage("The value mustn't be null or empty. (Parameter 'value')");
        }

        /// <summary>
        /// Test when search pattern is incorrect.
        /// </summary>
        [Fact]
        public void Search_SourcePathIncorrect_ShouldThrowException()
        {
            // Arrange
            var fictitiousPath = @"Z:\bubu\bubub";

            var model = new FileSystemVisitor
            {
                SourcePath = fictitiousPath,
            };

            // Act
            Action testAction = () => model.Search();

            // Assert
            testAction.Should()
                    .Throw<DirectoryNotFoundException>()
                    .WithMessage($"Directory not found: {fictitiousPath}");
        }

        /// <summary>
        /// Test when we filter only result.
        /// </summary>
        [Fact]
        public void Search_FilterOnlyFolders_ShouldReturnOnlyFolders()
        {
            // Arrange
            var model = new FileSystemVisitor
            {
                SourcePath = TestFolderPath,
                FilterPattern = FileSystemVisitor.ExcludeFileFilter,
            };

            var outputFolderNames = new List<string>
            {
                "bbin",
                "FirstLayerFolder1",
                "FirstLayerFolder2",
                "FirstLayerFolder3",
                "SecondLayerFolder",
                "SecondLayerFolder1",
                "SecondLayerFolder2",
                "ThirdLayerFolder",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "Files were excluded from the search.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputFolderNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we filter only files.
        /// </summary>
        [Fact]
        public void Search_FilterOnlyFiles_ShouldReturnOnlyFiles()
        {
            // Arrange
            var model = new FileSystemVisitor
            {
                SourcePath = TestFolderPath,
                FilterPattern = FileSystemVisitor.ExcludeDirectoryFilter,
            };

            var outputNames = new List<string>
            {
                "3000x2000_990611_[www.ArtFile.ru].jpg",
                "Animals___Cats_Red_Cat_on_an_orange_background_044688_.jpg",
                "app.config",
                "csrd_log - Copy (2).txt",
                "csrd_log - Copy (3).txt",
                "csrd_log - Copy (4).txt",
                "csrd_log - Copy.txt",
                "csrd_log.txt",
                "godnota.jpg",
                "kot-kote-ryzhij-morda-usy.svg",
                "log.txt",
                "Microsoft.Practices.Unity.Configuration.dll",
                "R2D2.bmp",
                "Secret.xlsx",
                "Test.docx",
                "TextWorksheet.xlsx",
                "times.png",
                "vocabulary_careers.doc",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "Directories were excluded from the search.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we use filter pattern.
        /// </summary>
        [Fact]
        public void Search_ExcludeFolderAndIncludeFileType_ShouldReturnCorrectListFilesAndFolders()
        {
            // Arrange
            var model = new FileSystemVisitor
            {
                SourcePath = TestFolderPath,
                FilterPattern = @"!*/bbin/*;*.png",
            };

            var outputNames = new List<string>
            {
                "FirstLayerFolder1",
                "FirstLayerFolder2",
                "FirstLayerFolder3",
                "SecondLayerFolder",
                "SecondLayerFolder1",
                "SecondLayerFolder2",
                "ThirdLayerFolder",
                "times.png",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "The directories had filtered by search pattern.",
                "The files had filtered by search pattern.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we use filter pattern.
        /// </summary>
        [Fact]
        public void Search_IncludeFolderAndExcludeFileType_ShouldReturnCorrectListFilesAndFolders()
        {
            // Arrange
            var model = new FileSystemVisitor
            {
                SourcePath = TestFolderPath,
                FilterPattern = @"*/FirstLayerFolder3/*;!*.xlsx",
            };

            var outputNames = new List<string>
            {
                "csrd_log - Copy (2).txt",
                "csrd_log - Copy (3).txt",
                "csrd_log - Copy (4).txt",
                "csrd_log - Copy.txt",
                "csrd_log.txt",
                "FirstLayerFolder3",
                "SecondLayerFolder",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "The directories had filtered by search pattern.",
                "The files had filtered by search pattern.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we use null Lambda filters.
        /// </summary>
        [Fact]
        public void Search_UseNullINLambdaFilters_ShouldReturnAllFilesAndFolders()
        {
            // Arrange
            var model = new FileSystemVisitor(TestFolderPath, null, null);

            var outputNames = new List<string>
            {
                "3000x2000_990611_[www.ArtFile.ru].jpg",
                "Animals___Cats_Red_Cat_on_an_orange_background_044688_.jpg",
                "app.config",
                "bbin",
                "csrd_log - Copy (2).txt",
                "csrd_log - Copy (3).txt",
                "csrd_log - Copy (4).txt",
                "csrd_log - Copy.txt",
                "csrd_log.txt",
                "FirstLayerFolder1",
                "FirstLayerFolder2",
                "FirstLayerFolder3",
                "godnota.jpg",
                "kot-kote-ryzhij-morda-usy.svg",
                "log.txt",
                "Microsoft.Practices.Unity.Configuration.dll",
                "R2D2.bmp",
                "SecondLayerFolder",
                "SecondLayerFolder1",
                "SecondLayerFolder2",
                "Secret.xlsx",
                "Test.docx",
                "TextWorksheet.xlsx",
                "ThirdLayerFolder",
                "times.png",
                "vocabulary_careers.doc",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we use Lambda filters.
        /// </summary>
        [Fact]
        public void Search_UseLambdaFilters_ShouldReturnCorrectListFilesAndFolders()
        {
            // Arrange
            var model = new FileSystemVisitor(TestFolderPath, f => f.Extension.Contains("dll"), d => !d.Name.Contains("Layer"));

            var outputNames = new List<string>
            {
                "bbin",
                "Microsoft.Practices.Unity.Configuration.dll",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "The files had filtered by lambda expression.",
                "The directories had filtered by lambda expression.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        /// <summary>
        /// Test when we use filter patern and Lambda filters.
        /// </summary>
        [Fact]
        public void Search_UsePatternAndLambdaFilters_ShouldReturnCorrectListFilesAndFolders()
        {
            // Arrange
            var model = new FileSystemVisitor(TestFolderPath);
            model.FilterPattern = @"*.txt;";
            model.DirectoryFilter = dir => dir.Name.StartsWith("First");

            var outputNames = new List<string>
            {
                "csrd_log - Copy (2).txt",
                "csrd_log - Copy (3).txt",
                "csrd_log - Copy (4).txt",
                "csrd_log - Copy.txt",
                "csrd_log.txt",
                "FirstLayerFolder1",
                "FirstLayerFolder2",
                "FirstLayerFolder3",
                "log.txt",
            };

            var outputEvents = new List<string>
            {
                "The process has begun.",
                "The files had found.",
                "The directories had found.",
                "The files had filtered by search pattern.",
                "The directories had filtered by lambda expression.",
                "The process is over",
            };

            var receivedEvents = new List<string>();
            Subscribe(model, receivedEvents);

            // Act
            var result = model.Search();

            // Assert
            result.Should()
                   .BeEquivalentTo(outputNames);

            receivedEvents.Should()
                   .BeEquivalentTo(outputEvents);
        }

        [SuppressMessage("Major Code Smell", "S1172:Unused method parameters should be removed", Justification = "receivedEvents used for adding events")]
        private static void Subscribe(FileSystemVisitor visitor, List<string> receivedEvents)
        {
            void AddToList(string message) => receivedEvents.Add(message);
            visitor.Start += AddToList;
            visitor.Finish += AddToList;
            visitor.DirectorysFiltered += AddToList;
            visitor.FilesFiltered += AddToList;
            visitor.DirectorysFinded += AddToList;
            visitor.FilesFinded += AddToList;
        }
    }
}
