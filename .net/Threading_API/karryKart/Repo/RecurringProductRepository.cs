using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RecurringProductRepository : IRecurringProductServices
    {
        private readonly DataContext appDbContext;

        public RecurringProductRepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Recurring_Product>> GetRecurringProduct()
        {
            return await appDbContext.Recurring_Product.ToListAsync();
        }
        public async Task<Recurring_Product> GetRecurringProductById(int Id)
        {
            return await appDbContext.Recurring_Product
                .FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Recurring_Product> AddRecurringProduct(Recurring_Product recprod)
        {
            var result = await appDbContext.Recurring_Product.AddAsync(recprod);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Recurring_Product> UpdateRecurringProduct(Recurring_Product recprod)
        {
            var result = await appDbContext.Recurring_Product
                .FirstOrDefaultAsync(r => r.Id == recprod.Id);

            if (result != null)
            {
                result.Period = recprod.Period;
                result.Cycle_Length = recprod.Cycle_Length;
                result.Total_Cycle = recprod.Total_Cycle;
                result.CreatedAt = recprod.CreatedAt;
                result.CreatedBy = recprod.CreatedBy;
                result.ModifiedBy = recprod.ModifiedBy;
                result.ModifiedAt = recprod.ModifiedAt;
                result.IsDeleted = recprod.IsDeleted;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteRecurringProduct(int Id)
        {
            var result = await appDbContext.Recurring_Product
                 .FirstOrDefaultAsync(r => r.Id == Id);
            if (result != null)
            {
                appDbContext.Recurring_Product.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }
    }
}
