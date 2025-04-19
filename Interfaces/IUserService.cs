using KindQuest.Models;

namespace KindQuest.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUidAsync(string uid);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<Project>> GetVolunteeredProjectsAsync(int userId);
        Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId);
    }
}
