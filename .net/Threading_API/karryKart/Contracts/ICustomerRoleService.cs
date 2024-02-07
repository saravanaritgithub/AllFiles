using Entities.Models.Customers;

namespace Contracts
{
    public interface ICustomerRoleService
    {
        Task<IEnumerable<CustomerRole>> GetCustomerRole();
        Task<CustomerRole> GetCustomerRoleById(int Id);
        Task<CustomerRole> AddCustomerRole(CustomerRole customerRole);
        Task<CustomerRole> UpdateCustomerRole(CustomerRole customerRole);
        Task DeleteCustomerRole(int Id);
    }
}