using AutoMapper;
using Store.DTOs;
using Store.Models;

namespace Store;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();
       

    }



}