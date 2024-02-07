using ConsoleToDB.Data;
using Entites.Models;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class AddressRepository : IAddressRepo
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Address>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }
        public async Task<Address> AddAddress(Address address)
        {
            var result = await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteAddress(int Id)
        {
            var result = await _context.Address.FirstOrDefaultAsync(t => t.Id == Id);
            if (result != null)
            {
                _context.Address.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IQueryable<Address>> GetAddressByName(string name)
        {
            var query = from value in _context.Address
                        where value.Address1 == name || value.CreatedBy == name
                        select value;
            return query;
        }
        public async Task<IEnumerable<Address>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }
        public async Task<Address> GetAddressbyId(int Id)
        {
            return await _context.Address.FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<Address> UpdateAddress(Address address)
        {
            var result = await _context.Address.FirstOrDefaultAsync(t => t.Id == address.Id);
            if (result != null)
            {
                result.CreatedBy = address.CreatedBy;
                result.ModifiedBy = address.ModifiedBy;
                result.PhoneNumber = address.PhoneNumber;
                result.Email = address.Email;
                result.FaxNumber = address.FaxNumber;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}