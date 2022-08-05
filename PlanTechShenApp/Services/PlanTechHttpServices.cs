using Newtonsoft.Json;
using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlanTechShenApp.Services
{
    public class PlanTechHttpServices
    {
        private HttpClient _httpClient;

        private string _serverUrl;

        public PlanTechHttpServices()
        {
            var handler = DependencyService.Get<IHttpNativeHandler>();

            _httpClient = new HttpClient(handler.GetHttpClientHandler());

            _serverUrl = "https://10.0.2.2:7030/";

        }


        public async Task<List<Detection>> GetDetectionsByDeviceId(int deviceId)
        {
            //"byDeviceid?deviceId=1"
            Uri uri = new Uri(_serverUrl + "api/Detection/byDeviceid?deviceId=" + deviceId);

            try
            {
               
               var  response = await _httpClient.GetStringAsync(uri);


               var valueResponse = JsonConvert.DeserializeObject<List<Detection>>(response);

               return valueResponse;
                

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return new List<Detection>() ;
        }
    }
}
