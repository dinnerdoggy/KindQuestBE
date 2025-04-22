using Microsoft.EntityFrameworkCore;
using KindQuest.Models;
using KindQuest.Interfaces;
using KindQuest.Data;
using Microsoft.EntityFrameworkCore;

<<<<<<< HEAD

=======
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297
namespace KindQuest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return (User)Results.BadRequest("User Id Not Found");
            }
<<<<<<< HEAD
            var user = await _userRepository.GetUserByIdAsync(id);
=======
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297
            if (user == null)
            {
                return (User)Results.BadRequest("User Not Found");
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
                return (User)Results.BadRequest("User Not Found");
            }
            var createdUser = await _userRepository.CreateUserAsync(user);
            if (createdUser == null)
            {
                return (User)Results.BadRequest("User Not Created");
            }
            return createdUser;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (user == null || user.Id <= 0)
            {
                return (User)Results.BadRequest("Invalid User Data");
            }
            var updatedUser = await _userRepository.UpdateUserAsync(user.Id, user);
            if (updatedUser == null)
            {
                return (User)Results.BadRequest("User Not Updated");
            }
            return updatedUser;
        }
        public async Task DeleteUserAsync(int id)
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
        }
    }
<<<<<<< HEAD
 }
=======
}
>>>>>>> 93f14f79531ce93b1ae285c955913a3a2a1a1297
