using System.IO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TreeViews_and_Value_Converters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region On Loaded
        
        /// <summary>
        /// When the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // Create a new item for it
                var item = new TreeViewItem()
                {
                    // Set the header
                    Header = drive,

                    // Set full path
                    Tag = drive
                };


                // Add items
                item.Items.Add(null);
                // Listen out for item being expanded
                item.Expanded += Folder_Expanded;

                // Add it to the main treeview
                FolderView.Items.Add(item);
            }
        }


        #endregion

        #region Folder Expanded

        /// <summary>
        /// When a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {

            #region Initial Checks

            var item = (TreeViewItem)sender;

            // If the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;
            // Clear the dummy data
            item.Items.Clear();

            // Get full path 
            var fullPath = (string)item.Tag;

            #endregion

            #region Get Folders 

            // Create a blank list for directories
            var directories = new List<string>();


            // Try and get directories from the folder
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch (UnauthorizedAccessException ue)
            {
                Console.WriteLine(ue);
            }

            // For each directory
            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                    // Set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    // and tag as full path
                    Tag = directoryPath
                };

                // Add dummy item so we can expand folder
                subItem.Items.Add(null);

                // Handle expnading
                subItem.Expanded += Folder_Expanded;

                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion

            #region Get Files

            // Create a blank list for files
            var fileList = new List<string>();


            // Try and get files from the folder
                try
                {
                    var files = Directory.GetFiles(fullPath);

                    if (files.Length > 0)
                        fileList.AddRange(files);
                }
                catch (UnauthorizedAccessException ue)
                {
                    Console.WriteLine(ue);
                }

            // For each file
            fileList.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                    // Set header as file name
                    Header = GetFileFolderName(filePath),
                    // and tag as full path
                    Tag = filePath
                };

                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion
        }

        #endregion

        #region Helpers


        /// <summary>
        /// Find a file or folder name from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes backslashes
            var normalizedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we dont find backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }

        #endregion
    }
}
