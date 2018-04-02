using System.Windows;
using MVVM_Basics;

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

            this.DataContext = new DirectoryStructureViewModel();

            // For test purposes
            //var item1 = dirViewModel.Items[0];
            //dirViewModel.Items[0].ExpandCommand.Execute(null);

            // Test INotifyPopertyChanged
            //this.DataContext = new MVVMTest();
        }

        #endregion   
    }
}
