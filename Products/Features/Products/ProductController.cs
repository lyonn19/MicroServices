using Microsoft.AspNetCore.Mvc;

namespace Products.Features.Products;

public class AccountController : ControllerBase
{
    private readonly IProductService _productService;
    public AccountController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpPost("get")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_productService.AddProduct(new ProductModel() { Id = id }));
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddAsync(ProductModel request)
    {
        return Ok(_productService.AddProduct(new ProductModel() { Id = request.Id }));
    }
    
    
}
