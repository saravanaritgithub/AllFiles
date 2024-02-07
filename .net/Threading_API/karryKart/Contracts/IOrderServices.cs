using Entities.Models;
using Entities.Models.Customers;
namespace Contracts
{
  public interface IOrders
    {
        Task<IEnumerable<Orders>> GetOrders();
        Task<Orders> GetOrdersbyId(int Id);
        Task<Orders> AddOrders(Orders orders);
        Task<Orders> UpdateOrders(Orders orders);
        Task<Orders> DeleteOrders(int Id);
        Task<IQueryable<Orders>> GetOrdersByName(string name);
    }
}