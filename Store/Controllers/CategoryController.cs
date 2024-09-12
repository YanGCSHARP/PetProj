using Microsoft.AspNetCore.Mvc;
using Store.DTOs;
using Store.Services;

namespace Store.Controllers;

public class CategoryController : Controller
{
    
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("api/categories/getAll/")]
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        return categories;
    }
    
    [HttpGet("api/categories/getById/")]
    public async Task<CategoryDTO> GetCategoryByIdAsync(Guid id)
    {
        var category = await _categoryService.GetCategoryAsync(id);
        return category;
    }
    
    [HttpPost("api/categories/add/")]
    public async Task<CategoryDTO> AddCategoryAsync([FromBody] CategoryDTO category)
    {
        var newCategory = await _categoryService.AddCategoryAsync(category);
        return newCategory;
    }    
    
    [HttpPut("api/categories/update/")]
    public async Task<CategoryDTO> UpdateCategoryAsync([FromBody] CategoryDTO category)
    {
        var updatedCategory = await _categoryService.UpdateCategoryAsync(category);
        return updatedCategory;
    }    
    
    [HttpDelete("api/categories/delete/")]
    public async Task<IActionResult> DeleteCategoryAsync([FromBody] Guid id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return Ok();
    }   
    
}