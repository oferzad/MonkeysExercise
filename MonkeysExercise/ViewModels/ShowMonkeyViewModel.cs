using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeysExercise.ViewModels
{
    public class ShowMonkeyViewModel: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
