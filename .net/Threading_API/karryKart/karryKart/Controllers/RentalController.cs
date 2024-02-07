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
    public class RentalController : ControllerBase
    {
            private readonly IRentalServices _Rental;
            public RentalController(IRentalServices rental)
            {
                _Rental = rental;
            }
            [HttpGet("GetRental")]
            public async Task<IEnumerable<Rental>> GetRental()
            {
                var Rental = await _Rental.GetRental();
                return Rental;
            }
            [HttpGet("GetRentalById")]
            public async Task<ActionResult<Rental>> GetRentalById(int Id)
            {
                var rental = await _Rental.GetRentalById(Id);
                return rental;
            }
            [HttpPost("AddRental")]
            public async Task<ActionResult<Rental>> AddRental(Rental rental)
            {
                Rental Response = new Rental();
                if (rental != null)
                {
                    rental.Id = 0;
                    Response = await _Rental.AddRental(rental);
                }

                return Response;
            }
            [HttpPut("UpdateRental/{id}")]
            public async Task<ActionResult<Rental>> UpdateRental(Rental rental)
            {
                var update = await _Rental.UpdateRental(rental);
                return update;
            }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _Rental.DeleteRental(id);
            return NoContent();
        }
    }
}
