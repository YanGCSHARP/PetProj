using Store.Models;

namespace Store.DTOs;

public class ProductDTO
{
    public Guid id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Image { get; set; }
    public Category Category { get; set; }
}