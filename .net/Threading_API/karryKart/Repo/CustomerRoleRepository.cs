using ConsoleToDB.Data;
using Contracts;
using Entities.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CustomerRoleRepository : ICustomerRoleService
    {
        private readonly DataContext _context;
        public CustomerRoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CustomerRole> AddCustomerRole(CustomerRole customerRole)
        {
            var result = await _context.CustomerRole.AddAsync(customerRole);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCustomerRole(int Id)
        {
            var result = await _context.CustomerRole.FirstOrDefaultAsync(t => t.Id == Id);
            if (result != null)
            {
                _context.CustomerRole.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<CustomerRole>> GetCustomerRole()
        {
            return await _context.CustomerRole.ToListAsync();
        }
        public async Task<CustomerRole> GetCustomerRoleById(int Id)
        {
            return await _context.CustomerRole.FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<IQueryable<CustomerRole>> GetCustomerRoleByName(string name)
        {

            var query = from value in _context.CustomerRole
                        where value.Name == name || value.CreatedBy == name
                        select value;

            return query;
        }
        public async Task<CustomerRole> UpdateCustomerRole(CustomerRole customerRole)
        {
            var result = await _context.CustomerRole.FirstOrDefaultAsync(t => t.Id == customerRole.Id);
            if (result != null)
            {
                result.Name = customerRole.Name;
                result.FreeShipping = customerRole.FreeShipping;
                result.Taxexempt = customerRole.Taxexempt;
                result.Active = customerRole.Active;
                result.IsSystemRole = customerRole.IsSystemRole;
                result.CreatedAt = customerRole.CreatedAt;
                result.CreatedBy = customerRole.CreatedBy;
                result.ModifiedAt = customerRole.ModifiedAt;
                result.ModifiedBy = customerRole.ModifiedBy;
                result.IsDeleted = customerRole.IsDeleted;
                await _context.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}