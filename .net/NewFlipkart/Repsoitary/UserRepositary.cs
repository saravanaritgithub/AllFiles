using ConsoleToDB.Data;
using Contracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;

namespace Repsoitary
{
    public class UserRepositary: UserServices
    {
        private readonly DataContext _context;
        public UserRepositary(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> AddUser(User User)
        {
            var result= await _context.User.AddAsync(User);
                await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<User> DeleteUser(int Id)
        {
            var result = await _context.User.FirstOrDefaultAsync(t => t.Id == Id);
            if (result != null)
            {
                _context.User.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<User> GetUserByID(int Id)
        {
            return await _context.User.FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<User> UpdateUser(User User)
        {
            var result = await _context.User.FirstOrDefaultAsync(t => t.Id == address.Id);
            if (result != null)
            {
                result.PhoneNumber = User.UserName;
                result.Email = User.UserEmail;
                result.FaxNumber = User.Password;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
