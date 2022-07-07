using PlanTechShenApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage :ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();

            var image = new Image { Source = "contact.png" };
            //Children.Add(new SignIn());
        }

        private async void LogInClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantsHomeTabbedPage());

        }

        private async void SignUpClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}