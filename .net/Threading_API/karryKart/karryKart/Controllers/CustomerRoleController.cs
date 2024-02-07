using Contracts;
using Entities.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace KarryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRolesController : ControllerBase
    {
        private readonly ICustomerRoleService _customerRoleService;
        public CustomerRolesController(ICustomerRoleService customerRoleService)
        {
            _customerRoleService = customerRoleService;
        }
        [HttpGet("GetTax")]
        public async Task<IEnumerable<CustomerRole>> GetCustomerRoles()
        {
            var cus = await _customerRoleService.GetCustomerRole();
            return cus;
        }
        [HttpGet("GetTaxById")]
        public async Task<ActionResult<CustomerRole>> GetCustomerRoleById(int Id)
        {
            var cus = await _customerRoleService.GetCustomerRoleById(Id);

            return cus;
        }
        [HttpPost("CreateCustomerRole")]
        public async Task<ActionResult<CustomerRole>> CreateTax(CustomerRole customerRole)
        {
            CustomerRole OBJ = new CustomerRole();
            if (customerRole != null)
            {
                OBJ = await _customerRoleService.AddCustomerRole(customerRole);

            }
            return OBJ;
        }
        [HttpPut("UpdateCustomerRole")]
        public async Task<ActionResult<CustomerRole>> UpdateCategory(CustomerRole customerRole)
        {
            var update = await _customerRoleService.UpdateCustomerRole(customerRole);
            return update;
        }
        [HttpDelete("DeleteCustomerRole")]
        public async Task<IActionResult> CustomerRoleDelete(int Id)
        {
            await _customerRoleService.DeleteCustomerRole(Id);
            return NoContent();
        }
    }
}