using MVVM_Basics.Directory.ViewModels;
using MVVM_Basics.DirectoryClasses;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MVVM_Basics
{
    /// <summary>
    /// A View model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }


        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicates if the current is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the Ui tells us to close
                else
                    this.ClearChildren();
            }
        }

        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear items
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand arrow if we are not on file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        /// <summary>
        /// Expand this directory and finds all children
        /// </summary>
        private void Expand()
        {
            throw new NotImplementedException();
        }
    }
}
