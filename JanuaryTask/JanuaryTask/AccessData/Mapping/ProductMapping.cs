using AccessData.Models;
using AutoMapper;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<CreateProductDTO, Product>() . ReverseMap();
        }
        
    }
}
