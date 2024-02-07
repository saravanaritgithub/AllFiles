using Entities.Models.Customers;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace karryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo _iAddressRepository;
        public AddressController(IAddressRepo iAddressRepository)
        {
            _iAddressRepository = iAddressRepository;
        }
        [HttpGet("GetAddress")]
        public async Task<IEnumerable<Address>> GetAddress()
        {
            var address = await _iAddressRepository.GetAddress();
            return address;
        }
        [HttpGet("GetaddressbyId")]
        public async Task<ActionResult<Address>> GetAddressbyId(int id)
        {
            var address = await _iAddressRepository.GetAddressbyId(id);
            return address;
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult<Address>> AddAddress(Address address)
        {
            Address Response = new Address();
            if (address != null)
            {
                address.Id = 0;
                Response = await _iAddressRepository.AddAddress(address);
            }
            return Response;
        }
        [HttpPut("UpdateAddress/{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(Address address)
        {


            var update = await _iAddressRepository.UpdateAddress(address);


            return update;
        }
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {


            await _iAddressRepository.DeleteAddress(id);
            return NoContent();
        }
    }
}
