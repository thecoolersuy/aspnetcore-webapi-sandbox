using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApiSandbox;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    public string Name { get; set; } = string.Empty;
    [Range(0.01, 1000, ErrorMessage = "The price should be positive and under 10000")]
    public decimal Price { get; set; }
}