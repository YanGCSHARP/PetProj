using Microsoft.AspNetCore.Mvc;
using Store.DTOs;

namespace Store.Services;

public interface IProductService
{
    Task<ProductDTO> AddProductAsync(ProductDTO product);
    Task<ProductDTO> GetProductAsync(Guid id);
    Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(int page, int pageSize);
    Task<ProductDTO> UpdateProductAsync(ProductDTO product, Guid id);
    Task DeleteProductAsync(Guid id);
}