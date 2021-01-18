// <copyright file="LoggingTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BrainstormSessions.Test.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrainstormSessions.Api;
    using BrainstormSessions.ClientModels;
    using BrainstormSessions.Controllers;
    using BrainstormSessions.Core.Interfaces;
    using BrainstormSessions.Core.Model;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using Moq;
    using Xunit;

    /// <summary>
    /// Test for logging in BrainstormSession project.
    /// </summary>
    public class LoggingTests : IDisposable
    {
        private readonly MemoryAppender appender;
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingTests"/> class.
        /// </summary>
        public LoggingTests()
        {
            this.appender = new MemoryAppender();
            BasicConfigurator.Configure(this.appender);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        /// <returns>Nothing.</returns>
        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            using var controller = new HomeController(mockRepo.Object);

            // Act
            await controller.Index();

            // Assert
            var logEntries = this.appender.GetEvents();
            Assert.True(logEntries.Any(l => l.Level == Level.Info), "Expected Info messages in the logs");
        }

        /// <summary>
        /// Test method.
        /// </summary>
        /// <returns>Nothing.</returns>
        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            using var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new NewSessionModel();

            // Act
            await controller.Index(newSession);

            // Assert
            var logEntries = this.appender.GetEvents();
            Assert.True(logEntries.Any(l => l.Level == Level.Warn), "Expected Warn messages in the logs");
        }

        /// <summary>
        /// Test method.
        /// </summary>
        /// <returns>Nothing.</returns>
        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            await controller.CreateActionResult(model: null);

            // Assert
            var logEntries = this.appender.GetEvents();
            Assert.True(logEntries.Any(l => l.Level == Level.Error), "Expected Error messages in the logs");
        }

        /// <summary>
        /// Test method.
        /// </summary>
        /// <returns>Nothing.</returns>
        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            using var controller = new SessionController(mockRepo.Object);

            // Act
            await controller.Index(testSessionId);

            // Assert
            var logEntries = this.appender.GetEvents();
            Assert.True(logEntries.Count(l => l.Level == Level.Debug) == 2, "Expected 2 Debug messages in the logs");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The implementation of Disposing pattern.
        /// </summary>
        /// <param name="disposing">Disposing flag.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.appender.Clear();
                }

                this.disposedValue = true;
            }
        }

        private static List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One",
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two",
            });
            return sessions;
        }
    }
}
