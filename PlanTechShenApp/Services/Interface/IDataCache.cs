using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.Services.Interface
{
    public interface IDataCache
    {
        bool IsAuthenticated { get; set; }

        Client AuthenticatedCustomer { get; set; }
    }
}
