using nanoFramework.Json;
using NFApp1.Model;
using NFApp1.Sensor;
using System;
using System.Device.Adc;
using System.Device.Gpio;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
namespace NFApp1
{
    /*    public class MoistureDegrees
        {
            public double WaterLevelPercentage { get; set; }
            public DateTime DetectionDate { get; set; }
        }

        */


    public class Program
    {
        /*
        public static void SendTelemetry(DetectionData moistureDegrees)

        {
            var moisture = JsonConvert.SerializeObject(moistureDegrees);

            var content = new StringContent(moisture, Encoding.UTF8, "application/json");
            var result = _httpClient.Post("http://172.17.130.79:5030/api/detection", content);

            result.EnsureSuccessStatusCode();

            var response = result.Content.ReadAsString();

        }
        */
        public static DetectionData ReadMoistureSensor(DfRobotMoistureSensor sensor)
        { 
            var moistureDegrees = new DetectionData();

            moistureDegrees.WaterLevelPercentage = sensor.GetMoisturePercentage();
            moistureDegrees.DetectionDate = DateTime.UtcNow;

            return moistureDegrees;
        }
        
        public static void ControlPump(DfRobotRelay relay, DetectionData moistureDegrees)
        {
            if (moistureDegrees.WaterLevelPercentage < 30)
            {
                relay.SetRelay(PinValue.High);
            }

            if (moistureDegrees.WaterLevelPercentage > 70)
            {
                relay.SetRelay(PinValue.Low);
            }



        }
        

        static void Main()
        {
            GpioController _gpioController = new GpioController();
            AdcController _adcController = new AdcController();
            HttpClient _httpClient;


            DfRobotMoistureSensor _moistureSensor = new DfRobotMoistureSensor(_adcController,15);
            DfRobotRelay _relay = new DfRobotRelay(_gpioController, 2);

            while (true)
            {
                //Debug.WriteLine("Hello from nanoFramework!");

              //var moisturePerc = ReadMoistureSensor();

                DetectionData moisturePerc = ReadMoistureSensor(_moistureSensor);
                ControlPump(_relay,moisturePerc);
               // SendTelemetry(moisturePerc);

                Debug.WriteLine(moisturePerc.WaterLevelPercentage.ToString());

                Thread.Sleep(2000);
            }
        }
    }
}


    
    








