using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VendorRepository : IVendorsServices
    {
        private readonly DataContext _dataContext;
        public VendorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Vendors>> GetVendors()
        {
            return await _dataContext.Vendors.ToListAsync();
        }
        public async Task<Vendors> GetVendorsById(int Id)
        {
            return await _dataContext.Vendors.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Vendors> AddVendors(Vendors vendors)
        {
            var result = await _dataContext.Vendors.AddAsync(vendors);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Vendors> updateVendors(Vendors vendors)
        {
            var result = await _dataContext.Vendors
                .FirstOrDefaultAsync(e => e.Id == vendors.Id);

            if (result != null)
            {
                result.Name = vendors.Name;
                result.Description = vendors.Description;
                result.Email = vendors.Email;
                result.Company_name = vendors.Company_name;
                result.Country = vendors.Country;
                result.State = vendors.State;
                result.City = vendors.City;
                result.Address = vendors.Address;
                result.Zip = vendors.Zip;
                result.Phone_number = vendors.Phone_number;
                result.created_at = vendors.created_at;
                result.Created_By = vendors.Created_By;
                result.ModifiedAt = vendors.ModifiedAt;
                result.ModifiedBy = vendors.ModifiedBy;
                result.IsDeleted = vendors.IsDeleted;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteVendors(int Id)
        {
            var result = await _dataContext.Vendors
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.Vendors.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
