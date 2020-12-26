// <copyright file="ObjectExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReflectionChanging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Fasterflect;

    /// <summary>
    /// Class for changing readonly properties and fields in class.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Static method for setting readonly property for object.
        /// </summary>
        /// <param name="obj">Object for changing.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="newValue">New value for property.</param>
        public static void SetReadOnlyProperty(this object obj, string propertyName, object newValue)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Property name is empty");
            }

            if (newValue is null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            var type = obj.GetType();
            var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (property is null)
            {
                throw new ArgumentException($"Property with name {propertyName} does not exist");
            }

            var resultFields = new List<FieldInfo>();
            GetAllHiddenFieldsRecursive(type, resultFields);

            // Find hidden field by type and special name pattern <PropertyName>k__BackingField
            var hiddenField = resultFields.FirstOrDefault(f => f.FieldType == property.PropertyType &&
                                                               f.Name.Contains($"<{property.Name}>"));

            if (hiddenField != null)
            {
                obj.SetFieldValue(hiddenField.Name, newValue, Flags.AllMembers);
            }
        }

        /// <summary>
        /// Static method for setting readonly field for object.
        /// </summary>
        /// <param name="obj">Object for changing.</param>
        /// <param name="filedName">Field name.</param>
        /// <param name="newValue">New value for field.</param>
        public static void SetReadOnlyField(this object obj, string filedName, object newValue)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (string.IsNullOrEmpty(filedName))
            {
                throw new ArgumentException("Property name is empty");
            }

            if (newValue is null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            obj.SetFieldValue(filedName, newValue, Flags.AllMembers);
        }

        /// <summary>
        /// Method for recursive getting all hidden fields for type and his BaseTypes.
        /// </summary>
        /// <param name="type">Start type.</param>
        /// <param name="fieldInfos">List of field info objects for collecting fields.</param>
        private static void GetAllHiddenFieldsRecursive(Type type, List<FieldInfo> fieldInfos)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            if (fields.Any())
            {
                fieldInfos.AddRange(fields);
            }

            if (type.BaseType != null)
            {
                GetAllHiddenFieldsRecursive(type.BaseType, fieldInfos);
            }
        }
    }
}
