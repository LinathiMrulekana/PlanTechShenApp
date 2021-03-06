using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage())
            {
                BarBackgroundColor = Color.LightGreen,
                BackgroundColor = Color.WhiteSmoke,
            };

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
