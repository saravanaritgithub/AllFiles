using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IInventoryServices
    {
        Task<IEnumerable<Inventory>> GetInventory();
        Task<Inventory> GetInventoryById(int inventoryId);
        Task<Inventory> AddInventory(Inventory inventory);
        Task<Inventory> UpdateInventory(Inventory inventory);
        Task DeleteInventory(int id);
    }
}
