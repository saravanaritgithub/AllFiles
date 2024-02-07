using ConsoleToDB.Data;
using Contracts;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StockSubscriptionsRepository : IStockSubscriptions
    {
        private readonly DataContext _dataContext;
        public StockSubscriptionsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<StockSubscriptions>> GetStockSubscriptions()
        {
            return await _dataContext.StockSubscriptions.ToListAsync();
        }
        public async Task<StockSubscriptions> GetStockSubscriptionsId(int Id)
        {
            return await _dataContext.StockSubscriptions.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<StockSubscriptions> AddStockSubscriptions(StockSubscriptions stockSubscriptions)
        {
            var result = await _dataContext.StockSubscriptions.AddAsync(stockSubscriptions);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<StockSubscriptions> UpdateStockSubscriptions(StockSubscriptions stockSubscriptions)
        {
            var result = await _dataContext.StockSubscriptions
                .FirstOrDefaultAsync(e => e.Id == stockSubscriptions.Id);
            if (result != null)
            {
                result.StoreName = stockSubscriptions.StoreName;
                result.ProductId = stockSubscriptions.ProductId;
                result.Product = stockSubscriptions.Product;
                result.SubscribedOn = stockSubscriptions.SubscribedOn;
                result.CreatedAt = stockSubscriptions.CreatedAt;
                result.CreatedBy = stockSubscriptions.CreatedBy;
                result.ModifiedAt = stockSubscriptions.ModifiedAt;
                result.ModifiedBy = stockSubscriptions.ModifiedBy;
                result.IsDeleted = stockSubscriptions.IsDeleted;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteStockSubscriptions(int Id)
        {
            var result = await _dataContext.StockSubscriptions
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.StockSubscriptions.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}