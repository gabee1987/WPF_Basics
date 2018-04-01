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

            // Test INotifyPopertyChanged
            //this.DataContext = new MVVMTest();
        }

        #endregion   
    }
}
