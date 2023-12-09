using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly CoffeeContext _context;

    public UserRepository(CoffeeContext context)
    {
        _context = context;
    }

    public IList<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(Guid id)
    {
        return _context.Users.Find(id);
    }
    
    public User GetUserByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public bool UserExists(Guid id)
    {
        return _context.Users.Any(e => e.Id == id);
    }

    public User UpdateUser(Guid id, User user)
    {
        var userToUpdate = GetUser(id);
        userToUpdate.IsAdmin = user.IsAdmin;
        _context.SaveChanges();
        return user;
    }

    public void DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User CreateUser(User user)
    {
        // Hash the password
        string salt = BCrypt.Net.BCrypt.GenerateSalt(); // Generate a unique salt
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);

        // Update the user object with hashed password and salt
        user.Password = hashedPassword;
        user.Salt = salt;
        
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}