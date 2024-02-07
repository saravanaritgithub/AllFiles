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
    public class MaufacturerController : ControllerBase
    {
        private readonly IManufacturerServices _MC;
        public MaufacturerController(IManufacturerServices mc)
        {
            _MC = mc;
        }
        [HttpGet("GetManufacturer")]
        public async Task<IEnumerable<Manufacturer>> GetManufacturer()
        {
            var player = await _MC.GetManufacturer();
            return player;
        }
        [HttpGet("GetManufacturerById")]
        public async Task<ActionResult<Manufacturer>> GetManufacturerById(int id)
        {
            var player = await _MC.GetManufacturerById(id);
            return player;
        }
        [HttpPost("AddManufacturer")]
        public async Task<ActionResult<Manufacturer>> AddManufacturer(Manufacturer mc)
        {
            Manufacturer obj = new Manufacturer();
            if (mc != null)
            {
                obj = await _MC.AddManufacturer(mc);
            }
            return obj;
        }
        [HttpPut("UpdateManufacturer")]
        public async Task<ActionResult<Manufacturer>> UpdateManufacturer(Manufacturer mc)
        {
            var update = await _MC.UpdateManufacturer(mc);
            return update;
        }
        [HttpDelete("DeleteManufacturer")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            await _MC.DeleteManufacturer(id);
            return NoContent();
        }
    }
}
