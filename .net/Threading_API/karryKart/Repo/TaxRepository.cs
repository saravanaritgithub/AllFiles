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
    public class TaxRepository : ITaxServices
    {
        private readonly DataContext _dataContext;
        public TaxRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Tax>> GetTax()
        {
            return await _dataContext.Tax.ToListAsync();
        }
        public async Task<Tax> GetTaxById(int Id)
        {
            return await _dataContext.Tax.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Tax> AddTax(Tax tax)
        {
            var result = await _dataContext.Tax.AddAsync(tax);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Tax> updateTax(Tax tax)
        {
            var result = await _dataContext.Tax
                .FirstOrDefaultAsync(e => e.Id == tax.Id);

            if (result != null)
            {
                result.TaxCode = tax.TaxCode;
                result.SGSTPercentage = tax.SGSTPercentage;
                result.CGSTPercentage = tax.CGSTPercentage;
                result.created_at = tax.created_at;
                result.Created_By = tax.Created_By;
                result.ModifiedAt = tax.ModifiedAt;
                result.ModifiedBy = tax.ModifiedBy;
                result.IsDeleted = tax.IsDeleted;


                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteTax(int Id)
        {
            var result = await _dataContext.Tax
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.Tax.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
        public Task<Tax> DeleteTax(Tax tax)
        {
            throw new NotImplementedException();
        }
    }
}
