using PlanTechShenApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.Services
{
    public class AppConfigurationService : IAppConfiguration
    {
        private string _serverUrl;

        public string ServerUrl { get => _serverUrl; set => _serverUrl = value; }

        public AppConfigurationService()
        {
#if LOCALSERVER
                _serverUrl = "https://10.0.2.2:5001/";
#else
            _serverUrl = "http://localhost:5114";
#endif
        }
    }
}
