using Contracts;
using Entites.Models;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _catg;
        public CategoryController(ICategoryServices category)
        {
            _catg = category;
        }
        [HttpGet("GetCategory")]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            var category = await _catg.GetCategory();
            return category;
        }
        [HttpGet("GetCategoryByID")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var manufracturer = await _catg.GetCategoryById(id);
            return manufracturer;
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            Category obj = new Category();
            if (category != null)
            {
                obj = await _catg.AddCategory(category);
            }
            return obj;
        }
        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            var update = await _catg.UpdateCategory(category);
            return update;
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _catg.DeleteCategory(id);
            return NoContent();
        }
    }
}