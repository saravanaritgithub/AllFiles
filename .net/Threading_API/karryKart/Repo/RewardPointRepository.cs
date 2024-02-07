using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Entities.Models.Customers;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RewardPointRepository : IRewardPointservices
    {
        private readonly DataContext _dataContext;
        public RewardPointRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<RewardPoint>> GetRewardPoint()
        {
            return await _dataContext.RewardPoint.ToListAsync();
        }
        public Task<RewardPoint> GetRewardPointById(int rewardPointId)
        {
            return _dataContext.RewardPoint.FirstOrDefaultAsync(e => e.Id == rewardPointId);
        }
        public async Task<RewardPoint> AddRewardPoint(RewardPoint rewardPoint)
        {
            var result = await _dataContext.RewardPoint.AddAsync(rewardPoint);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<RewardPoint> UpdateRewardPoint(RewardPoint rewardPoint)
        {
            var result = await _dataContext.RewardPoint
                .FirstOrDefaultAsync(e => e.Id == rewardPoint.Id);

            if (result != null)
            {
                result.Id = rewardPoint.Id;
                result.Points = rewardPoint.Points;
                result.PointBalance = rewardPoint.PointBalance;
                result.Message = rewardPoint.Message;
                result.StartDate = rewardPoint.StartDate;
                result.EndDate = rewardPoint.EndDate;
                result.CreatedAt = rewardPoint.CreatedAt;
                result.CreatedBy = rewardPoint.CreatedBy;
                result.ModifiedAt = rewardPoint.ModifiedAt;
                result.ModifiedBy = rewardPoint.ModifiedBy;
                result.IsDeleted = rewardPoint.IsDeleted;
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteReward(int Id)
        {
            var result = await _dataContext.RewardPoint
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.RewardPoint.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
