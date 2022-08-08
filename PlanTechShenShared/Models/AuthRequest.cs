namespace PlanTechShenAppWebApi.Models
{

    //  Add Security as this password is in CLEARTEXT
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

      
    }
}
