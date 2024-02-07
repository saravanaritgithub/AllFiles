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
    public class CustomerInfoController : ControllerBase
    {

        private readonly ICustomerInfo _customerinfo;
        public CustomerInfoController(ICustomerInfo customerinfo)
        {
            _customerinfo = customerinfo;
        }
        [HttpGet("GetCustomerInfo")]
        public async Task<IEnumerable<CustomerInfo>> GetCustomerInfo()
        {
            var customerinfo = await _customerinfo.GetCustomerInfo();
            return customerinfo;
        }
        [HttpGet("GetCustomerInfoByID")]
        public async Task<ActionResult<CustomerInfo>> GetCustomerInfoId(int id)
        {
            var manufracturer = await _customerinfo.GetCustomerInfoId(id);
            return manufracturer;
        }
        [HttpPost("CreateCustomerInfo")]
        public async Task<ActionResult<CustomerInfo>> CreateCustomerInfo(CustomerInfo customerInfo)
        {
            CustomerInfo obj = new CustomerInfo();
            if (customerInfo != null)
            {
                obj = await _customerinfo.AddCustomerInfo(customerInfo);
            }
            return obj;
        }
        [HttpPut("UpdateCustomerInfo")]
        public async Task<ActionResult<CustomerInfo>> UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            var update = await _customerinfo.UpdateCustomerInfo(customerInfo);
            return update;
        }

        [HttpDelete("DeleteCustomerInfo")]
        public async Task<IActionResult> DeleteCustomerInfo(int id)
        {
            await _customerinfo.DeleteCustomerInfo(id);
            return NoContent();
        }
    }
}