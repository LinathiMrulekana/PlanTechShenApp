using PlanTechShenApp.ViewModels;
using PlanTechShenApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

        }

        private async void SignInClicked(object sender, EventArgs e)
        {
           

            string Name = string.Empty;
            string Surname = string.Empty;
            string Cellphone = string.Empty;
            string Email = string.Empty;
            string Password = string.Empty;
            string ConfirmPassword = string.Empty;


            if ((string.IsNullOrEmpty(Name)) &&
                (string.IsNullOrEmpty(Surname)) &&
                (string.IsNullOrEmpty(Email)) &&
                (string.IsNullOrEmpty(Password)) &&
                (string.IsNullOrEmpty(ConfirmPassword)) &&
                (string.IsNullOrEmpty(Cellphone)))
            {
                await Navigation.PushAsync(new PlantsHomeTabbedPage());

            }






        }
    }       
} 