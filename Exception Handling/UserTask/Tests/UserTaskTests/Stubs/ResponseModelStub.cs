// <copyright file="ResponseModelStub.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3.Tests.Stubs
{
    using System.Collections.Generic;
    using UserTask.DoNotChange;

    /// <summary>
    /// Stub of response model.
    /// </summary>
    internal class ResponseModelStub : IResponseModel
    {
        private readonly IDictionary<string, string> data = new Dictionary<string, string>();

        /// <inheritdoc/>
        public void AddAttribute(string key, string value)
        {
            this.data.Add(key, value);
        }

        /// <inheritdoc/>
        public string GetAttribute(string key)
        {
            return this.data[key];
        }

        /// <summary>
        /// Return action result if data contains action_result key.
        /// </summary>
        /// <returns>Value in action_result key.</returns>
        public string GetActionResult()
        {
            if (this.data.ContainsKey("action_result"))
            {
                return this.data["action_result"];
            }

            return null;
        }
    }
}