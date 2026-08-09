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
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
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
    public IActionResult Deleteproduct(int id)
    {
        bool status = _repository.Delete(id);
        if (status == false)
        {
            return NotFound();
        }
        return NoContent();
    }



}