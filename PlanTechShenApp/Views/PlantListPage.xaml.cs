using Microcharts;
using PlanTechShenApp.Data;
using PlanTechShenApp.Models;
using PlanTechShenApp.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PlanTechShenApp.ViewModels.MainPageViewModel;

namespace PlanTechShenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantListPage : ContentPage
    {
        public PlantListPage()
        {
            InitializeComponent();

            var vm = new PlantListViewModel();

            BindingContext = vm;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PlantItemDatabase database = await PlantItemDatabase.Instance;
           listView.ItemsSource = await database.GetItemsAsync();


            var vm = (PlantListViewModel) BindingContext;

            await vm.GetDetections();

            PopulateChart();
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

        public void PopulateChart()
        {
            var vm = (PlantListViewModel)BindingContext;
            var detections = vm.Detections;


            List<ChartEntry> entries = new List<ChartEntry>();
            LineChart lc = new LineChart();

            foreach (var detection in detections)
            {
                
                var chartEntry = new ChartEntry((float) detection.WaterLevelPercentage)  ;

                chartEntry.Label = detection.DetectionDate.ToShortDateString();
               
                entries.Add(chartEntry);

            }

            lc.Entries = entries;

            chartView.Chart = lc;


/*            lc.LabelTextSize = 48;
            lc.LineMode = LineMode.Straight;

            List<ChartEntry> entries = new List<ChartEntry>();

            var color = new SKColor(0, 0, 255);

            ChartEntry entry = new ChartEntry(10) { Label = "Test Label 1", ValueLabelColor = color, ValueLabel="10"};

            entries.Add(entry);

           // entry = new ChartEntry(20) { Label = "Test Label 2", ValueLabelColor = color };

           // entries.Add(entry);

            entry = new ChartEntry(80) { Label = "Test Label 4", ValueLabelColor = color };

            entries.Add(entry);

            lc.Entries = entries;

            chartView.Chart = lc;
*/

        }


    }
}