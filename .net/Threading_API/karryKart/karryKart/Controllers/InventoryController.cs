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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _IR;
        public InventoryController(IInventoryServices irs)
        {
            _IR = irs;
        }
        [HttpGet(" GetInventory")]
        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            var Inventory = await _IR.GetInventory();
            return Inventory;
        }
        [HttpGet("GetInventoryById")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var Inventory = await _IR.GetInventoryById(id);
            return Inventory;
        }
        [HttpPost("AddInventory")]
        public async Task<ActionResult<Inventory>> AddInventory(Inventory irs)
        {
            Inventory Response = new Inventory();
            if (irs != null)
            {
                irs.Id = 0;
                Response = await _IR.AddInventory(irs);
            }
            return Response;
        }
        [HttpPut("UpdateInventory/{id}")]
        public async Task<ActionResult<Inventory>> UpdateInventory(Inventory irs)
        {
            var update = await _IR.UpdateInventory(irs);
            return update;
        }
        [HttpDelete("DeleteInventory/{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _IR.DeleteInventory(id);
            return NoContent();
        }
    }
}
