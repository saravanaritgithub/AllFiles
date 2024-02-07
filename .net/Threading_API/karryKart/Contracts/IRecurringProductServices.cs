using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRecurringProductServices
    {
        Task<IEnumerable<Recurring_Product>> GetRecurringProduct();
        Task<Recurring_Product> GetRecurringProductById(int inventoryId);
        Task<Recurring_Product> AddRecurringProduct(Recurring_Product recurringproduct);
        Task<Recurring_Product> UpdateRecurringProduct(Recurring_Product recurringproduct);
        Task DeleteRecurringProduct(int id);
    }
}
