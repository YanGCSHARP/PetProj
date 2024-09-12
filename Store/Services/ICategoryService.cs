using Store.DTOs;

namespace Store.Services;

public interface ICategoryService
{
    Task<CategoryDTO> GetCategoryAsync(Guid id);
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> AddCategoryAsync(CategoryDTO category);
    Task<CategoryDTO> DeleteCategoryAsync(Guid id);
    Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO category);    
    
}