// <copyright file="UserTask.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask.DoNotChange
{
    /// <summary>
    /// User task model.
    /// </summary>
    public class UserTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTask"/> class.
        /// </summary>
        /// <param name="description">Description.</param>
        public UserTask(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// Gets description of task.
        /// </summary>
        public string Description { get; }
    }
}