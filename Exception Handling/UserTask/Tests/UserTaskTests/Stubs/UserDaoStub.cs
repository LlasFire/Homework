// <copyright file="UserDaoStub.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3.Tests.Stubs
{
    using System.Collections.Generic;
    using UserTask.DoNotChange;

    /// <summary>
    /// Stub of User Dao object.
    /// </summary>
    internal class UserDaoStub : IUserDao
    {
        private readonly IDictionary<int, IUser> data = new Dictionary<int, IUser>
        {
            { 1, new UserStab() },
        };

        /// <inheritdoc/>
        public IUser GetUser(int id)
        {
            if (this.data.ContainsKey(id))
            {
                return this.data[id];
            }

            return null;
        }
    }
}