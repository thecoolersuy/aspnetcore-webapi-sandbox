using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApiSandbox;

public class RegisterDto
{
    [Required(ErrorMessage = "Your username is required to register your account.")]
    [MinLength(4, ErrorMessage = "The username must be at least 4 characters long.")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The password cannot be left empty.")]
    [MinLength(8, ErrorMessage = "The passowrd must be 8 characters long.")]
    public string Password { get; set; } = string.Empty;
}