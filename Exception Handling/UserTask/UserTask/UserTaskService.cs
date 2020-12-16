// <copyright file="UserTaskService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask
{
    using System;
    using UserTask.DoNotChange;

    /// <summary>
    /// Service for work with user tasks.
    /// </summary>
    public class UserTaskService
    {
        private readonly IUserDao userDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskService"/> class.
        /// </summary>
        /// <param name="userDao">UserDao interface.</param>
        public UserTaskService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        /// <summary>
        /// Method for adding task to user.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="task">Task object.</param>
        public void AddTaskForUser(int userId, UserTask task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (userId < 0)
            {
                throw new UserServiceException("Invalid userId");
            }

            var user = this.userDao.GetUser(userId);

            if (user == null)
            {
                throw new UserServiceException("User not found");
            }

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                {
                throw new UserServiceException("The task already exists");
                }
            }

            tasks.Add(task);
        }
    }
}