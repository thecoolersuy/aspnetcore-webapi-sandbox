using Xunit;
using AspNetCoreWebApiSandbox;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiSandbox.Test;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AspNetCoreWebApiSandbox.Tests;

public class ProductsControllerTests
{
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