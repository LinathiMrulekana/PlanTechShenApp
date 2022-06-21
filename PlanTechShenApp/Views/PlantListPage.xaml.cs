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
    public partial class PlantListPage : ContentPage
    {
        public PlantListPage()
        {
            InitializeComponent();

            Children.Add(new TipsPage());
            Children.Add(new CommunityPage());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PlantItemDatabase database = await PlantItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantNamePage
            {
                BindingContext = new PlantItems()
            });

        }

        async void OnlistViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PlantNamePage
                {
                    BindingContext = e.SelectedItem as PlantItems
                });
            }

        }
    }
}