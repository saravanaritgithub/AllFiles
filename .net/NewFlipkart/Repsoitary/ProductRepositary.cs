using ConsoleToDB.Data;
using Contracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Repository
{
    public class ProductRepositary : ProductServices
    {
        private readonly DataContext _context;
        public ProductRepositary(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Product> DeleteProduct(int Id)
        {
            var result = await _context.Product.FirstOrDefaultAsync(t => t.Id == Id);
            if (result != null)
            {
                _context.Product.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<Product> GetProductById(int Id)
        {
            return await _context.Product.FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _context.Product.FirstOrDefaultAsync(t => t.Id == product.Id);
            if (result != null)
            {

                result.ProductName = product.ProductName;
                result.ProductDescription = product.ProductDescription;
                result.ProductCategory = product.ProductCategory;
                result.Price = product.Price;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}