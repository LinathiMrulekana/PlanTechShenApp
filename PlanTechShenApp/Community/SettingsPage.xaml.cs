using PlanTechShenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanTechShenApp.Community
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            // TODO Add listview for settings

           /*  ListView<SettingsInfo gsInfo> settingslist = new ListView <SettingsInfo>
            {
               new SettingsInfo{Name ="Personal & Account information",ImageName= "personalicon.png"},
               new SettingsInfo{Name ="Password & Security", ImageName= "passwordicon.png"},
               new SettingsInfo{Name = "Notifications", ImageName= "notificationicon.png"},
               new SettingsInfo {Name ="DarkMode", ImageName= "darkmodeicon.png"},
               new SettingsInfo {Name= "Data Policy", ImageName = "policyicon.png"},
               new SettingsInfo{Name ="Terms of Service" ,ImageName= "termsicon.png"},
               new SettingsInfo{Name= "Language & Region", ImageName="languageicon.png"},
               new SettingsInfo{Name="Social Media", ImageName= "socialicon.png"},

            };
*/        }
    }
}