using Contracts;
using Microsoft.EntityFrameworkCore;
using NewProducts.Entity.Data;
using NewProducts.Entity.Models;

namespace Repositories
{
    public class ProductPatternRepository : IOrder<User>, IOrder<Product>, IOrder<CartItem>, IOrder<Invoice>
    {
        private readonly ProductContext _contextDB;
        public ProductPatternRepository(ProductContext contextDB)
        {
            _contextDB = contextDB;
        }
        //User
        public async Task<IEnumerable<User>> Get()
        {
            return await _contextDB.UserTable.ToListAsync();
        }
        public async Task<User> GetById(int userId)
        {
            return await _contextDB.UserTable.FirstOrDefaultAsync(e => e.Id == userId);
        }
        public async Task<User> Add(User user)
        {
            var addUser = await _contextDB.UserTable.AddAsync(user);
            await _contextDB.SaveChangesAsync();
            return addUser.Entity;
        }
        public async Task<User> Update(User user)
        {
            var updateUser = await _contextDB.UserTable.FirstOrDefaultAsync(e => e.Id == user.Id);

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
            var deleteUser = await _contextDB.UserTable.FirstOrDefaultAsync(e => e.Id == Id);
            if (deleteUser != null)
            {
                _contextDB.UserTable.Remove(deleteUser);
                await _contextDB.SaveChangesAsync();
            }
        }
        //Product
        async Task<IEnumerable<Product>> IOrder<Product>.Get()
        {
            return await _contextDB.Products.ToListAsync();
        }
        async Task<Product> IOrder<Product>.GetById(int productId)
        {
            return await _contextDB.Products.FirstOrDefaultAsync(e => e.Id == productId);
        }
        public async Task<Product> Add(Product product)
        {
            var addProduct = await _contextDB.Products.AddAsync(product);
            await _contextDB.SaveChangesAsync();
            return addProduct.Entity;
        }
        public async Task<Product> Update(Product product)
        {
            var updateProduct = await _contextDB.Products.FirstOrDefaultAsync(e => e.Id == product.Id);
            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.SellingPrice = product.SellingPrice;
                updateProduct.AvailableQuantity = product.AvailableQuantity;
                await _contextDB.SaveChangesAsync();
                return updateProduct;
            }
            throw new Exception("Id not found");
        }
        async Task IOrder<Product>.Delete(int productId)
        {
            var deleteProduct = await _contextDB.Products.FirstOrDefaultAsync(e => e.Id == productId);
            if (deleteProduct != null)
            {
                _contextDB.Products.Remove(deleteProduct);
                await _contextDB.SaveChangesAsync();
            }
        }
        //CartItem
        async Task<IEnumerable<CartItem>> IOrder<CartItem>.Get()
        {
            return await _contextDB.CartItem.ToListAsync();
        }
        async Task<CartItem> IOrder<CartItem>.GetById(int cartId)
        {
            return await _contextDB.CartItem.FirstOrDefaultAsync(e => e.Id == cartId);
        }
        public async Task<CartItem> Add(CartItem cartItem)
        {
            var addProduct = await _contextDB.CartItem.AddAsync(cartItem);
            await _contextDB.SaveChangesAsync();
            return addProduct.Entity;
        }
        public async Task<CartItem> Update(CartItem cartItem)
        {
            var updateCartItem = await _contextDB.CartItem.FirstOrDefaultAsync(e => e.Id == cartItem.Id);
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
            var cartItemProduct = await _contextDB.CartItem.FirstOrDefaultAsync(e => e.Id == cartId);
            if (cartItemProduct != null)
            {
                _contextDB.CartItem.Remove(cartItemProduct);
                await _contextDB.SaveChangesAsync();
            }
        }
        //Invoice
        async Task<IEnumerable<Invoice>> IOrder<Invoice>.Get()
        {
            return await _contextDB.Invoice.ToListAsync();
        }
        async Task<Invoice> IOrder<Invoice>.GetById(int id)
        {
            return await _contextDB.Invoice.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Invoice> Add(Invoice order)
        {
            var addInvoice = await _contextDB.Invoice.AddAsync(order);
            await _contextDB.SaveChangesAsync();
            return addInvoice.Entity;
        }
        public async Task<Invoice> Update(Invoice invoice)
        {
            var updateInvoice = await _contextDB.Invoice.FirstOrDefaultAsync(i => i.Id == invoice.Id);
            if (updateInvoice != null)
            {
                updateInvoice.GrandTotal = invoice.GrandTotal;
                var CartItem = await _contextDB.CartItem.FirstOrDefaultAsync(c => c.Id == invoice.CartItemId);
                if (CartItem != null)
                {
                    var product = await _contextDB.Products.FirstOrDefaultAsync(p => p.Id == CartItem.ProductId);
                    updateInvoice.GrandTotal = (double)(CartItem.Quantity * product.SellingPrice);
                }
                await _contextDB.SaveChangesAsync();
                return updateInvoice;
            }
            throw new Exception("Invoice Id not found");
        }
        async Task IOrder<Invoice>.Delete(int cartId)
        {
            var deleteInvoice = await _contextDB.Invoice.FirstOrDefaultAsync(e => e.Id == cartId);
            if (deleteInvoice != null)
            {
                _contextDB.Invoice.Remove(deleteInvoice);
                await _contextDB.SaveChangesAsync();
            }
        }
    }
}
