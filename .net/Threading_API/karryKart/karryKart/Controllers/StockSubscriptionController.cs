using Contracts;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockSubscriptionsController : ControllerBase
    {
        private readonly IStockSubscriptions _stockSubscriptions;
        public StockSubscriptionsController(IStockSubscriptions stockSubscriptions)
        {
            _stockSubscriptions = stockSubscriptions;
        }
        [HttpGet("GetStockSubscriptions")]
        public async Task<IEnumerable<StockSubscriptions>> GetStockSubscriptions()
        {
            var category = await _stockSubscriptions.GetStockSubscriptions();
            return category;
        }
        [HttpGet("GetStockSubscriptionsByID")]
        public async Task<ActionResult<StockSubscriptions>> GetStockSubscriptionsId(int id)
        {
            var manufracturer = await _stockSubscriptions.GetStockSubscriptionsId(id);
            return manufracturer;
        }
        [HttpPost("CreateCStockSubscriptions")]
        public async Task<ActionResult<StockSubscriptions>> CreateStockSubscriptions(StockSubscriptions stockSubscriptions)
        {
            StockSubscriptions obj = new StockSubscriptions();
            if (stockSubscriptions != null)
            {
                obj = await _stockSubscriptions.AddStockSubscriptions(stockSubscriptions);
            }
            return obj;
        }
        [HttpPut("UpdateStockSubscriptions")]
        public async Task<ActionResult<StockSubscriptions>> UpdateStockSubscriptions(StockSubscriptions stockSubscriptions)
        {
            var update = await _stockSubscriptions.UpdateStockSubscriptions(stockSubscriptions);
            return update;
        }

        [HttpDelete("DeleteStockSubscriptions")]
        public async Task<IActionResult> DeleteStockSubscriptions(int id)
        {
            await _stockSubscriptions.DeleteStockSubscriptions(id);
            return NoContent();
        }
    }
}