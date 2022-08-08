using PlanTechShenWebApi.Models;

namespace PlanTechShenAppWebApi.Models
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public Client AuthenticatedCustomer { get; set; }
    }
}