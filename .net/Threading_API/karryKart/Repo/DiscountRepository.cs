using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entities.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DiscountRepository : IDiscountsServices
    {
        private readonly DataContext _dataContext;
        public DiscountRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _dataContext.Discount.ToListAsync();
        }
        public Task<Discount> GetDiscountsById(int discountsId)
        {
            return  _dataContext.Discount.FirstOrDefaultAsync(e => e.ID == discountsId);
        }
        public async Task<Discount> AddDiscounts(Discount discount)
        {
            var result = await _dataContext.Discount.AddAsync(discount);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<IQueryable<Discount>> GetDiscountByName(string name)
        {

            var query = from value in _dataContext.Discount
                        where value.Discount_Name == name || value.CreatedBy == name
                        select value;

            return query;
        }
        public async Task<Discount> UpdateDiscounts(Discount discount)
        {
            var result = await _dataContext.Discount
                .FirstOrDefaultAsync(e => e.ID == discount.ID);

            if (result != null)
            {
                result.Discount_Name = discount.Discount_Name;
                result.Discount_Percent = discount.Discount_Percent;
                result.Discount_Type = discount.Discount_Type;
                result.Start_Date = discount.Start_Date;
                result.End_Date = discount.End_Date;
                result.CreatedAt = discount.CreatedAt;
                result.CreatedBy = discount.CreatedBy;
                result.ModifiedAt = discount.ModifiedAt;
                result.ModifiedBy = discount.ModifiedBy;
                result.IsDeleted = discount.IsDeleted;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteDiscounts(int Id)
        {
            var result = await _dataContext.Discount
                .FirstOrDefaultAsync(e => e.ID == Id);
            if (result != null)
            {
                _dataContext.Discount.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
