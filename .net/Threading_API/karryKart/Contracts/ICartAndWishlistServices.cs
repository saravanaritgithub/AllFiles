using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICartAndWishlistServices
    {
        Task<IEnumerable<CartAndWishlist>> GetCartAndWishlists();
        Task<CartAndWishlist> GetCartAndWishlistId(int CWLId);
        Task<CartAndWishlist> AddCartAndWishlist(CartAndWishlist cartAndWishlist);
        Task<CartAndWishlist> UpdateCartAndWishlist(CartAndWishlist cartAndWishlist);
        Task<IQueryable<CartAndWishlist>> SearchyByValues(string name);
        Task DeleteCartAndWishlist(int CWLId);
    }
}
