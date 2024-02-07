using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CustomerInfoRepository : ICustomerInfo
    {
        private readonly DataContext _dataContext;
        public CustomerInfoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<CustomerInfo>> GetCustomerInfo()
        {
            return await _dataContext.CustomerInfo.ToListAsync();
        }
        public async Task<CustomerInfo> GetCustomerInfoId(int Id)
        {
            return await _dataContext.CustomerInfo.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<CustomerInfo> AddCustomerInfo(CustomerInfo customerInfo)
        {
            var result = await _dataContext.CustomerInfo.AddAsync(customerInfo);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<IQueryable<CustomerInfo>> GetCustomerInfoByName(string name)
        {

            var query = from value in _dataContext.CustomerInfo
                        where value.Name == name || value.CreatedBy == name
                        select value;

            return query;
        }
        public async Task<CustomerInfo> UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            var result = await _dataContext.CustomerInfo
                .FirstOrDefaultAsync(e => e.Id == customerInfo.Id);

            if (result != null)
            {
                result.Name = customerInfo.Name;
                result.Email = customerInfo.Email;
                result.Phone = customerInfo.Phone;
                result.AddressId = customerInfo.AddressId;
                result.Address = customerInfo.Address;
                result.Gender = customerInfo.Gender;
                result.DateOfBirth = customerInfo.DateOfBirth;
                result.CompanyName = customerInfo.CompanyName;
                result.Istaxexempt = customerInfo.Istaxexempt;
                result.NewsLetter = customerInfo.NewsLetter;
                result.CustomerRolesEnum = customerInfo.CustomerRolesEnum;
                result.VendorId = customerInfo.VendorId;
                result.Vendors = customerInfo.Vendors;
                result.Active = customerInfo.Active;
                result.AdminComment = customerInfo.AdminComment;
                result.CreatedAt = customerInfo.CreatedAt;
                result.CreatedBy = customerInfo.CreatedBy;
                result.ModifiedAt = customerInfo.ModifiedAt;
                result.ModifiedBy = customerInfo.ModifiedBy;
                result.IsDeleted = customerInfo.IsDeleted;


                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteCustomerInfo(int Id)
        {
            var result = await _dataContext.CustomerInfo
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.CustomerInfo.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}