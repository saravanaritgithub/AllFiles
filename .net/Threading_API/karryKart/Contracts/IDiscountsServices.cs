using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDiscountsServices
    {
        Task<IEnumerable<Discount>> GetDiscounts();
        Task<Discount> GetDiscountsById(int discountsId);
        Task<Discount> AddDiscounts(Discount discounts);
        Task<Discount> UpdateDiscounts(Discount discounts);
        Task DeleteDiscounts(int id);
    }
}
