using ConsoleToDB.Data;
using Contracts;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GiftCardRepository : IGiftCardServices
    {
        private readonly DataContext _dataContext;
        public GiftCardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<GiftCard>> GetGiftCard()
        {
            return await _dataContext.GiftCard.ToListAsync();
        }
        public async Task<GiftCard> GetGiftCardById(int Id)
        {
            return await _dataContext.GiftCard.FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<GiftCard> AddGiftCard(GiftCard giftcard)
        {
            var result = await _dataContext.GiftCard.AddAsync(giftcard);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<GiftCard> UpdateGiftCard(GiftCard giftcard)
        {
            var result = await _dataContext.GiftCard
                .FirstOrDefaultAsync(e => e.Id == giftcard.Id);

            if (result != null)
            {
                result.Giftcard = giftcard.Giftcard;
                result.giftcardtype = giftcard.giftcardtype;
                result.Overriddengiftcardamount = giftcard.Overriddengiftcardamount;
                result.CreatedAt = giftcard.CreatedAt;
                result.CreatedBy = giftcard.CreatedBy;
                result.ModifiedAt = giftcard.ModifiedAt;
                result.ModifiedBy = giftcard.ModifiedBy;
                result.IsDeleted = giftcard.IsDeleted;


                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteGiftCard(int Id)
        {
            var result = await _dataContext.GiftCard
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _dataContext.GiftCard.Remove(result);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
