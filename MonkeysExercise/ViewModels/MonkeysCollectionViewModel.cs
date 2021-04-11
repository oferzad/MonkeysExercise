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

        #region Properties
        //Properties
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

        public ObservableCollection<Monkey> MonkeyList { get; }
        #endregion
        //Constructor
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

        #region Commands
        //Commands and methods connected to the commands

        //Selection changed 
        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public void OnSelectionChanged(Object obj)
        {
            if (obj is Monkey)
            {
                Monkey chosenMonkey = (Monkey)obj;
                Page monkeyPage = new ShowMonkey();
                ShowMonkeyViewModel monkeyContext = new ShowMonkeyViewModel
                {
                    Name = chosenMonkey.Name,
                    ImageUrl = chosenMonkey.ImageUrl,
                    Details = chosenMonkey.Details
                };
                monkeyPage.BindingContext = monkeyContext;
                monkeyPage.Title = monkeyContext.Name;
                if (NavigateToPageEvent != null)
                    NavigateToPageEvent(monkeyPage);
            }
        }
        //Delete monkey
        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);
        void RemoveMonkey(Monkey m)
        {
            if (MonkeyList.Contains(m))
            {
                MonkeyList.Remove(m);
            }

        }

        //Refresh collection
        public ICommand RefreshCommand => new Command(RefreshMonkeys);
        
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
        #endregion

        #region Events
        //Events
        //This event is used to navigate to the monkey page
        public Action<Page> NavigateToPageEvent;
        #endregion
    }


}
