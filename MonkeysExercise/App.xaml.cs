using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeysExercise
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Page p = new MonkeysCollection();
            p.Title = "Monkeys";
            MainPage = new NavigationPage(p);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
