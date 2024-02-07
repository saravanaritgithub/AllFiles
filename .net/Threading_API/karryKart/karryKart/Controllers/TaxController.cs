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
    public class TaxController : ControllerBase
    {
        private readonly ITaxServices _Tax;
        public TaxController(ITaxServices tax)
        {
            _Tax = tax;
        }
        [HttpGet("GetTax")]
        public async Task<IEnumerable<Tax>> GetTax()
        {
            var player = await _Tax.GetTax();
            return player;
        }
        [HttpGet("GetTaxById")]
        public async Task<ActionResult<Tax>> GetTaxById(int id)
        {
            var player = await _Tax.GetTaxById(id);
            return player;
        }
        [HttpPost("AddTax")]
        public async Task<ActionResult<Tax>> AddTax(Tax tax)
        {
            Tax obj = new Tax();
            if (tax != null)
            {
                obj = await _Tax.AddTax(tax);
            }
            return obj;
        }
        [HttpPut("UpdateTax")]
        public async Task<ActionResult<Tax>> UpdateTax(Tax tax)
        {
            var update = await _Tax.updateTax(tax);
            return update;
        }
        [HttpDelete("DeleteTax")]
        public async Task<IActionResult> DeleteTax(int id)
        {
            await _Tax.DeleteTax(id);
            return NoContent();
        }
    }
}
