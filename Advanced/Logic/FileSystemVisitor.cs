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
    /// <exception cref="DirectoryNotFoundException">When directory not found.</exception>
    public class FileSystemVisitor
    {
        /// <summary>
        /// Excluding all files from search.
        /// </summary>
        public const string ExcludeFileFilter = "!*.*";

        /// <summary>
        /// Excluding all directories from search.
        /// </summary>
        public const string ExcludeDirectoryFilter = @"!*\*\*";

        private const string DefaultFilter = "*";
        private const string ExcludePrefix = "!";
        private string filterPattern;
        private string sourcePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        public FileSystemVisitor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        /// <remarks>
        /// sourcePath : C:\\Temp .
        /// filterPattern : !*.jpg;!*.temp;!*/bin/* .
        /// or filterPattern : *.jpg;*/obj/* .
        /// </remarks>
        /// <param name="sourcePath">Start folder for search.</param>
        public FileSystemVisitor(string sourcePath)
        {
            this.SourcePath = sourcePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        /// <remarks>
        /// sourcePath : C:\\Temp .
        /// filterPattern : !*.jpg;!*.temp;!*/bin/* .
        /// or filterPattern : *.jpg;*/obj/* .
        /// </remarks>
        /// <param name="sourcePath">Start folder for search.</param>
        /// <param name="filterPattern">Search pattern.</param>
        public FileSystemVisitor(string sourcePath, string filterPattern)
        {
            this.FilterPattern = filterPattern;
            this.SourcePath = sourcePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        /// <param name="sourcePath">Start folder for search.</param>
        /// <param name="fileFilter">File filter.</param>
        /// <param name="directoryFilter">Directory filter.</param>
        public FileSystemVisitor(string sourcePath,  Func<FileInfo, bool> fileFilter, Func<DirectoryInfo, bool> directoryFilter)
        {
            this.FileFilter = fileFilter;
            this.DirectoryFilter = directoryFilter;
            this.SourcePath = sourcePath;
        }

        /// <summary>
        /// Send message when process had begun.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void StartDelegate(string message);

        /// <summary>
        /// Send message when process is over.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void FinishDelegate(string message);

        /// <summary>
        /// Send message when files are finded.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void FilesFindedDelegate(string message);

        /// <summary>
        /// Send message when directories are finded.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void DirectorysFindedDelegate(string message);

        /// <summary>
        /// Send message when files are filtered.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void FilesFilteredDelegate(string message);

        /// <summary>
        /// Send message when directories are filtered.
        /// </summary>
        /// <param name="message">Message.</param>
        public delegate void DirectorysFilteredDelegate(string message);

        /// <summary>
        /// Start event.
        /// </summary>
        public event StartDelegate Start = message => { };

        /// <summary>
        /// Start event.
        /// </summary>
        public event FinishDelegate Finish = message => { };

        /// <summary>
        /// Start event.
        /// </summary>
        public event FilesFindedDelegate FilesFinded = message => { };

        /// <summary>
        /// Start event.
        /// </summary>
        public event DirectorysFindedDelegate DirectorysFinded = message => { };

        /// <summary>
        /// Start event.
        /// </summary>
        public event FilesFilteredDelegate FilesFiltered = message => { };

        /// <summary>
        /// Start event.
        /// </summary>
        public event DirectorysFilteredDelegate DirectorysFiltered = message => { };

        /// <summary>
        /// Gets or sets source path for search.
        /// </summary>
        public string SourcePath
        {
            get
            {
               return this.sourcePath;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The value mustn't be null or empty.", nameof(value));
                }

                this.sourcePath = value;
            }
        }

        /// <summary>
        /// Gets or sets filterPattern for funded files.
        /// </summary>
        public Func<FileInfo, bool> FileFilter { get; set; }

        /// <summary>
        /// Gets or sets filterPattern for funded directories.
        /// </summary>
        public Func<DirectoryInfo, bool> DirectoryFilter { get; set; }

        /// <summary>
        /// Gets or sets string filters pattern for search.
        /// </summary>
        /// <exception cref="ArgumentException">If value is null or empty.</exception>
        public string FilterPattern
        {
            get
            {
               return string.IsNullOrEmpty(this.filterPattern)
                      ? DefaultFilter
                      : this.filterPattern;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The value mustn't be null or empty. Default value is *", nameof(value));
                }

                this.filterPattern = value;
            }
        }

        /// <summary>
        /// Get folder filters by Regex from FilterPattern string.
        /// </summary>
        /// <returns>List of folder filters.</returns>
        public List<string> GetFolderFilters()
        {
            if (this.FilterPattern == DefaultFilter)
            {
                return new List<string>();
            }

            // For find folder filters like */temp/* or !*/temp
            var folderFilterExpression = new Regex(@"(!\*|\*)(\\|\/)(\w|\W)+\**");

            // For find last / symbol
            var replaceRegex = new Regex(@"\\(?:.(?!\\))*$");
            var filters = this.FilterPattern.Split(';');

            if (filters.Any(f => f.Contains(ExcludeDirectoryFilter)))
            {
                return new List<string> { ExcludeDirectoryFilter };
            }

            // delete chars *, then replace / to \, and then delete last \ symbol
            return filters.Where(dir => folderFilterExpression.IsMatch(dir))
                          .Select(dir => replaceRegex.Replace(dir.Replace("/", @"\").Replace("*", string.Empty), string.Empty))
                          .ToList();
        }

        /// <summary>
        /// Get file filters by Regex from FilterPattern string.
        /// </summary>
        /// <returns>List of folder filters.</returns>
        public List<string> GetFileFilters()
        {
            if (this.FilterPattern == DefaultFilter)
            {
                return new List<string>();
            }

            // For find file filters like .png or !.temp or temp.*
            var fileFilterExpression = new Regex(@"(!\*|\*|\w+)\.(\w|\*)+");
            var filters = this.FilterPattern.Split(';');

            if (filters.Any(f => f.Contains(ExcludeFileFilter)))
            {
                return new List<string> { ExcludeFileFilter };
            }

            return filters.Where(f => fileFilterExpression.IsMatch(f))
                          .Select(f => f.Replace("*", string.Empty))
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

            this.Start("The process has begun.");

            var files = directory.GetFiles(DefaultFilter, SearchOption.AllDirectories).ToList();

            if (files.Any())
            {
                this.FilesFinded("The files had found.");
            }
            else
            {
                this.FilesFinded("The files hadn't found.");
            }

            var directories = directory.GetDirectories(DefaultFilter, SearchOption.AllDirectories).ToList();

            if (directories.Any())
            {
                this.DirectorysFinded("The directories had found.");
            }
            else
            {
                this.DirectorysFinded("The directories hadn't found.");
            }

            (directories, files) = this.FilteredByDirectory(directories, files);
            files = this.FilteredByFile(files);

            if (this.FileFilter != null)
            {
                files = files.Where(this.FileFilter).ToList();
                this.FilesFiltered("The files had filtered by lambda expression.");
            }

            if (this.DirectoryFilter != null)
            {
                directories = directories.Where(this.DirectoryFilter).ToList();
                this.DirectorysFiltered("The directories had filtered by lambda expression.");
            }

            var result = files.Select(f => f.Name)
                                    .Concat(directories.Select(dir => dir.Name))
                                    .ToList();
            result.Sort();

            this.Finish("The process is over");
            return result;
        }

        /// <summary>
        /// Simple iterator for filtering entities.
        /// </summary>
        /// <param name="entities">Source list.</param>
        /// <param name="includeFilters">Include filters.</param>
        /// <param name="excludeFilters">Exclude filters.</param>
        /// <returns>Item.</returns>
        private static IEnumerable<T> FilteredEntity<T>(List<T> entities, List<string> includeFilters, List<string> excludeFilters)
            where T : FileSystemInfo
        {
            foreach (var entity in entities)
            {
                if (includeFilters.Any())
                {
                    if (includeFilters.Any(filter => entity.FullName.Contains(filter)))
                    {
                        yield return entity;
                    }
                }
                else
                {
                    if (!excludeFilters.Any() ||
                        (excludeFilters.Any() && !excludeFilters.Any(filter => entity.FullName.Contains(filter))))
                    {
                        yield return entity;
                    }
                }
            }
        }

        /// <summary>
        /// Sort filter patterns by include and exclude.
        /// </summary>
        /// <param name="filters">List of filters.</param>
        /// <returns>Lists include and exclude patterns.</returns>
        private static (List<string>, List<string>) GetIncludeExcludeFilters(List<string> filters)
        {
            var includeFilters = filters.Where(f => !f.StartsWith(ExcludePrefix, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var excludeFilters = filters.Where(f => f.StartsWith(ExcludePrefix, StringComparison.OrdinalIgnoreCase))
                .Select(f => f.Replace("!", string.Empty))
                .ToList();

            return (includeFilters, excludeFilters);
        }

        /// <summary>
        /// Filtered lists of directories and files by directory filters.
        /// </summary>
        /// <param name="directories">List of directories.</param>
        /// <param name="files">List of files.</param>
        /// <returns>Tuple filtered lists directories and files.</returns>
        private (List<DirectoryInfo>, List<FileInfo>) FilteredByDirectory(List<DirectoryInfo> directories, List<FileInfo> files)
        {
            var filters = this.GetFolderFilters();

            if (!filters.Any())
            {
                return (directories, files);
            }

            if (filters.Any(f => f.Equals(ExcludeDirectoryFilter)))
            {
                this.DirectorysFiltered("Directories were excluded from the search.");
                return (new List<DirectoryInfo>(), files);
            }

            var (includeFilters, excludeFilters) = GetIncludeExcludeFilters(filters);

            files = FilteredEntity(files, includeFilters, excludeFilters).ToList();
            directories = FilteredEntity(directories, includeFilters, excludeFilters).ToList();

            this.DirectorysFiltered("The directories had filtered by search pattern.");
            return (directories, files);
        }

        /// <summary>
        /// Filtered lists of files by file filters.
        /// </summary>
        /// <param name="files">List of files.</param>
        /// <returns>Filtered list of files.</returns>
        private List<FileInfo> FilteredByFile(List<FileInfo> files)
        {
            var filters = this.GetFileFilters();

            if (!filters.Any())
            {
                return files;
            }

            if (filters.Any(f => f.Equals(ExcludeFileFilter)))
            {
                this.FilesFiltered("Files were excluded from the search.");
                return new List<FileInfo>();
            }

            var (includeFilters, excludeFilters) = GetIncludeExcludeFilters(filters);

            this.FilesFiltered("The files had filtered by search pattern.");
            return FilteredEntity(files, includeFilters, excludeFilters).ToList();
        }
    }
}
