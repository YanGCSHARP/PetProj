using Microsoft.AspNetCore.Mvc;
using Store.DTOs;
using Store.Services;

namespace Store.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet("api/products/")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(int page = 1, int pageSize = 10)
    {
        var products = await _productService.GetProductsAsync(page, pageSize);
        return products;
    }
    
    [HttpGet("api/products/product/")]
    public async Task<IActionResult> GetPriductByIdAsync(Guid id)
    {
        var product = await _productService.GetProductAsync(id);
        return Ok(product);
    }
    
    [HttpPost("api/products/add/")]
    public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO product)
    {
        var newProduct = await _productService.AddProductAsync(product);
        return Ok(newProduct);
    }
    
    [HttpPut("api/products/update/")]
    public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDTO product, Guid id)
    {
        var updatedProduct = await _productService.UpdateProductAsync(product, id);
        return Ok(updatedProduct);
    }
    
    [HttpDelete("api/products/delete/")]
    public async Task<IActionResult> DeleteProductAsync([FromBody] Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }
    
    
    
}

public class ActionRezult<T>
{
}