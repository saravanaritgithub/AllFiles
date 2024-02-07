using Contracts;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleToDB.Data;
using Entites.Models;

namespace Repository
{

    public class InventoryRepository : IInventoryServices
    {
        private readonly DataContext appDbContext;

        public InventoryRepository(DataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            return await appDbContext.Inventory.ToListAsync();
        }

        public async Task<Inventory> GetInventoryById(int Id)
        {
            return await appDbContext.Inventory
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            var result = await appDbContext.Inventory.AddAsync(inventory);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Inventory> UpdateInventory(Inventory inventory)
        {
            var result = await appDbContext.Inventory
                .FirstOrDefaultAsync(p => p.Id == inventory.Id);

            if (result != null)
            {

                result.warehouse = inventory.warehouse;
                result.Stockquantity = inventory.Stockquantity;
                result.Allowedquantities = inventory.Allowedquantities;
                result.CreatedAt = inventory.CreatedAt;


                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Inventory> DeleteInventory(int Id)
        {
            var result = await appDbContext.Inventory
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                appDbContext.Inventory.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
            return result;

        }
        Task IInventoryServices.DeleteInventory(int id)
        {
            throw new NotImplementedException();
        }
    }
}