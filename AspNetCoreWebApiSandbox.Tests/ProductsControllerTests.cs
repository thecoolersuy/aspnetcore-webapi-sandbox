using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiSandbox.Test;

namespace AspNetCoreWebApiSandbox.Tests;

public class ProductsControllerTests
{
    [Fact]
    public async Task CreateProduct_ReturnCreatedAtAction_WhenValid()
    {
        var fakeRepo = new FakeProductRepository();
        var controller = new ProductsController(fakeRepo);
        var newProduct = new CreateProductDto
        {
            Name = "Nokia 350",
            Price = 199m
        };
        var result = await controller.CreateProduct(newProduct);
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var responseData = Assert.IsType<ProductResponseDto>(createdResult.Value);
        Assert.Equal("Nokia 350", responseData.Name);
        Assert.Equal(199m, responseData.Price);
    }

    [Fact]
    public async Task GetProductById_ReturnsOk_WhenProductExists()
    {
        var fakeRepository = new FakeProductRepository();
        var controller = new ProductsController(fakeRepository);

        var result = await controller.GetProductById(1);
        Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_WhenNoProductExists()
    {
        var fakeRepo = new FakeProductRepository();
        var controller = new ProductsController(fakeRepo);

        var result = await controller.GetProductById(999);
        Assert.IsType<NotFoundResult>(result);
    }
}