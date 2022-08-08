using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanTechShenApp.Services.Interface
{
    public interface IAuthentication
    {
        Task<AuthResponse> Authenticate(string Email, string Password);
    }
}
