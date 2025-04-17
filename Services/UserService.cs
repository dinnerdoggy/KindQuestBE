using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuestBE.Services
{
    public class UserService : IUserRepository
    {
        private readonly KindQuestDbContext _context;
        public UserService(KindQuestDbContext context) => _context = context;

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
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


