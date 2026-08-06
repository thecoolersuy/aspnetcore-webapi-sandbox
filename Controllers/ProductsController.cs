using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiSandbox;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = new List<string> { "Laptop", "Phone", "Headphones" };
        return Ok(products);
    }
}