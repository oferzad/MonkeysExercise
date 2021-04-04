using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeysExercise.Services;
using MonkeysExercise.Models;

namespace MonkeysExercise.ViewModels
{
    public class MonkeysCollectionViewModel:INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ObservableCollection<Monkey> MonkeyList { get; }
        public MonkeysCollectionViewModel()
        {
            MonkeyList = new ObservableCollection<Monkey>();
            this.isRefreshing = false;
            CreateMonkeyCollection();
        }
        async void CreateMonkeyCollection()
        {
            MonkeysWebServiceProxy proxy = new MonkeysWebServiceProxy();
            List<Monkey> theMonkeys = await proxy.GetAllMonkeysAsync();
            foreach(Monkey m in theMonkeys)
            {
                this.MonkeyList.Add(m);
            }
        }
        
        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);
        public ICommand RefreshCommand => new Command(RefreshMonkeys);
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                if (this.isRefreshing != value)
                {
                    this.isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }
        void RemoveMonkey(Monkey m)
        {
            if (MonkeyList.Contains(m))
            {
                MonkeyList.Remove(m);
            }
            
        }

        async void RefreshMonkeys()
        {
            MonkeysWebServiceProxy proxy = new MonkeysWebServiceProxy();
            List<Monkey> theMonkeys = await proxy.GetAllMonkeysAsync();
            this.MonkeyList.Clear();
            foreach (Monkey m in theMonkeys)
            {
                this.MonkeyList.Add(m);
            }
            this.IsRefreshing = false;
        }
    }
    
    
}
