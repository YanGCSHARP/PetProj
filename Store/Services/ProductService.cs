using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.DTOs;
using Store.Models;

namespace Store.Services;

public class ProductService : IProductService
{
    
    private readonly StoreContext _context;
    private readonly IMapper _mapper;
    
    public ProductService(StoreContext context, IMapper _Mapper)
    {
        _context = context;
        _mapper = _Mapper;
    }

    public async Task<ProductDTO> AddProductAsync(ProductDTO product)
    {
        var productEntity = new Product();
        
        productEntity = _mapper.Map<Product>(product);
        productEntity.Category = await _context.Categories.FindAsync(product.Category.Id);
        
        await _context.Products.AddAsync(productEntity);
        await _context.SaveChangesAsync();
        var ans = new ProductDTO();
        ans = _mapper.Map<ProductDTO>(productEntity);
        ans.Category.Id = productEntity.Category.Id;
        return ans;
    }

    public async Task<ProductDTO> GetProductAsync(Guid id)
    {
        var productEntity = await _context.Products.FindAsync(id);
        var ans = new ProductDTO();
        ans = _mapper.Map<ProductDTO>(productEntity);
        return ans;
    }

    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(int page = 1, int pageSize = 10)
    {
        IEnumerable<Product> products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize);
        PageInfo pageInfo = new PageInfo
        {
            PageNumber = page,
            PageSize = pageSize,
            TotalItems = _context.Products.Count()
        };
        
        IndexViewModel<ProductDTO> ivm = new IndexViewModel<ProductDTO>
        {
            Items = products.Select(product => _mapper.Map<ProductDTO>(product)),
            PageInfo = pageInfo
        };

        return ivm.Items.ToList();
    }

    public async Task<ProductDTO> UpdateProductAsync(ProductDTO product, Guid id)
    {
        var productEntity = await _context.Products.FindAsync(id);
        productEntity.Name = product.Name;
        productEntity.Description = product.Description;
        productEntity.Price = product.Price;
        productEntity.Category = await _context.Categories.FindAsync(product.Category.Id);
        await _context.SaveChangesAsync();
        var ans = new ProductDTO();
        ans = _mapper.Map<ProductDTO>(productEntity);
        return ans;
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var productEntity = await _context.Products.FindAsync(id);
        _context.Products.Remove(productEntity);
        await _context.SaveChangesAsync();
    }
}
