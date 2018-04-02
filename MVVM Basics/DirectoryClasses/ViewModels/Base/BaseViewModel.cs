using System.ComponentModel;

namespace MVVM_Basics
{
    /// <summary>
    /// A base view model that fires the Property Phanged events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
