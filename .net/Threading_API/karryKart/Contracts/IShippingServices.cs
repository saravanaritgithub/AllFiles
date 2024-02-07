using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShippingServices
    {
        Task<IEnumerable<Shipping>> GetShipping();
        Task<Shipping> GetShippingById(int inventoryId);
        Task<Shipping> AddShipping(Shipping shipping);
        Task<Shipping> UpdateShipping(Shipping shipping);
        Task DeleteShipping(int id);
    }
}
