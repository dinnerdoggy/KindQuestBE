using KindQuest.Services;
using KindQuest.Models;
using KindQuest.Interfaces;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace KindQuest.Tests
{

  public class UserServiceTests

  {
    private readonly UserService _userService;

    private readonly Mock<IUserRepository> _mockUserRepository;

    public UserServiceTests()
    {
      _mockUserRepository = new Mock<IUserRepository>();
      _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task GetAllUsers_ShouldReturnAllUsers()
    {
      var Users = new List<User>
            {
                new User { Id = 1, Uid = "1", FirstName = "Luke", LastName = "Skywalker", Email = "Test@xample.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" },
                new User { Id = 2, Uid = "2", FirstName = "Leia", LastName = "Organa", Email = "Test@example.net", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile2.jpg" },
            };

      // When the GetAllUsers method is called, the mock object should return the list of Users.
      // Task.FromResult is used to create a task that returns the list of Users, we need this because the GetAllUsers method is asynchronous.
      _mockUserRepository
          .Setup(repo => repo.GetAllUsersAsync())
          .Returns(Task.FromResult(Users.AsEnumerable()));

      var actualUsers = (await _userService.GetAllUsersAsync()).ToList();

      // The actualUsers returned by the GetAllUsers method should be equal to the list of Users.
      Assert.Equal(Users, actualUsers);
    }

    [Fact]
    public async Task GetAllUsers_ShouldReturnEmptyList_WhenNoUsersExist()
    {
      // The GetAllUsers method should return an empty list when there are no Users in the repository.
      var Users = new List<User>();

      _mockUserRepository.Setup(repo => repo.GetAllUsersAsync()).Returns(Task.FromResult<IEnumerable<User>>(Users));

      var actualUsers = new List<User>();

      try
      {
        actualUsers = (await _userService.GetAllUsersAsync()).ToList();
      }
      catch (InvalidOperationException ex)
      {
        Assert.Equal("No Users Found", ex.Message);
      }

      // The actualUsers returned by the GetAllUsers method should be equal to the empty list of Users.
      Assert.Empty(actualUsers);
    }

    [Fact]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
      var UserId = 1;

      var expectedUser = new User { Id = UserId, FirstName = "Luke", LastName = "Skywalker", Email = "Test@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" };

      // The GetUserById method is called with the UserId parameter, the mock object should return the expectedUser instance.
      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult(expectedUser));

      var actualUser = await _userService.GetUserByIdAsync(UserId);

      // The actualUser returned by the GetUserById method should be equal to the expectedUser instance.
      Assert.Equal(expectedUser, actualUser);
    }

    [Fact]
    public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
    {
      // A User with an Id of 999 does not exist in the repository
      // Therefore, the GetUserById method should return null.
      var UserId = 999;

      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult<User>(null!));

      var actualUser = await _userService.GetUserByIdAsync(UserId);

      // The actualUser returned should be null.
      Assert.Null(actualUser);
    }

    [Fact]
    public async Task CreateUser_ShouldCreateUser_WhenUserIsValid()
    {
      var newUser = new User { Id = 3, FirstName = "Han", LastName = "Solo", Email = "TEST@example.org", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile3.jpg" };
      // The CreateUser method should return the newUser instance when the newUser parameter is valid.

      _mockUserRepository.Setup(repo => repo.CreateUserAsync(newUser)).Verifiable();

      // The Verify method is used to verify that the CreateUser method was called with the newUser parameter.
      await _mockUserRepository.Object.CreateUserAsync(newUser);
      _mockUserRepository.Verify(repo => repo.CreateUserAsync(newUser), Times.Once);
    }

    [Fact]
    public async Task CreateUser_ShouldThrowException_WhenUserIsNull()
    {
      User newUser = null;

      // The CreateUser method should throw an ArgumentNullException when the newUser parameter is null.
      await Assert.ThrowsAsync<ArgumentNullException>(async () => await _userService.CreateUserAsync(newUser));
    }

    [Fact]
    public async Task UpdateUser_ShouldUpdateUser_WhenUserExists()
    {
      var existingUser = new User { Id = 1, FirstName = "Luke", LastName = "Skywalker", Email = "Test@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" };
      var updatedUser = new User { Id = 2, FirstName = "Kyle", LastName = "Katarn", Email = "test@example.net", EmergencyContact = 0987654321, ProfilePic = "https://example.com/profile2.jpg" };
      // The UpdateUser method should return the updatedUser instance when the updatedUser parameter is valid.

      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(existingUser.Id)).Returns(Task.FromResult(existingUser));
      _mockUserRepository.Setup(repo => repo.UpdateUserAsync(updatedUser.Id, updatedUser)).Returns(Task.FromResult(updatedUser)).Verifiable();

      await _userService.UpdateUserAsync(updatedUser.Id, updatedUser);

      _mockUserRepository.Verify(repo => repo.UpdateUserAsync(updatedUser.Id, updatedUser), Times.Once);
    }

    [Fact]
    public async Task UpdateUser_ShouldThrowException_WhenUserDoesNotExist()
    {
      var nonExistingUser = new User { Id = 99, FirstName = "Darth", LastName = "Vader", Email = "evilguy@empire.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile3.jpg" };

      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(nonExistingUser.Id)).Returns(Task.FromResult<User>(null));

      await Assert.ThrowsAsync<InvalidOperationException>(async () => await _userService.UpdateUserAsync(nonExistingUser.Id, nonExistingUser));
    }

    [Fact]
    public async Task DeleteUser_ShouldDeleteUser_WhenUserExists()
    {
      var UserId = 1;
      var existingUser = new User { Id = UserId, FirstName = "Luke", LastName = "Skywalker", Email = "Test@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" };

      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult(existingUser));
      _mockUserRepository.Setup(repo => repo.DeleteUserAsync(UserId))
          .Returns(Task.FromResult(true)).Verifiable();

      await _userService.DeleteUserAsync(UserId);

      _mockUserRepository.Verify(repo => repo.DeleteUserAsync(UserId), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_ShouldThrowException_WhenUserDoesNotExist()
    {
      var UserId = 999;

      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult<User>(null));

      await Assert.ThrowsAsync<InvalidOperationException>(async () => await _userService.DeleteUserAsync(UserId));
    }
  }
}
