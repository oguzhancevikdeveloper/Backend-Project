using BackendProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Repositories.User;

public class UserRepository(ApplicationDbContext _context) : IUserRepository
{

    public async Task<bool> RegisterUser(Models.User.User user)
    {

        if (await _context.Users.AnyAsync(u => u.Email == user.Email)) return false;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Models.User.User> LoginUser(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
