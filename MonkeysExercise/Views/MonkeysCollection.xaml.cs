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
            MonkeysCollectionViewModel context = new MonkeysCollectionViewModel();
            //Register to the event so the view model will be able to navigate to the monkeypage
            context.NavigateToPageEvent += NavigateToAsync;
            this.BindingContext = context;

            InitializeComponent();
        }

        //Allow ViewModel to call this function if needed to navigate to another page!
        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }

        
    }
}