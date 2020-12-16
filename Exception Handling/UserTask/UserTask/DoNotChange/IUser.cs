// <copyright file="IUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask.DoNotChange
{
    using System.Collections.Generic;

    /// <summary>
    /// User model interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets list of user tasks.
        /// </summary>
        IList<UserTask> Tasks { get; }
    }
}