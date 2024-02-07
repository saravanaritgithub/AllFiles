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
    public class VendorsController : ControllerBase
    {
        private readonly IVendorsServices _Vendors;
        public VendorsController(IVendorsServices vendors)
        {
            _Vendors = vendors;
        }
        [HttpGet("GetVendors")]
        public async Task<IEnumerable<Vendors>> GetVendors()
        {
            var player = await _Vendors.GetVendors();
            return player;
        }
        [HttpGet("GetVendorsById")]
        public async Task<ActionResult<Vendors>> GetVendorsById(int id)
        {
            var player = await _Vendors.GetVendorsById(id);
            return player;
        }
        [HttpPost("AddVendors")]
        public async Task<ActionResult<Vendors>> AddVendors(Vendors vendors)
        {
            Vendors obj = new Vendors();
            if (vendors != null)
            {
                obj = await _Vendors.AddVendors(vendors);
            }
            return obj;
        }
        [HttpPut("UpdateVendors")]
        public async Task<ActionResult<Vendors>> updateVendors(Vendors vendors)
        {
            var update = await _Vendors.updateVendors(vendors);
            return update;
        }
        [HttpDelete("DeleteVendors")]
        public async Task<IActionResult> DeleteVendors(int id)
        {
            await _Vendors.DeleteVendors(id);
            return NoContent();
        }
    }
}
