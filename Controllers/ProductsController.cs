using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiSandbox;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{

    private static List<Product> _products = new List<Product>
    {
        new Product{Id=1, Name="Nokia",Price=100.2m},
        new Product{Id=2,Name="Iphone", Price=23000m},
        new Product{Id=3,Name="Nothing Phone", Price=40000m},
    };

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _products.FirstOrDefault(n => n.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);

    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product newProduct)
    {
        newProduct.Id = _products.Count + 1;
        _products.Add(newProduct);

        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        var product = _products.FirstOrDefault(n => n.Id == id);
        if (product == null)
        {
            NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deleteproduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        _products.Remove(product);

        return NoContent();
    }



}