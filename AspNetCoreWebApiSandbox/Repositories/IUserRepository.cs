using SQLitePCL;

namespace AspNetCoreWebApiSandbox;

public interface IUserRepository
{
    Task<bool> RegisterAsync(RegisterDto registerData);

    Task<bool> LoginAsync(LoginDto loginData);


}