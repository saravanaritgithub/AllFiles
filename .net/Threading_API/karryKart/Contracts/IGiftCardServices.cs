using Entites.Models;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGiftCardServices
    {
        Task<IEnumerable<GiftCard>> GetGiftCard();
        Task<GiftCard> GetGiftCardById(int giftcardId);
        Task<GiftCard> AddGiftCard(GiftCard giftcard);
        Task<GiftCard> UpdateGiftCard(GiftCard giftcard);
        Task DeleteGiftCard(int id);
    }
}
