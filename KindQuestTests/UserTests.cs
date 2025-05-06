using KindQuest.Services;
using KindQuest.Models;
using KindQuest.Interfaces;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace KindQuestTests
{

  public class UserServiceTests

  {
    // The UserService class is dependent on the IUserRepository interface.
    // We do not need to mock the User class because it is a simple class.
    private readonly UserService _userService;

    // The Mock class is used to create a mock object of the IUserRepository interface.
    // Mock objects are used to simulate the behavior of real objects.
    // Mock objects are used in unit testing to isolate the code under test.
    // We are mocking the IUserRepository interface because we do not want to test the actual implementation of the UserRepository class.
    // Mock just means that we are creating a fake object that simulates the behavior of the real object.
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

      // The Setup method is used to set up the behavior of the mock object.
      // This means that when the GetAllUsers method is called, the mock object should return the list of Users.
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

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetAllUsersAsync()).Returns(Task.FromResult<IEnumerable<User>>(Users));

      var actualUsers = await _userService.GetAllUsersAsync();


      // The actualUsers returned by the GetAllUsers method should be equal to the empty list of Users.
      Assert.Empty(actualUsers);
    }




    [Fact]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
      // Arrange - means to set up the test
      var UserId = 1;

      // Here, we are creating an instance of the User class and properties.
      // The expectedUser does not have to match the actual User in the repository.
      var expectedUser = new User { Id = UserId, FirstName = "Luke", LastName = "Skywalker", Email = "Test@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" };

      // The Setup method is used to set up the behavior of the mock object.
      // This means that when the GetUserById method is called with the UserId parameter, the mock object should return the expectedUser instance.
      // The expectedUser is the object that we set up to be returned by the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult(expectedUser));

      // The GetUserByIdAsync method is called with the UserId parameter.
      // The actual User returned by the GetUserById method comes from the mock object.
      var actualUser = await _userService.GetUserByIdAsync(UserId);

      // The actualUser returned by the GetUserById method should be equal to the expectedUser instance.
      Assert.Equal(expectedUser, actualUser);
    }


    [Fact]
    public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
    {
      // A User with an Id of -1 does not exist in the repository
      // Therefore, the GetUserById method should return null.
      var UserId = -1;

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(UserId)).Returns(Task.FromResult<User>(null));

      // The GetUserByIdAsync method is called with the UserId parameter.
      var actualUser = await _userService.GetUserByIdAsync(UserId);

      // The actualUser returned should be null.
      Assert.Null(actualUser);
    }











































    // GET is ready for testing. Create, Update and Delete are not ready yet.





































    [Fact]
    public async Task CreateUser_ShouldCreateUser_WhenUserIsValid()
    {
      // Arrange - means to set up the test
      var newUser = new User { Id = 3, FirstName = "Han", LastName = "Solo", Email = "TEST@example.org", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile3.jpg" };
      // The CreateUser method should return the newUser instance when the newUser parameter is valid.

      // The Setup method is used to set up the behavior of the mock object.
      // This means that when the CreateUser method is called with the newUser parameter, the mock object should do nothing.
      _mockUserRepository.Setup(repo => repo.CreateUserAsync(newUser)).Verifiable();


      await _userService.CreateUserAsync(newUser);


      // The Verify method is used to verify that the CreateUser method was called with the newUser parameter.
      await _mockUserRepository.Object.CreateUserAsync(newUser);
      _mockUserRepository.Verify(repo => repo.CreateUserAsync(newUser), Times.Once);
    }

    [Fact]
    public async Task CreateUser_ShouldThrowException_WhenUserIsNull()
    {
      // Arrange - means to set up the test
      User newUser = null;


      // The CreateUser method should throw an ArgumentNullException when the newUser parameter is null.
      await Assert.ThrowsAsync<ArgumentNullException>(async () => await _userService.CreateUserAsync(newUser));
    }














































    [Fact]
    public async Task UpdateUser_ShouldUpdateUser_WhenUserExists()
    {
      // Arrange - means to set up the test
      var existingUser = new User { Id = 1, FirstName = "Luke", LastName = "Skywalker", Email = "Test@example.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile.jpg" };
      var updatedUser = new User { Id = 2, FirstName = "Kyle", LastName = "Katarn", Email = "test@example.net", EmergencyContact = 0987654321, ProfilePic = "https://example.com/profile2.jpg" };
      // The UpdateUser method should return the updatedUser instance when the updatedUser parameter is valid.

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(existingUser.Id)).Returns(Task.FromResult(existingUser));
      _mockUserRepository.Setup(repo => repo.UpdateUserAsync(updatedUser.Id, updatedUser)).Verifiable();

      // Act - means to run the test
      await _userService.UpdateUserAsync(updatedUser.Id, updatedUser);

      // Assert - means to check the result
      _mockUserRepository.Verify(repo => repo.UpdateUserAsync(updatedUser.Id, updatedUser), Times.Once);
    }

    [Fact]
    public async Task UpdateUser_ShouldThrowException_WhenUserDoesNotExist()
    {
      // Arrange - means to set up the test
      var nonExistingUser = new User { Id = 99, FirstName = "Darth", LastName = "Vader", Email = "evilguy@empire.com", EmergencyContact = 1234567890, ProfilePic = "https://example.com/profile3.jpg" };
      // The UpdateUser method should throw an InvalidOperationException when the User does not exist in the repository.

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserById(nonExistingUser.Id)).Returns((User)null);


      // The UpdateUser method should throw an InvalidOperationException when the User does not exist in the repository.
      Assert.Throws<InvalidOperationException>(() => _userService.UpdateUser(nonExistingUser));
    }












































    

    [Fact]
    public async Task DeleteUser_ShouldDeleteUser_WhenUserExists()
    {
      // Arrange - means to set up the test
      var UserId = 1;
      var existingUser = new User { Id = UserId, Title = "Star Wars", Author = "George Lucas" };

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserById(UserId)).Returns(existingUser);
      _mockUserRepository.Setup(repo => repo.DeleteUser(UserId)).Verifiable();


      _userService.DeleteUser(UserId);


      _mockUserRepository.Verify(repo => repo.DeleteUser(UserId), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_ShouldThrowException_WhenUserDoesNotExist()
    {
      // Arrange - means to set up the test
      var UserId = 99;

      // The Setup method is used to set up the behavior of the mock object.
      _mockUserRepository.Setup(repo => repo.GetUserById(UserId)).Returns((User)null);


      // The DeleteUser method should throw an InvalidOperationException when the User does not exist in the repository.
      Assert.Throws<InvalidOperationException>(() => _userService.DeleteUser(UserId));
    }

  }
}
