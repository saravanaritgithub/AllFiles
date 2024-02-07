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
    public class DownloadableProductController : ControllerBase
    {
        private readonly IDownloadableProductServices _Dwnpc;
        public DownloadableProductController(IDownloadableProductServices Dpc)
        {
            _Dwnpc = Dpc;
        }
        [HttpGet("GetDownloadableProduct")]
        public async Task<IEnumerable<DownloadableProduct>> GetDownloadableProduct()
        {
            var player = await _Dwnpc.GetDownloadableProduct();
            return player;
        }
        [HttpGet("GetDownloadableProductById")]
        public async Task<ActionResult<DownloadableProduct>> GetDownloadableProductById(int id)
        {
            var player = await _Dwnpc.GetDownloadableProductById(id);
            return player;
        }
        [HttpPost("AddDownloadableProduct")]
        public async Task<ActionResult<DownloadableProduct>> AddDownloadableProduct(DownloadableProduct Dpc)
        {
            DownloadableProduct obj = new DownloadableProduct();
            if (Dpc != null)
            {
                obj = await _Dwnpc.AddDownloadableProduct(Dpc);
            }
            return obj;
        }
        [HttpPut("UpdateDownloadableProduct")]
        public async Task<ActionResult<DownloadableProduct>> UpdateCategory(DownloadableProduct Dpc)
        {
            var update = await _Dwnpc.UpdateDownloadableProduct(Dpc);
            return update;
        }
        [HttpDelete("DeleteDownloadableProduct")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _Dwnpc.DeleteDownloadableProduct(id);
            return NoContent();
        }
    }
}
