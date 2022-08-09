using PlanTechShenApp.Data;
using PlanTechShenApp.Models;
using PlanTechShenAppWebApi.Models;
using PlanTechShenWebApi.Models;

namespace PlanTechShenAppWebApi.Data
{
           public class DbInitialiser
        {
            private readonly UserContext _context;

            public DbInitialiser(UserContext context)
            {
                _context = context;
            }

            public void Run()
            {



                if (!_context.Client.Any())
                {

                    var client = new Client();
                    client.firstName = "Chuck";
                    client.Surname = "Norris";
                    client.CellphoneNumber = "0652311963";
                    client.EmailAddress = "me@computer.com";


                    var userAccount = new UserAccount();


                    var authentication = new Authentication();
                    authentication.LastLogin = DateTime.Now;
                    authentication.Password = "12345";
                    authentication.Enabled = true;

                    client.UserAccounts = new List<UserAccount>();
                    client.UserAccounts.Add(userAccount);

                    client.Authentication = authentication;



                }


                if (!_context.Detections.Any())
                {
                    var detection = new Detection();

                    detection.WaterLevelPercentage = 100;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-10);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 90;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-9);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 80;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-8);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 70;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-7);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 60;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-6);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 50;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-5);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 40;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-4);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 30;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-3);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 80;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-2);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 70;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now.AddDays(-1);

                    _context.Detections.Add(detection);

                    detection = new Detection();

                    detection.WaterLevelPercentage = 60;
                    detection.DeviceId = 1;
                    detection.DetectionDate = DateTime.Now;

                    _context.Detections.Add(detection);

                    _context.SaveChanges();

                }
            }
        }
    }

