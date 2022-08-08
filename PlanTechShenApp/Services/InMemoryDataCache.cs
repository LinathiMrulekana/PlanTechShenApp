using PlanTechShenApp.Services.Interface;
using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.Services
{
    public class InMemoryDataCache : IDataCache
    {
        public bool IsAuthenticated { get; set; }
        public Client AuthenticatedCustomer { get; set; }
    }
}
