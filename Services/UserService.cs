using KindQuest.Models;
using KindQuest.Interfaces;

namespace KindQuest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<User?> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
            throw new ArgumentException("Invalid User Id", nameof(id));
            }
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                throw new InvalidOperationException("No Users Found");
            }
            return users;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Created User cannot be null");
            }
            var createdUser = await _userRepository.CreateUserAsync(user);
            if (createdUser == null)
            {
                return (User)Results.BadRequest("User Not Created");
            }
            return createdUser;
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid User Id", nameof(id));
            }
            if (user == null || user.Id <= 0)
            {
                throw new ArgumentNullException("Invalid User data", nameof(user));
            }
            var updatedUser = await _userRepository.UpdateUserAsync(user.Id, user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("User could not be updated");
            }
            return updatedUser;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid User Id");
            }

            var deleted = await _userRepository.DeleteUserAsync(id);
            if (!deleted)
            {
                throw new InvalidOperationException("User could not be deleted");
            }

            return deleted;
        }
    }
}
