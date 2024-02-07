using Entity.Models;

namespace Contracts
{
    public interface UserServices
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> GetUserByID(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int Id);
    }
}
