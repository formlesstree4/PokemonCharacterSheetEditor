using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokemonCharacterSheetEditor.Lib.Ui
{

    /// <summary>
    ///     Abstract class for handling ViewModel integration.
    /// </summary>
    /// <remarks>
    ///     Includes a nice implementation of OnPropertyChanged. Which is good for WPF.
    /// </remarks>
    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {

        /// <summary>
        ///     Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Occurs when a property value is changing
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;



        /// <summary>
        ///     Invoke when a property value has changed
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected internal void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new System.ArgumentException("message", nameof(propertyName));
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Invoke when a property value is changing
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing</param>
        protected internal void OnPropertyChanging([CallerMemberName]string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new System.ArgumentException("message", nameof(propertyName));
            }
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

    }

}