using PlanTechShenWebApi.Models;

namespace PlanTechShenWebApi.Interfaces
{
    public interface IUserDbRepository
    {
        Client CreateNewClient(Client client);
        UserAccount CreateNewUserAccount(UserAccount userAccount);
        bool DoesClientExistById(int id);
        bool DoesCustomerExistByCellphoneNumber(string CellphoneNumber);
        bool DoesCustomerExistByEmailAddress(string Emailaddress);
        bool DoesCustomerExistByFirstName(string FirstName);
        bool DoesCustomerExistBysurname(string Surname);
        List<Client> GetAllClients(bool fullFetch = true);
        Client GetClientByCellphoneNumber(string CellphoneNumber, bool fullFetch = true);
        Client GetClientByEmail(string email, bool fullFetch = true);
        Client GetClientById(int id, bool fullFetch = true);
        Client GetClientByFirstName(string firstName, bool fullFetch = true);
        Client GetCustomerBySurname(string Surname, bool fullFetch = true);
        UserAccount GetUserAccountById(int bUserAccountId);
        bool DoesClientExistByEmailAddress(string? emailAddress);
        IList<UserAccount> GetUserAccountsByUserId(int userId);
        bool PerformAuthenticationCheck(string username, string password);
        Client GetClientBySurname(string surname);
    }
}