using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApiSandbox;

public class UpdateProductDto
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    public string Name { get; set; } = string.Empty;
    [Range(0.01, 100000, ErrorMessage = "The price should be postive and under 100000")]
    public decimal Price { get; set; }
}