using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Models;

namespace Bootcamp.API.Mappers;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}