using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KindQuestDbContext _context;
        public UserRepository(KindQuestDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task<User> UpdateUserAsync(int id, User user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
