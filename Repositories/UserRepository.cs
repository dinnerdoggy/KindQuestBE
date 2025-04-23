using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KindQuestDbContext _context;
        public UserRepository(KindQuestDbContext context) => _context = context;
       
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return (User)Results.BadRequest("User Id not found");
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return (User)Results.BadRequest("User not found");
            }
            return user;
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
                return (User)Results.BadRequest("User not found");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.EmergencyContact = user.EmergencyContact;
            existingUser.ProfilePic = user.ProfilePic;
            existingUser.CreatedProjects = user.CreatedProjects;
            existingUser.VolunteeredProjects = user.VolunteeredProjects;
            existingUser.Jobs = user.Jobs;

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
