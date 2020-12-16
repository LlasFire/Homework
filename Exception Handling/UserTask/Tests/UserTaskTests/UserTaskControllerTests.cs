// <copyright file="UserTaskControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3.Tests
{
    using NUnit.Framework;
    using Task3.Tests.Stubs;
    using UserTask;
    using UserTask.DoNotChange;

    /// <summary>
    /// Tests for UserTaskController.
    /// </summary>
    [TestFixture]
    public class UserTaskControllerTests
    {
        private readonly UserTaskController controller;
        private readonly IUserDao userDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskControllerTests"/> class.
        /// </summary>
        public UserTaskControllerTests()
        {
            this.userDao = new UserDaoStub();
            var taskService = new UserTaskService(this.userDao);
            this.controller = new UserTaskController(taskService);
        }

        /// <summary>
        /// Test when data is valid.
        /// </summary>
        [Test]
        public void CreateUserTask_ValidData_ReturnsTaskAndEmptyMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 1;

            bool result = this.controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(model.GetActionResult(), Is.Null);
            Assert.That(this.userDao.GetUser(userId).Tasks.Count, Is.EqualTo(4));
            StringAssert.AreEqualIgnoringCase(this.userDao.GetUser(userId).Tasks[3].Description, description);
        }

        /// <summary>
        /// Test when UserId is invalid.
        /// </summary>
        [Test]
        public void CreateUserTask_InvalidUserId_ReturnsNullAndInvalidUserIdMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = -11, existingUserId = 1;

            bool result = this.controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "Invalid userId");
            Assert.That(this.userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        /// <summary>
        /// Test when user isn't existent.
        /// </summary>
        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndUserNotFoundMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 2, existingUserId = 1;

            bool result = this.controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "User not found");
            Assert.That(this.userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        /// <summary>
        /// Test when user isn't existent.
        /// </summary>
        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndTheTaskAlreadyExistsMessage()
        {
            var model = new ResponseModelStub();
            string description = "task3";
            int userId = 1;

            bool result = this.controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            StringAssert.AreEqualIgnoringCase(model.GetActionResult(), "The task already exists");
            Assert.That(this.userDao.GetUser(userId).Tasks.Count, Is.EqualTo(3));
        }
    }
}