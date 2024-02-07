using ConsoleToDB.Data;
using Contracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CartAndWishlistRepository : ICartAndWishlistServices
    {
        private readonly DataContext _dataContext;
        public CartAndWishlistRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<CartAndWishlist> AddCartAndWishlist(CartAndWishlist cartAndWishlist)
        {
            var result = await _dataContext.CartAndWishlist.AddAsync(cartAndWishlist);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCartAndWishlist(int CWLId)
        {
            var result = await _dataContext.CartAndWishlist
                            .FirstOrDefaultAsync(e => e.Id == CWLId);
            if (result != null)
            {
                _dataContext.CartAndWishlist.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<CartAndWishlist> GetCartAndWishlistId(int CWLId)
        {
            return await _dataContext.CartAndWishlist.FirstOrDefaultAsync(e => e.Id == CWLId);
        }

        public async Task<IEnumerable<CartAndWishlist>> GetCartAndWishlists()
        {
            return await _dataContext.CartAndWishlist.ToListAsync();
        }

        public async Task<IQueryable<CartAndWishlist>> SearchyByValues(string name)
        {
            var result = from value in _dataContext.CartAndWishlist
                         where value.Name == name
                         select value;
            return result;
        }

        public async Task<CartAndWishlist> UpdateCartAndWishlist(CartAndWishlist cartAndWishlist)
        {
            var result = await _dataContext.CartAndWishlist
                .FirstOrDefaultAsync(e => e.Id == cartAndWishlist.Id);

            if (result != null)
            {
                result.shoppingCartTypeEnum = cartAndWishlist.shoppingCartTypeEnum;
                result.Name = cartAndWishlist.Name;
                result.Quantity = cartAndWishlist.Quantity;
                result.UnitPrice = cartAndWishlist.UnitPrice;
                result.TotalPrice = cartAndWishlist.TotalPrice;
                result.StoreName = cartAndWishlist.StoreName;
                result.UpdatedOn = cartAndWishlist.UpdatedOn;
                result.ModifiedAt = cartAndWishlist.ModifiedAt;
                result.ModifiedBy = cartAndWishlist.ModifiedBy;
                result.IsDeleted = cartAndWishlist.IsDeleted;

                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}