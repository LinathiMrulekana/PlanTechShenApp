using PlanTechShenApp.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommunityPage : Shell
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

        private async void ProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void IOTSetupClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IOTPage());
        }
    }
}