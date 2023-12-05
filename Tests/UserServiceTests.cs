using Business.Service;
using Data.Repository;
using FluentAssertions;
using Models.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests;

public class UserServiceTests
{
    private IUserService _userService;
    
    [SetUp]
    public void Setup()
    {
        // Create a mock repository for testing (you can use a mocking library)
        var mockRepository = new MockUserRepository();
        _userService = new UserService(mockRepository);
    }
    
    
    [Test]
    public void GetUsers_ShouldReturnListOfUsers()
    {
        // Arrange (handled in the Setup method)

        // Act
        var users = _userService.GetUsers();

        // Assert
        users.Should().NotBeNull();
        users.Should().BeOfType<List<User>>();
        // Additional assertions as needed
    }

    [Test]
    public void GetUser_ShouldReturnUserById()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        var user = _userService.GetUser(userId);

        // Assert
        user.Should().BeNull(); // Assuming the mock repository returns null for non-existing user
        // Additional assertions as needed
    }
    
    [Test]
    public void UserExists_ShouldReturnTrueForExistingUser()
    {
        // Arrange
        Guid existingUserId = new Guid("64980173-fd6d-e5e0-7c13-05d127cf97f2");

        // Act
        var userExists = _userService.UserExists(existingUserId);

        // Assert
        userExists.Should().BeTrue();
    }
    
    [Test]
    public void UserExists_ShouldReturnFalseForNonExistingUser()
    {
        // Arrange
        Guid nonExistingUserId = new Guid("E3AB2ADD-CC18-4A64-B117-C1D4F9099B90");

        // Act
        var userExists = _userService.UserExists(nonExistingUserId);

        // Assert
        userExists.Should().BeFalse();
    }

}

// Mock UserRepository for testing purposes
public class MockUserRepository : IUserRepository
{
    // Implement IUserRepository methods for testing
    public IList<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public User GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public bool UserExists(Guid id)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(Guid id, User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }
}
