using Contracts;
using Entities.Models;
using Entities.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace KarryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _iordersRepository;
        public OrdersController(IOrders iordersRepository)
        {
            _iordersRepository = iordersRepository;
        }
        [HttpGet("GetOrders")]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            var orders = await _iordersRepository.GetOrders();
            return orders;
        }
        [HttpGet("GetOrdersbyId")]
        public async Task<ActionResult<Orders>> GetOrdersbyId(int id)
        {
            var ord = await _iordersRepository.GetOrdersbyId(id);
            return ord;
        }
        [HttpGet("GetOrdersByName")]
        public async Task<ActionResult<IQueryable<Orders>>> GetOrdersByName(string name)
        {
            var orders1 = await _iordersRepository.GetOrdersByName(name);
            return Ok(orders1);
        }
        [HttpPost("AddOrders")]
        public async Task<ActionResult<Orders>> AddOrders(Orders orders)
        {
            Orders orderResponse = new Orders();
            if (orders != null)
            {
                orders.Id = 0;
                orderResponse = await _iordersRepository.AddOrders(orders);
            }

            return orderResponse;
        }
        [HttpPut("UpdateOrders/{id}")]
        public async Task<ActionResult<Orders>> UpdateOrders(int id, Orders orders)
        {


            var updateOrder = await _iordersRepository.UpdateOrders(orders);


            return updateOrder;
        }
        [HttpDelete("DeleteOrders/{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {


            await _iordersRepository.DeleteOrders(id);
            return NoContent();
        }
    }
}