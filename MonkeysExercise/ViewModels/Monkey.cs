using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeysExercise.ViewModels
{
    public class Monkey: INotifyPropertyChanged
    {
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual string Details { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual bool IsFavorite { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
