using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiSandbox;

public class SqliteUserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public SqliteUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterAsync(RegisterDto registerData)
    {
        bool usernameTaken = await _context.Users.AnyAsync(p => p.UserName == registerData.UserName);
        if (usernameTaken)
        {
            return false;
        }
        var user = new User
        {
            UserName = registerData.UserName,
            Password = BCrypt.Net.BCrypt.HashPassword(registerData.Password)
        };
        _context.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LoginAsync(LoginDto loginData)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.UserName == loginData.UserName);
        if (user == null)
        {
            return false;
        }
        else
        {
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password);
            if (passwordMatches) { return true; }
            else
            {
                return false;
            }
        }
    }
}