using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductKart.Entity.Models;
using ProductKart.Entity.Models;

namespace ProductPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder<User> _user;
        private readonly IOrder<Product> _product;
        //private readonly IOrder<Cart> _cart;
        private readonly IOrder<CartItem> _cartItem;
        private readonly IOrder<Invoice> _inVoice;
        public OrderController(IOrder<User> user, IOrder<Product> product, IOrder<CartItem> cartItem, IOrder<Invoice> inVoice)
        {
            _user = user;
            _product = product;
            //_cart = cart;
            _cartItem = cartItem;
            _inVoice = inVoice;
        }

        // User
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _user.Get();
        }
        [HttpGet("GetUsersByID")]
        public async Task<User> GetUsersById(int id)
        {
            return await _user.GetById(id);
        }
        [HttpPost("AddUser")]
        public async Task<User> AddUser(User user)
        {
            User obj = new User();
            if (user != null)
            {
                obj = await _user.Add(user);
            }
            return obj;
        }
        [HttpPut("UpdateUser")]
        public async Task<User> UpdateUser(User user)
        {
            return await _user.Update(user);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_user != null)
            {
                await _user.Delete(id);
                return Ok();
            }
            return BadRequest();
        }

        // Product
        [HttpGet("GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _product.Get();
        }
        [HttpGet("GetUsersbyID")]
        public async Task<Product> GetProductsById(int id)
        {
            return await _product.GetById(id);
        }
        [HttpPost("AddProduct")]
        public async Task<Product> AddProducts(Product product)
        {
            Product obj = new Product();
            if (product != null)
            {
                obj = await _product.Add(product);
            }
            return obj;
        }
        [HttpPut("UpdateProduct")]
        public async Task<Product> UpdateProducts(Product product)
        {
            return await _product.Update(product);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            if (_product != null)
            {
                await _product.Delete(id);
                return Ok();
            }
            return BadRequest();
        }

      

        // Cart item
        [HttpGet("GetCartItems")]
        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            return await _cartItem.Get();
        }
        [HttpGet("GetCartItemsById")]
        public async Task<CartItem> GetCartItemsById(int id)
        {
            return await _cartItem.GetById(id);
        }
        [HttpPost("AddCartItems")]
        public async Task<CartItem> AddCartItems(CartItem cartItem)
        {
            CartItem obj = new CartItem();
            if (cartItem != null)
            {
                obj = await _cartItem.Add(cartItem);
            }
            return obj;
        }
        [HttpPut("UpdateCartItems")]
        public async Task<CartItem> UpdateCartItems(CartItem cartItem)
        {
            return await _cartItem.Update(cartItem);
        }
        [HttpDelete("DeleteCartItems")]
        public async Task<IActionResult> DeleteCartItems(int id)
        {
            if (_cartItem != null)
            {
                await _cartItem.Delete(id);
                return Ok();
            }
            return BadRequest();
        }

        // Invoice
        [HttpGet("GenerateInvoice")]
        public async Task<IEnumerable<Invoice>> GetInvoice()
        {
            return await _inVoice.Get();
        }      
    }
}
