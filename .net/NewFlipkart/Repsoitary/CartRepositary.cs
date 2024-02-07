using ConsoleToDB.Data;
using Contracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Repository
{
    public class CartRepositary : CartServices
    {
        private readonly DataContext _context;
        public CartRepositary(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cart>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }
        public async Task<Cart> AddCart(Cart cart)
        {
            var result = await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Cart> DeleteCart(int Id)
        {
            var result = await _context.Cart.FirstOrDefaultAsync(t => t.CartId == Id);
            if (result != null)
            {
                _context.Cart.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<Cart> GetCartById(int Id)
        {
            return await _context.Cart.FirstOrDefaultAsync(t => t.CartId == Id);
        }
        public async Task<Cart> UpdateCart(Cart cart)
        {
            var result = await _context.Cart.FirstOrDefaultAsync(t => t.CartId == cart.CartId);
            if (result != null)
            {

                result.CartId = cart.CartId;
                result.Quantity = cart.Quantity;
                result.amount = cart.amount;
                result.ProductId = cart.ProductId;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        Task CartServices.DeleteCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}