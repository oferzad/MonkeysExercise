using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeysExercise.ViewModels;
using MonkeysExercise.Models;

namespace MonkeysExercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonkeysCollection : ContentPage
    {
        public MonkeysCollection()
        {
            this.BindingContext = new MonkeysCollectionViewModel();
            InitializeComponent();
        }

        
        private void collectionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Monkey chosenMonkey = (Monkey)e.CurrentSelection[0];
            Page monkeyPage = new ShowMonkey();
            ShowMonkeyViewModel monkeyContext = new ShowMonkeyViewModel
            {
                Name = chosenMonkey.Name,
                ImageUrl = chosenMonkey.ImageUrl,
                Details = chosenMonkey.Details
            };
            monkeyPage.BindingContext = monkeyContext;
            monkeyPage.Title = monkeyContext.Name;
            Navigation.PushAsync(monkeyPage);
        }
    }
}