namespace BackendProject.Repositories.User;

public interface IUserRepository
{
    Task<bool> RegisterUser(Models.User.User user);
    Task<Models.User.User> LoginUser(string email, string password);
}