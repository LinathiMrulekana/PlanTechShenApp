using PlanTechShenApp.Services;
using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlanTechShenApp.ViewModels
{
    public class MainPageViewModel
    {

        private async Task LoginAsync()
        {
           // if (!ValidationHelper.IsFormValid(LoginModel, _page)) { return; }
            // await _page.DisplayAlert("Success", "Validation Success!", "OK");
        }
        public class PlantListViewModel
        {
            private ObservableCollection<Detection> _detections;

            public ObservableCollection<Detection> Detections
            {
                get { return _detections; }
                set { _detections = value; }
            }


            public async Task GetDetections()
            {
                var service = new PlanTechHttpServices();
                var detect = await service.GetDetectionsByDeviceId(1);
                Detections = new ObservableCollection<Detection>(detect);
            }



        }
    }
}
