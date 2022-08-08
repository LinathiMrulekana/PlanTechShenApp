using PlanTechShenApp.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityPage : ContentPage
    {
        public CommunityPage()
        {
            InitializeComponent();
        }
         private  void OnToolbarItemClicked(object sender, EventArgs e)
         {
            
         }
        private async void ClientSupportClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientSupportPage());
        }
        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void ImageClicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                await Browser.OpenAsync("https://www.gardening-forums.com/forums/general-gardening-talk.5/");

            
            }
        }

        private async void IOTSetupClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IOTPage());
        }
    }
}