using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductById(int productId);
        Task<Product> AddProduct(Product product);
        Task<Product> updateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
