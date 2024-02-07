using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace karryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _Product;
        public ProductController(IProductServices product)
        {
            _Product = product;
        }
        [HttpGet("GetProduct")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            var player = await _Product.GetProduct();
            return player;
        }
        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var player = await _Product.GetProductById(id);
            return player;
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            Product obj = new Product();
            if (product != null)
            {
                obj = await _Product.AddProduct(product);
            }
            return obj;
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<Product>> updateProduct(Product product)
        {
            var update = await _Product.updateProduct(product);
            return update;
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _Product.DeleteProduct(id);
            return NoContent();
        }
    }
}
