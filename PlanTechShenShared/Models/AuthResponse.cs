using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenShared.Models
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public UserAccount AuthenticatedUserAccount { get; set; }

        public AuthResponse()
        {
            Authenticated = false;
            AuthenticatedUserAccount = null;
        }
    }
}
