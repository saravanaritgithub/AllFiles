using Entities.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarryKart.CustomerControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineCustomerController : ControllerBase
    {
        private readonly IOnlineCustomerRepo _iOnlineCustomerRepository;
        public OnlineCustomerController(IOnlineCustomerRepo iOnlineCustomerRepository)
        {
            _iOnlineCustomerRepository = iOnlineCustomerRepository;
        }
        [HttpGet("GetOnlineCustomer")]
        public async Task<IEnumerable<OnlineCustomer>> GetOnlineCustomer()
        {
            var onlineCustomer = await _iOnlineCustomerRepository.GetOnlineCustomer();
            return onlineCustomer;
        }
        [HttpGet("GetOnlineCustomerbyId")]
        public async Task<ActionResult<OnlineCustomer>> GetOnlineCustomerbyId(int id)
        {
            var onlineCustomer = await _iOnlineCustomerRepository.GetOnlineCustomerbyId(id);
            return onlineCustomer;
        }

        [HttpPost("AddOnlineCustomer")]
        public async Task<ActionResult<OnlineCustomer>> AddOnlineCustomer(OnlineCustomer onlineCustomer)
        {
            OnlineCustomer Response = new OnlineCustomer();
            if (onlineCustomer != null)
            {
                onlineCustomer.Id = 0;
                Response = await _iOnlineCustomerRepository.AddOnlineCustomer(onlineCustomer);
            }

            return Response;
        }
        [HttpPut("UpdateOnlineCustomer/{id}")]
        public async Task<ActionResult<OnlineCustomer>> UpdateOnlineCustomer(OnlineCustomer onlineCustomer)
        {


            var update = await _iOnlineCustomerRepository.UpdateOnlineCustomer(onlineCustomer);


            return update;
        }
        [HttpDelete("DeleteOnlineCustomer/{id}")]
        public async Task<IActionResult> DeleteOnlineCustomer(int id)
        {


            await _iOnlineCustomerRepository.DeleteOnlineCustomer(id);
            return NoContent();
        }
    }
}