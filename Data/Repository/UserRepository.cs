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

    public bool UserExists(Guid id)
    {
        return _context.Users.Any(e => e.Id == id);
    }

    public User UpdateUser(Guid id, User user)
    {
        _context.Entry(user).State = EntityState.Modified;
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
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}