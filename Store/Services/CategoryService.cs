using System.Data.SqlTypes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.DTOs;
using Store.Models;

namespace Store.Services;

public class CategoryService : ICategoryService
{
    
    public readonly StoreContext _context;
    public readonly IMapper _mapper;

    public CategoryService(StoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<CategoryDTO> GetCategoryAsync(Guid id)
    {
        var categoryEntity = await _context.Categories.FindAsync(id);
        var ans = new CategoryDTO();
        ans = _mapper.Map<CategoryDTO>(categoryEntity);
        return ans;
    }
    
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
           var categories = await _context.Categories.ToListAsync();
           var ans = new List<CategoryDTO>();
           ans = _mapper.Map<List<CategoryDTO>>(categories);
           return ans;
    }
    
    public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO category)
    {
        var categoryEntity = new Category();
        categoryEntity = _mapper.Map<Category>(category);
        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();
        var ans = new CategoryDTO();
        ans = _mapper.Map<CategoryDTO>(categoryEntity);
        return ans;
    }
    
    public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO category)
    {
        var categoryEntity = await _context.Categories.FindAsync(category.Id);
        categoryEntity.Name = category.Name;
        categoryEntity.Description = category.Description;
        await _context.SaveChangesAsync();
        var ans = new CategoryDTO();
        ans = _mapper.Map<CategoryDTO>(categoryEntity);
        return ans;
    }
    
    public async Task<CategoryDTO> DeleteCategoryAsync(Guid id)
    {
        var categoryEntity = await _context.Categories.FindAsync(id);
        _context.Categories.Remove(categoryEntity);
        await _context.SaveChangesAsync();
        var ans = new CategoryDTO();
        ans = _mapper.Map<CategoryDTO>(categoryEntity);
        return ans;
    }
    
}