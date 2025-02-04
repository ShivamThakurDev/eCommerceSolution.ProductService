using AutoMapper;
using ProductService.DAL.DTO;
using ProductService.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductService.BLL.Mappers
{
    public class ProductUpdateRequestToProductMappingProfile : Profile
    {
        public ProductUpdateRequestToProductMappingProfile()
        {
            CreateMap<ProductUpdateRequest, Product>()
              .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
              .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
              .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
              .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
              ;
        }
    }
}
