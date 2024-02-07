using Entities.Models.Customers;
using Entity.Models;
public interface IAddressRepo
    {
        Task<IEnumerable<Address>> GetAddress();
        Task<Address> GetAddressbyId(int Id);
        Task<Address> AddAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task DeleteAddress(int Id);
    }