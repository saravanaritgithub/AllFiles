using Contracts;
using Entites.Models;
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
    public class RewardPointController : ControllerBase
    {
        private readonly IRewardPointservices _Rwp;
        public RewardPointController(IRewardPointservices RewardPoint)
        {
            _Rwp = RewardPoint;
        }
        [HttpGet("GetRewardPoint")]
        public async Task<IEnumerable<RewardPoint>> GetRewardPoint()
        {
            var rwps = await _Rwp.GetRewardPoint();
            return rwps;
        }
        [HttpGet("GetRewardPointByID")]
        public async Task<ActionResult<RewardPoint>> GetRewardPointById(int id)
        {
            var rwps = await _Rwp.GetRewardPointById(id);
            return rwps;
        }
        [HttpPost("AddRewardPoint")]
        public async Task<ActionResult<RewardPoint>> AddRewardPoint(RewardPoint rwp)
        {
            RewardPoint obj = new RewardPoint();
            if (rwp != null)
            {
                obj = await _Rwp.AddRewardPoint(rwp);
            }
            return obj;
        }
        [HttpPut("UpdateRewardPoint")]
        public async Task<ActionResult<RewardPoint>> UpdateRewardPoint(RewardPoint rwp)
        {
            var update = await _Rwp.AddRewardPoint(rwp);
            return update;
        }
        [HttpDelete("DeleteRewardPoint")]
        public async Task<IActionResult> DeleteReward(int id)
        {
            await _Rwp.DeleteReward(id);
            return NoContent();
        }
    }
}
