using System.ComponentModel;

namespace DAN_XLIX_Kristina_Garcia_Francisco.ViewModel
{
    /// <summary>
    /// Base view model that implements the interface INotifyPropertyChanged
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Change of the property
        /// </summary>
        /// <param name="propertyName">property that is being changed</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
