using PlanTechShenWebApi.Models;

namespace PlanTechShenAppWebApi.Models
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public Client AuthenticatedUserAccount { get; set; }
    }
}