using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Services
{
    public class UserService : IUserRepository
    {
        private readonly KindQuestDbContext _context;
        public UserService(KindQuestDbContext context) => _context = context;

        public async Task<User> GetUserByIdAsync(int id)
        {
           if (id <= 0)
            {
                return (User)Results.BadRequest("User Id Not Found");
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return (User)Results.BadRequest("User Not Found");
            }
            return user;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return (User)Results.BadRequest("User Not Found");
            }
            existingUser.FirstName = user.LastName;
            existingUser.Email = user.Email;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


