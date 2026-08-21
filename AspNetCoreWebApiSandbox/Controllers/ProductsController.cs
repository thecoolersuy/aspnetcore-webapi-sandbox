using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiSandbox;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _repository.GetAllAsync();
        var responseData = products.Select(p => new ProductResponseDto
        {
            Name = p.Name,
            Price = p.Price
        }).ToList();

        return Ok(responseData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();

        var responseData = new ProductResponseDto
        {
            Name = product.Name,
            Price = product.Price
        };

        return Ok(responseData);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto newProduct)
    {
        var product = new Product
        {
            Name = newProduct.Name,
            Price = newProduct.Price

        };
        await _repository.AddAsync(product);

        var responseData = new ProductResponseDto
        {
            Name = product.Name,
            Price = product.Price
        };
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, responseData);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updatedProduct)
    {
        var product = new Product
        {
            Name = updatedProduct.Name,
            Price = updatedProduct.Price
        };
        bool status = await _repository.UpdateAsync(id, product);
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();



    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        bool status = await _repository.DeleteAsync(id);
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll()
    {
        bool status = await _repository.DeleteAllAsync();
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();
    }



}