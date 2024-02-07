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
    public class RecurringProductController : ControllerBase
    {
        private readonly IRecurringProductServices _RecurringProduct;
        public RecurringProductController(IRecurringProductServices Recurringproduct)
        {
            _RecurringProduct = Recurringproduct;
        }
        [HttpGet("GetRecurringProduct")]
        public async Task<IEnumerable<Recurring_Product>> GetRecurringProduct()
        {
            var category = await _RecurringProduct.GetRecurringProduct();
            return category;
        }
        [HttpGet("GetRecurringProductByID")]
        public async Task<ActionResult<Recurring_Product>> GetRecurringProductId(int id)
        {
            var manufracturer = await _RecurringProduct.GetRecurringProductById(id);
            return manufracturer;
        }
        [HttpPost("CreateRecurringProduct")]
        public async Task<ActionResult<Recurring_Product>> CreateRecurringProduct(Recurring_Product Recurringproduct)
        {
            Recurring_Product obj = new Recurring_Product();
            if (Recurringproduct != null)
            {
                obj = await _RecurringProduct.AddRecurringProduct(Recurringproduct);
            }
            return obj;
        }
        [HttpPut("UpdateRecurringproduct")]
        public async Task<ActionResult<Recurring_Product>> UpdateRecurringproduct(Recurring_Product Recurringproduct)
        {
            var update = await _RecurringProduct.UpdateRecurringProduct(Recurringproduct);
            return update;
        }

        [HttpDelete("DeleteRecurringproduct")]
        public async Task<IActionResult> DeleteRecurringproduct(int id)
        {
            await _RecurringProduct.DeleteRecurringProduct(id);
            return NoContent();
        }
    }
}
