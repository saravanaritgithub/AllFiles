using ProductKart.Entity.Models;

namespace Contracts
{
    public interface IOrder<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(T order);
        Task<T> Update(T order);
        Task Delete(int id);
    }
}
