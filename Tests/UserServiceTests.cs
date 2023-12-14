using Models.Entities;
using Moq;

namespace Tests;

[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private IUserService _userService;

    [SetUp]
    public void SetUp()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Test]
    public void GetUsers_ShouldReturnListOfUsers()
    {
        // Arrange
        var users = new List<User> { new User(), new User() };
        _userRepositoryMock.Setup(r => r.GetUsers()).Returns(users);

        // Act
        var result = _userService.GetUsers();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(List<User>)));
        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    public void GetUser_ExistingUserId_ShouldReturnUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId };
        _userRepositoryMock.Setup(r => r.GetUser(userId)).Returns(user);

        // Act
        var result = _userService.GetUser(userId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(User)));
        Assert.That(result.Id, Is.EqualTo(userId));
    }

    [Test]
    public void GetUser_NonExistingUserId_ShouldReturnNull()
    {
        // Arrange
        var nonExistingUserId = Guid.NewGuid();
        _userRepositoryMock.Setup(r => r.GetUser(nonExistingUserId)).Returns((User)null);

        // Act
        var result = _userService.GetUser(nonExistingUserId);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetUserByUsername_ExistingUsername_ShouldReturnUser()
    {
        // Arrange
        var username = "testuser";
        var user = new User { Id = Guid.NewGuid(), Username = username };
        _userRepositoryMock.Setup(r => r.GetUserByUsername(username)).Returns(user);

        // Act
        var result = _userService.GetUserByUsername(username);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(User)));
        Assert.That(result.Username, Is.EqualTo(username));
    }

    [Test]
    public void GetUserByUsername_NonExistingUsername_ShouldReturnNull()
    {
        // Arrange
        var nonExistingUsername = "nonexistent";
        _userRepositoryMock.Setup(r => r.GetUserByUsername(nonExistingUsername)).Returns((User)null);

        // Act
        var result = _userService.GetUserByUsername(nonExistingUsername);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void UserExists_ExistingUserId_ShouldReturnTrue()
    {
        // Arrange
        var existingUserId = Guid.NewGuid();
        _userRepositoryMock.Setup(r => r.UserExists(existingUserId)).Returns(true);

        // Act
        var result = _userService.UserExists(existingUserId);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void UserExists_NonExistingUserId_ShouldReturnFalse()
    {
        // Arrange
        var nonExistingUserId = Guid.NewGuid();
        _userRepositoryMock.Setup(r => r.UserExists(nonExistingUserId)).Returns(false);

        // Act
        var result = _userService.UserExists(nonExistingUserId);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void UpdateUser_ExistingUserId_ShouldReturnUpdatedUser()
    {
        // Arrange
        var existingUserId = Guid.NewGuid();
        var updatedUser = new User { Id = existingUserId, Username = "Updated User" };
        _userRepositoryMock.Setup(r => r.UpdateUser(existingUserId, updatedUser)).Returns(updatedUser);

        // Act
        var result = _userService.UpdateUser(existingUserId, updatedUser);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(User)));
        Assert.That(result.Id, Is.EqualTo(existingUserId));
        Assert.That(result.Username, Is.EqualTo("Updated User"));
    }

    [Test]
    public void DeleteUser_ExistingUserId_ShouldCallRepositoryDeleteUser()
    {
        // Arrange
        var existingUserId = Guid.NewGuid();

        // Act
        _userService.DeleteUser(existingUserId);

        // Assert
        _userRepositoryMock.Verify(r => r.DeleteUser(existingUserId), Times.Once);
    }

    [Test]
    public void CreateUser_ShouldReturnCreatedUser()
    {
        // Arrange
        var newUser = new User { Username = "New User" };
        _userRepositoryMock.Setup(r => r.CreateUser(newUser)).Returns(newUser);

        // Act
        var result = _userService.CreateUser(newUser);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(User)));
        Assert.That(result.Username, Is.EqualTo("New User"));
    }
}