using Data.Repository;
using Models.Entities;

namespace Business.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public IList<User> GetUsers()
    {
        return _userRepository.GetUsers();
    }
    
    public User? GetUser(Guid id)
    {
        return _userRepository.GetUser(id);
    }
    
    public User? GetUserByUsername(string username)
    {
        return _userRepository.GetUserByUsername(username);
    }
    
    public bool UserExists(Guid id)
    {
        return _userRepository.UserExists(id);
    }
    
    public User UpdateUser(Guid id, User user)
    {
        return _userRepository.UpdateUser(id, user);
    }
    
    public void DeleteUser(Guid id)
    {
        _userRepository.DeleteUser(id);
    }
    
    public User CreateUser(User user)
    {
        return _userRepository.CreateUser(user);
    }
}