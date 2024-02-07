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
    public class ShippingController : ControllerBase
    { 
        private readonly IShippingServices _shipping;
        public ShippingController(IShippingServices shipping)
        {
            _shipping = shipping;
        }
        [HttpGet("GetShipping")]
        public async Task<IEnumerable<Shipping>> GetShipping()
        {
            var player = await _shipping.GetShipping();
            return player;
        }
        [HttpGet("GetShippingById")]
        public async Task<ActionResult<Shipping>> GetShippingById(int id)
        {
            var player = await _shipping.GetShippingById(id);
            return player;
        }
        [HttpPost("AddShipping")]
        public async Task<ActionResult<Shipping>> AddShipping(Shipping shipping)
        {
            Shipping obj = new Shipping();
            if (shipping != null)
            {
                obj = await _shipping.AddShipping(shipping);
            }
            return obj;
        }
        [HttpPut("UpdateShipping")]
        public async Task<ActionResult<Shipping>> UpdateShipping(Shipping shipping)
        {
            var update = await _shipping.UpdateShipping(shipping);
            return update;
        }
        [HttpDelete("DeleteShipping")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            await _shipping.DeleteShipping(id);
            return NoContent();
        }
    }
}
