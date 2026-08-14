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
    public IActionResult GetAllProducts()
    {
        var products = _repository.GetAll();
        var responseData = products.Select(p => new ProductResponseDto
        {
            Name = p.Name,
            Price = p.Price
        }).ToList();

        return Ok(responseData);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null) return NotFound();

        var responseData = new ProductResponseDto
        {
            Name = product.Name,
            Price = product.Price
        };

        return Ok(responseData);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto newProduct)
    {
        var product = new Product
        {
            Name = newProduct.Name,
            Price = newProduct.Price

        };
        _repository.Add(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto updatedProduct)
    {
        var product = new Product
        {
            Name = updatedProduct.Name,
            Price = updatedProduct.Price
        };
        bool status = _repository.Update(id, product);
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();



    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        bool status = _repository.Delete(id);
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAll()
    {
        bool status = _repository.DeleteAll();
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();
    }



}