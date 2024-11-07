using BackendProject.Models;

namespace BackendProject.Repositories;

public interface IUserRepository
{
    Task<bool> RegisterUser(User user);
    Task<User> LoginUser(string email, string password);
}