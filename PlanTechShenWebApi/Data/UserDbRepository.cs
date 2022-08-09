
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using PlanTechShenApp.Data;
using PlanTechShenWebApi.Interfaces;
using PlanTechShenWebApi.Models;

namespace PlanTechShenWebApi.Data
{
    // TODO Split this repository into multiple repositories

    public class UserDbRepository : IUserDbRepository
    {
        private UserContext _userContext;

        public UserDbRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        #region Client


        public Client CreateNewClient(Client client)
        {
            _userContext.Client.Add(client);
            _userContext.SaveChanges();

            return client;
        }

        public bool DoesClientExistById(int id)
        {
            return _userContext.Client.Any(User => User.UserId == id);
        }

        public bool DoesClientExistByFirstName(string FirstName)
        {
            return _userContext.Client.Any(User => User.firstName == FirstName);
        }

        public bool DoesClientExistBysurname(string Surname)
        {
            return _userContext.Client.Any(User => User.firstName == Surname);
        }

        public bool DoesClientExistByEmailAddress(string Emailaddress)
        {
            return _userContext.Client.Any(User => User.firstName == Emailaddress);
        }

        public bool DoesClientExistByCellphoneNumber(string CellphoneNumber)
        {
            return _userContext.Client.Any(User => User.firstName == CellphoneNumber);
        }
        public List<Client> GetAllClients(bool fullFetch = true)
        {
            if (fullFetch)
            {
                var client = _userContext.Client.Include(c => c.UserAccounts).ToList();
                return client;
            }
            else
            {
                var clients = _userContext.Client.ToList();
                return clients;
            }
        }

        public Client GetClientById(int id, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var client = _userContext.Client.Where(x => x.UserId == id).Include(c => c.UserAccounts).FirstOrDefault();
                return client;
            }
            else
            {
                var client = _userContext.Client.Where(x => x.UserId == id).FirstOrDefault();
                return client;
            }
        }

        public Client GetClientByFirstName(string firstName, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var client = _userContext.Client.Where(x => x.firstName.Contains(firstName)).Include(x => x.UserAccounts).FirstOrDefault();
                return client;
            }
            else
            {
                var client = _userContext.Client.Where(x => x.Surname.Contains(firstName))
                    .FirstOrDefault();
                return client;

            }
        }
        public Client GetClientBySurname(string Surname, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var client = _userContext.Client.Where(x => x.Surname.Contains(Surname)).Include(x => x.UserAccounts).FirstOrDefault();
                return client;
            } 
            else
            {
                var client = _userContext.Client.Where(x => x.Surname.Contains(Surname)).FirstOrDefault();
                return client;

            }
        }
        public Client GetClientByEmail(string email, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var client = _userContext.Client.Where(x => x.EmailAddress == email).Include(x => x.UserAccounts).Include(x => x.UserAccounts).FirstOrDefault();
                return client;
            }
            else
            {
                var client = _userContext.Client.Where(x => x.EmailAddress == email).FirstOrDefault();
                return client;

            }
        }

        public Client GetClientByCellphoneNumber(string CellphoneNumber, bool fullFetch = true)
        {
            if (fullFetch)
            {

                var client = _userContext.Client.Where(x => x.CellphoneNumber == CellphoneNumber).Include(x => x.UserAccounts).FirstOrDefault();
                return client;
            }

            else
            {
                var client = _userContext.Client.Where(x => x.CellphoneNumber == CellphoneNumber).FirstOrDefault();
                return client;

            }
        }


        #endregion
        #region Detection
        public Detection GetDeviceByDeviceId(int id, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var detection = _userContext.Detections.Where(x => x.DeviceId == id).Include(c => c.WaterLevelPercentage).FirstOrDefault();
                return detection;
            }
            else
            {
                var detection = _userContext.Detections.Where(x => x.DeviceId == id).FirstOrDefault();
                return detection;
            }
        }

        public List<Detection> GetDetectionsByDeviceId(int id)
        {
            var detections = _userContext.Detections.Where(x => x.DeviceId == id).OrderBy(x => x.DetectionDate).ToList();

            return detections;
        }

        public Detection CreateNewDetection(Detection detection)
        {
            _userContext.Detections.Add(detection);
            _userContext.SaveChanges();

            return detection;
        }



        #endregion


        #region UserAccount

        public UserAccount CreateNewUserAccount(UserAccount userAccount)
        {
            _userContext.UserAccount.Add(userAccount);
            _userContext.SaveChanges();

            return userAccount;
        }


        public IList<UserAccount> GetUserAccountsByUserId(int userId)
        {
            var accounts = _userContext.UserAccount.Where(x => x.UserId == userId).ToList();
            return accounts;

        }

        public UserAccount GetUserAccountById(int UserAccountId)
        {
            var account = _userContext.UserAccount.Where(x => x.UserAccountId == UserAccountId).FirstOrDefault();
            return account;

        }


        #endregion






        #region Authentication

        public bool PerformAuthenticationCheck(string username, string password)
        {
            var user = _userContext.Authentication.Where(u => u.EmailAddress == username && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
