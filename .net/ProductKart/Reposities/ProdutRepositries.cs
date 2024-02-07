using Contracts;
using Microsoft.EntityFrameworkCore;
using ProductKart.Entity.Models;
using ProductKart.Entity.Data;
using ProductKart.Entity.Models;

namespace Repositories
{
    public class ProductPatternRepository : IOrder<User>, IOrder<Product>, IOrder<CartItem>, IOrder<Invoice>
    {
        private readonly DataContext _contextDB;
        public ProductPatternRepository(DataContext contextDB)
        {
            _contextDB = contextDB;
        }
        // User
        public async Task<IEnumerable<User>> Get()
        {
            return await _contextDB.User.ToListAsync();
        }
        public async Task<User> GetById(int userId)
        {
            return await _contextDB.User.FirstOrDefaultAsync(e => e.UserId == userId);
        }
        public async Task<User> Add(User user)
        {
            var addUser = await _contextDB.User.AddAsync(user);
            await _contextDB.SaveChangesAsync();
            return addUser.Entity;
        }
        public async Task<User> Update(User user)
        {
            var updateUser = await _contextDB.User.FirstOrDefaultAsync(e => e.UserId == user.UserId);

            if (updateUser != null)
            {
                updateUser.UserName = user.UserName;
                updateUser.Email = user.Email;
                updateUser.Address = user.Address;
                updateUser.Country = user.Country;
                updateUser.Phno = user.Phno;

                await _contextDB.SaveChangesAsync();
                return updateUser;
            }
            throw new NotImplementedException();
        }
        public async Task Delete(int Id)
        {
            var deleteUser = await _contextDB.User.FirstOrDefaultAsync(e => e.UserId == Id);
            if (deleteUser != null)
            {
                _contextDB.User.Remove(deleteUser);
                await _contextDB.SaveChangesAsync();
            }
        }
       // Products
        async Task<IEnumerable<Product>> IOrder<Product>.Get()
        {
            return await _contextDB.Products.ToListAsync();
        }
        async Task<Product> IOrder<Product>.GetById(int productId)
        {
            return await _contextDB.Products.FirstOrDefaultAsync(e => e.ProductId == productId);
        }
        public async Task<Product> Add(Product product)
        {
            var addProduct = await _contextDB.Products.AddAsync(product);
            await _contextDB.SaveChangesAsync();
            return addProduct.Entity;
        }
        public async Task<Product> Update(Product product)
        {
            var updateProduct = await _contextDB.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.ProductPrice = product.ProductPrice;
                updateProduct.AvaliableQuantity = product.AvaliableQuantity;

                await _contextDB.SaveChangesAsync();
                return updateProduct;
            }
            throw new Exception("Id not found");
        }
        async Task IOrder<Product>.Delete(int productId)
        {
            var deleteProduct = await _contextDB.Products.FirstOrDefaultAsync(e => e.ProductId == productId);
            if (deleteProduct != null)
            {
                _contextDB.Products.Remove(deleteProduct);
                await _contextDB.SaveChangesAsync();
            }
        }
        // Cart item
        async Task<IEnumerable<CartItem>> IOrder<CartItem>.Get()
        {
            return await _contextDB.CartItems.ToListAsync();
        }
        async Task<CartItem> IOrder<CartItem>.GetById(int cartId)
        {
            return await _contextDB.CartItems.FirstOrDefaultAsync(e => e.CartItemId == cartId);
        }
        public async Task<bool> FindResult(CartItem cartItem)
        {
            var product = await _contextDB.Products
                .FirstOrDefaultAsync(p => p.ProductId == cartItem.ProductId);

            if (product != null && product.AvaliableQuantity >= cartItem.Quantity)
            {
                product.AvaliableQuantity -= cartItem.Quantity;
                await _contextDB.SaveChangesAsync();

                return true;
            }
            return false;
        }
        public async Task<CartItem> UserTotalProductPrice(CartItem cartItem)
        {
            var product = await _contextDB.Products
                .FirstOrDefaultAsync(p => p.ProductId == cartItem.ProductId);
            if (product != null)
            {
                cartItem.Amount = product.ProductPrice;
                cartItem.TotalAmount = cartItem.Quantity * cartItem.Amount;
                await _contextDB.SaveChangesAsync();
                return cartItem;
            }
            return null;
        }
        public async Task<CartItem> Add(CartItem cartItem)
        {
            try
            {
                bool IsCheck = await FindResult(cartItem);
                if (IsCheck)
                {
                    CartItem cartItem1 = await UserTotalProductPrice(cartItem);
                    var addCartItem = await _contextDB.AddAsync(cartItem1);
                    await _contextDB.SaveChangesAsync();

                    return addCartItem.Entity;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }       
        public async Task<CartItem> Update(CartItem cartItem)
        {
            var updateCartItem = await _contextDB.CartItems.FirstOrDefaultAsync(e => e.CartItemId == cartItem.CartItemId);

            if (updateCartItem != null)
            {
                updateCartItem.Quantity = cartItem.Quantity;
                updateCartItem.Amount = cartItem.Amount;
                await _contextDB.SaveChangesAsync();
                return updateCartItem;
            }
            throw new Exception("CartItem not found");
        }
        async Task IOrder<CartItem>.Delete(int cartId)
        {
            var cartItemProduct = await _contextDB.CartItems.FirstOrDefaultAsync(e => e.CartItemId == cartId);
            if (cartItemProduct != null)
            {
                _contextDB.CartItems.Remove(cartItemProduct);
                await _contextDB.SaveChangesAsync();
            }
        }
        // Invoice
    }
}
