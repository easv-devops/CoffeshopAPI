using Models.Entities;

namespace Data.Repository;

public interface IUserRepository
{
    IList<User> GetUsers();
    User GetUser(Guid id);
    bool UserExists(Guid id);
    User UpdateUser(Guid id, User user);
    void DeleteUser(Guid id);
    User CreateUser(User user);
}