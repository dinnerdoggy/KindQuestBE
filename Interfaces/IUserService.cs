using KindQuest.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KindQuest.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int Id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
