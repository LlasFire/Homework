// <copyright file="UserTaskController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask
{
    using System;
    using UserTask.DoNotChange;

    /// <summary>
    /// Controller for work with user tasks.
    /// </summary>
    public class UserTaskController
    {
        private readonly UserTaskService taskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTaskController"/> class.
        /// </summary>
        /// <param name="taskService">Task Service.</param>
        public UserTaskController(UserTaskService taskService)
        {
            this.taskService = taskService;
        }

        /// <summary>
        /// Method for adding task attribute for user.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="description">Description.</param>
        /// <param name="model">Respond model.</param>
        /// <returns>True if task is added.</returns>
        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string message = this.GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);

            try
            {
                this.taskService.AddTaskForUser(userId, task);
                return null;
            }
            catch (UserServiceException exception)
            {
                return exception.Message;
            }
            catch (ArgumentNullException exception)
            {
                return exception.Message;
            }
        }
    }
}