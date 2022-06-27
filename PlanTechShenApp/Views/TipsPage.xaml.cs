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
    public partial class TipsPage : ContentPage
    {
        
        public TipsPage()
        {
            InitializeComponent();

        

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search items...",
                PlaceholderColor = Color.Orange,
                TextColor = Color.Orange,
                TextTransform = TextTransform.Lowercase,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(SearchBar)),
                FontAttributes = FontAttributes.Italic
            };
        }

        private async void StartUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartUpPage());
        }

        private void PlantListView(object sender, ItemTappedEventArgs e)
        {

        }
    }
}