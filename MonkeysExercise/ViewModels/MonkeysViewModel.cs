using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeysExercise.Services;

namespace MonkeysExercise.ViewModels
{
    public class MonkeysViewModel
    {
        public ObservableCollection<Monkey> MonkeyList { get; }
        public MonkeysViewModel()
        {
            MonkeyList = new ObservableCollection<Monkey>();
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

        void RemoveMonkey(Monkey m)
        {
            if (MonkeyList.Contains(m))
            {
                MonkeyList.Remove(m);
            }
        }

        public async void RefreshMonkeys()
        {
            MonkeysWebServiceProxy proxy = new MonkeysWebServiceProxy();
            List<Monkey> theMonkeys = await proxy.GetAllMonkeysAsync();
            this.MonkeyList.Clear();
            foreach (Monkey m in theMonkeys)
            {
                this.MonkeyList.Add(m);
            }
        }
    }
    
    
}
