using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;

namespace KindQuest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KindQuestDbContext _context;
        public UserRepository(KindQuestDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }
        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
