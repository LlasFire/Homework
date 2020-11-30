// <copyright file="FileSystemVisitor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Allows you to crawl the folder tree in the file system, starting from the specified point.
    /// </summary>
    public class FileSystemVisitor
    {
        private const string DefaultFilter = "*";
        private const string IncludePrefix = "*";
        private const string ExcludePrefix = "!";

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        public FileSystemVisitor()
        {
        }

        /// <summary>
        /// Gets or sets source path for search.
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets filters for search.
        /// </summary>
        public string Filters { get; set; } = DefaultFilter;

        /// <summary>
        /// Get folder filters by Regex from Filters string.
        /// </summary>
        /// <returns>List of folder filters.</returns>
        public List<string> GetFolderFilters()
        {
            if (this.Filters == DefaultFilter)
            {
                return new List<string>();
            }

            var folderFilterPattern = @"(!\*|\*)\\(\w|\W)+\*";
            var folderFilterExpression = new Regex(folderFilterPattern);

            return this.Filters.Split(';')
                                .Where(f => folderFilterExpression.IsMatch(f))
                                .ToList();
        }

        /// <summary>
        /// Get file filters by Regex from Filters string.
        /// </summary>
        /// <returns>List of folder filters.</returns>
        public List<string> GetFileFilters()
        {
            if (this.Filters == DefaultFilter)
            {
                return new List<string>();
            }

            var fileFilterPattern = @"(!\*|\*|\w+)\.(\w|\*)+";
            var fileFilterExpression = new Regex(fileFilterPattern);

            return this.Filters.Split(';')
                                .Where(f => fileFilterExpression.IsMatch(f))
                                .ToList();
        }

        /// <summary>
        /// Search files and folders in filesystem.
        /// </summary>
        /// <returns>The file names list.</returns>
        public List<string> Search()
        {
            DirectoryInfo directory;
            if (Directory.Exists(this.SourcePath))
            {
                directory = new DirectoryInfo(this.SourcePath);
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory not found: {this.SourcePath}");
            }

            var resultFiles = directory.GetFiles().ToList();
            var resultDirectory = directory.GetDirectories().ToList();

            resultFiles = this.FilteredFile(resultFiles);
            resultDirectory = this.FilteredDirectory(resultDirectory);

            return result;
        }

        /// <summary>
        /// Simple iterator for filtering directory.
        /// </summary>
        /// <param name="resultDirectory">Source list.</param>
        /// <param name="includeFilters">Include filters.</param>
        /// <param name="excludeFilters">Exclude filters.</param>
        /// <returns>Item.</returns>
        private static IEnumerable<DirectoryInfo> DirectoryFilter(List<DirectoryInfo> resultDirectory, List<string> includeFilters, List<string> excludeFilters)
        {
            foreach (var dir in resultDirectory)
            {
                if (includeFilters.Any() && includeFilters.Any(filter => dir.FullName.Contains(filter)))
                {
                    yield return dir;
                }

                if (!excludeFilters.Any() && excludeFilters.Any(filter => dir.FullName.Contains(filter)))
                {
                    yield return dir;
                }
            }
        }

        private List<DirectoryInfo> FilteredDirectory(List<DirectoryInfo> resultDirectory)
        {
            var filters = this.GetFolderFilters();

            if (filters.Any())
            {
                return resultDirectory;
            }

            var includeFilters = filters.Where(f => f.StartsWith(IncludePrefix, StringComparison.OrdinalIgnoreCase))
                                        .Select(f => f.Replace("*", string.Empty).Replace(";", string.Empty))
                                        .ToList();
            var excludeFilters = filters.Where(f => f.StartsWith(ExcludePrefix, StringComparison.OrdinalIgnoreCase))
                                        .Select(f => f.Replace("*", string.Empty).Replace("!", string.Empty).Replace(";", string.Empty))
                                        .ToList();

            return DirectoryFilter(resultDirectory, includeFilters, excludeFilters).ToList();
        }

        private List<FileInfo> FilteredFile(List<FileInfo> resultFiles)
        {
            var filters = this.GetFileFilters();

            if (filters.Any())
            {
                return resultFiles;
            }

            var includeFilters = filters.Where(f => f.StartsWith(IncludePrefix, StringComparison.OrdinalIgnoreCase))
                                        .Select(f => f.Replace("*", string.Empty).Replace(";", string.Empty))
                                        .ToList();
            var excludeFilters = filters.Where(f => f.StartsWith(ExcludePrefix, StringComparison.OrdinalIgnoreCase))
                                        .Select(f => f.Replace("*", string.Empty).Replace("!", string.Empty).Replace(";", string.Empty))
                                        .ToList();
        }
    }
}
