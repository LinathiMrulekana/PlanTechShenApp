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

        public void Run(DateTime dateOnly, Authentication userAccount, Authentication authentication)
        {



            if (!_context.Client.Any())
            {

                var client = new Client();
                client.firstName = "Chuck";
                client.Surname = "Norris";
                client.CellphoneNumber = "0652311963";
                client.EmailAddress = "me@computer.com";


                var UserAccount = new UserAccount();
              
                UserAccount.Description = "11adsfdf";



                var Authentication = new Authentication();
                Authentication.LastLogin = dateOnly;
                Authentication.Password = "12345";
                Authentication.Enabled = true;

                client.UserAccounts = new List<UserAccount>();
                client.UserAccounts.Add(UserAccount);

                client.Authentication = userAccount;

            }
        }
    }
}
