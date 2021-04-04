using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeysExercise.ViewModels;

namespace MonkeysExercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonkeysCollection : ContentPage
    {
        public MonkeysCollection()
        {
            this.BindingContext = new MonkeysViewModel();
            InitializeComponent();
        }

        public ICommand refreshCommand => new Command(Refresh);

        private void Refresh()
        {
            MonkeysViewModel monkeysViewModel = (MonkeysViewModel)this.BindingContext;
            monkeysViewModel.RefreshMonkeys();
            refreshView.IsRefreshing = false;
        }

        private void collectionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monkey chosenMonkey = (Monkey)e.CurrentSelection[0];
            Page monkeyPage = new ShowMonkey();
            monkeyPage.BindingContext = chosenMonkey;
            monkeyPage.Title = chosenMonkey.Name;
            Navigation.PushAsync(monkeyPage);
        }
    }
}