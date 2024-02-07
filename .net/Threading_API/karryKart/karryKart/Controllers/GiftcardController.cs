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
    public class GiftcardController : ControllerBase
    {
        private readonly IGiftCardServices _GFC;
        public GiftcardController(IGiftCardServices GC)
        {
            _GFC = GC;
        }
        [HttpGet("GetGiftCard")]
        public async Task<IEnumerable<GiftCard>> GetGiftCard()
        {
            var player = await _GFC.GetGiftCard();
            return player;
        }
        [HttpGet("GetGiftCardById")]
        public async Task<ActionResult<GiftCard>> GetGiftCardById(int id)
        {
            var player = await _GFC.GetGiftCardById(id);
            return player;
        }
        [HttpPost("AddGiftCard")]
        public async Task<ActionResult<GiftCard>> AddGiftCard(GiftCard GC)
        {
            GiftCard obj = new GiftCard();
            if (GC != null)
            {
                obj = await _GFC.AddGiftCard(GC);
            }
            return obj;
        }
        [HttpPut("UpdateGiftCard")]
        public async Task<ActionResult<GiftCard>> UpdateGiftCard(GiftCard GC)
        {
            var update = await _GFC.UpdateGiftCard(GC);
            return update;
        }
        [HttpDelete("DeleteGiftCard")]
        public async Task<IActionResult> DeleteGiftCard(int id)
        {
            await _GFC.DeleteGiftCard(id);
            return NoContent();
        }
    }
}
