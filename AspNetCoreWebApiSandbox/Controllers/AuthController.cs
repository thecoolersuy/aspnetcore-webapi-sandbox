using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiSandbox;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;

    public AuthController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerData)
    {
        bool registerSuccess = await _repository.RegisterAsync(registerData);
        if (!registerSuccess)
        {
            return BadRequest(new { error = "Requested username already exists." });
        }
        return Ok(new { message = "Registered Successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginData)
    {
        bool loginSuccess = await _repository.LoginAsync(loginData);
        if (!loginSuccess)
        {
            return BadRequest(new { error = "The Passwords didn't match." });
        }
        return Ok(new { message = "Login Successfull" });
    }
}