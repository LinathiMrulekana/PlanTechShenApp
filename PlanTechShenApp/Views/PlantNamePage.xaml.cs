using PlanTechShenApp.Data;
using PlanTechShenApp.Models;
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
    public partial class PlantNamePage : ContentPage
    {
        public PlantNamePage()
        {
            InitializeComponent();
        }

         async void OnSaveClicked(object sender, EventArgs e)
        {
            var plantItem = (PlantItems)BindingContext;
            PlantItemDatabase database = await PlantItemDatabase.Instance;
            await database.SaveItemAsync(plantItem);
            await Navigation.PopAsync();

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var plantItem = (PlantItems)BindingContext;
            PlantItemDatabase database = await PlantItemDatabase.Instance;
            await database.DeleteItemAsync(plantItem);
            await Navigation.PopAsync();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}