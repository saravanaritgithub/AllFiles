using Contracts;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace karryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SEOController : ControllerBase
    {
        private readonly ISEOServices _SEO;
        public SEOController(ISEOServices seo)
        {
            _SEO = seo;
        }
        [HttpGet("GetSEO")]
        public async Task<IEnumerable<SEO>> GetSEO()
        {
            var player = await _SEO.GetSEO();
            return player;
        }

        [HttpGet("GetSEOById")]
        public async Task<ActionResult<SEO>> GetSEOById(int id)
        {
            var player = await _SEO.GetSEOById(id);
            return player;
        }
        [HttpPost("AddSEO")]
        public async Task<ActionResult<SEO>> AddSEO(SEO seo)
        {
            SEO obj = new SEO();
            if (seo != null)
            {
                obj = await _SEO.AddSEO(seo);
            }
            return obj;
        }
        [HttpPut("UpdateSEO")]
        public async Task<ActionResult<SEO>> UpdateSEO(SEO seo)
        {
            var update = await _SEO.UpdateSEO(seo);
            return update;
        }
        [HttpDelete("DeleteSEO")]
        public async Task<IActionResult> DeleteSEO(int seoid)
        {
            await _SEO.DeleteSEO(seoid);
            return NoContent();
        }
    }
}