using Entites.Models;
using Entities.Models.Customers;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRewardPointservices
    {
        Task<IEnumerable<RewardPoint>> GetRewardPoint();
        Task<RewardPoint> GetRewardPointById(int rewardPointId);
        Task<RewardPoint> AddRewardPoint(RewardPoint rewardPoint);
        Task<RewardPoint> UpdateRewardPoint(RewardPoint rewardPoint);
        Task DeleteReward(int id);
    }
}
