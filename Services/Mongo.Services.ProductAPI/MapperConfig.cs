using AutoMapper;
using Mongo.Services.ProductAPI.Modles;
using Mongo.Services.ProductAPI.Modles.DTOs;

namespace Mongo.Services.ProductAPI
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
