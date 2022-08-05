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

        }

       
private async void LogInClickedAsync(object sender, EventArgs e)
 {

     string Username = "---";
     string Password = "---";

     if (!(string.IsNullOrEmpty(Username)) && !(string.IsNullOrEmpty(Password)))
     {
         await Navigation.PushAsync(new PlantsHomeTabbedPage());
     }
            else {
                 await DisplayAlert("Alert", "PLEASE FILL IN THE BLANKS", "OK");
            }


        }


private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new HomePage());
        }

    }
}