// <copyright file="IUserDao.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask.DoNotChange
{
    /// <summary>
    /// User data access object interface.
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// Return user model by id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Interface of user model.</returns>
        IUser GetUser(int id);
    }
}