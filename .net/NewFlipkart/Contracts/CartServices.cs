using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface CartServices
    {
        Task<IEnumerable<Cart>> GetCart();
        Task<Cart> GetCartById(int id);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(Cart cart);
        Task DeleteCart(int id);
    }
}
