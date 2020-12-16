// <copyright file="IResponseModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserTask.DoNotChange
{
    /// <summary>
    /// Response model interface.
    /// </summary>
    public interface IResponseModel
    {
        /// <summary>
        /// Add attribute to response model.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        void AddAttribute(string key, string value);

        /// <summary>
        /// Get attribute value by key.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Value string.</returns>
        string GetAttribute(string key);
    }
}