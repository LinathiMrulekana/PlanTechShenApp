using PlanTechShenWebApi.Models;

namespace PlanTechShenWebApi.Interfaces
{
    public interface IUserDbRepository
    {
        Client CreateNewClient(Client client);
        UserAccount CreateNewUserAccount(UserAccount userAccount);
        bool DoesClientExistByCellphoneNumber(string CellphoneNumber);
        bool DoesClientExistByEmailAddress(string Emailaddress);
        bool DoesClientExistByFirstName(string FirstName);
        bool DoesClientExistById(int id);
        bool DoesClientExistBysurname(string Surname);
        List<Client> GetAllClients(bool fullFetch = true);
        Client GetClientByCellphoneNumber(string CellphoneNumber, bool fullFetch = true);
        Client GetClientByEmail(string email, bool fullFetch = true);
        Client GetClientByFirstName(string firstName, bool fullFetch = true);
        Client GetClientById(int id, bool fullFetch = true);
        Client GetClientBySurname(string Surname, bool fullFetch = true);
        UserAccount GetUserAccountById(int UserAccountId);
        IList<UserAccount> GetUserAccountsByUserId(int userId);
        bool PerformAuthenticationCheck(string username, string password);


        List<Detection> GetDetectionsByDeviceId(int id);
        Detection CreateNewDetection(Detection detection);


    }
}