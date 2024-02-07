using Entities.Models.Customers;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{       
    public interface IStockSubscriptions
    {
            Task<IEnumerable<StockSubscriptions>> GetStockSubscriptions();
            Task<StockSubscriptions> GetStockSubscriptionsId(int stockSubscriptionsId);
            Task<StockSubscriptions> AddStockSubscriptions(StockSubscriptions stockSubscriptions);
            Task<StockSubscriptions> UpdateStockSubscriptions(StockSubscriptions stockSubscriptions);
            Task DeleteStockSubscriptions(int stockSubscriptionsId);
    }
}

