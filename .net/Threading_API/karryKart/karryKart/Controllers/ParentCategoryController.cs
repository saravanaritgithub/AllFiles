using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace karryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentCategoryController : ControllerBase
    {
        private readonly IparentCategoryServices _ParentCategory;
        public ParentCategoryController(IparentCategoryServices Parent_Category)
        {
            _ParentCategory = Parent_Category;
        }

        [HttpGet("GetParentCategory")]
        public async Task<IEnumerable<ParentCategory>> GetParentCategory()
        {
            var player = await _ParentCategory.GetParentCategory();
            return player;
        }

        [HttpGet("GetParentCategoryById")]
        public async Task<ActionResult<ParentCategory>> GetParentCategoryById(int id)
        {
            var player = await _ParentCategory.GetParentCategoryById(id);
            return player;
        }

        [HttpPost("AddParentCategory")]
        public async Task<ActionResult<ParentCategory>> AddParentCategory(ParentCategory ParentCategory)
        {
            ParentCategory obj = new ParentCategory();
            if (ParentCategory != null)
            {
                obj = await _ParentCategory.AddParentCategory(ParentCategory);
            }
            return obj;
        }

        [HttpPut("updateParentCategory")]
        public async Task<ActionResult<ParentCategory>> updateParentCategory(ParentCategory ParentCategory)
        {
            var update = await _ParentCategory.updateParentCategory(ParentCategory);
            return update;
        }

        [HttpDelete("DeleteParentCategory")]
        public async Task<IActionResult> DeleteParentCategory(int id)
        {
            await _ParentCategory.DeleteParentCategory(id);
            return NoContent();
        }
        [HttpGet("GetParentCatbByName")]
        public async Task<ActionResult<IQueryable<ParentCategory>>> GetParentByName(string name)
        {
            var pro = await _ParentCategory.GetParentCategoryByName(name);
            return Ok(pro);
        }
    }
}
