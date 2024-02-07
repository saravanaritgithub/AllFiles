using Entities.Models.Customers;

public interface IOnlineCustomerRepo
{
    Task<IEnumerable<OnlineCustomer>> GetOnlineCustomer();
    Task<OnlineCustomer> GetOnlineCustomerbyId(int Id);
    Task<OnlineCustomer> AddOnlineCustomer(OnlineCustomer onlineCustomer);
    Task<OnlineCustomer> UpdateOnlineCustomer(OnlineCustomer onlineCustomer);
    Task<OnlineCustomer> DeleteOnlineCustomer(int Id);
}