// <copyright file="UserStab.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3.Tests.Stubs
{
    using System.Collections.Generic;
    using UserTask.DoNotChange;

    /// <summary>
    /// Stub for user model.
    /// </summary>
    internal class UserStab : IUser
    {
        /// <inheritdoc/>
        public IList<UserTask> Tasks { get; } = new List<UserTask>
        {
            new UserTask("task1"),
            new UserTask("task2"),
            new UserTask("task3"),
        };
    }
}