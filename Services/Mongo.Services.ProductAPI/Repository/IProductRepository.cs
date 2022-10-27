using Mongo.Services.ProductAPI.Modles.DTOs;

namespace Mongo.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto model);
        Task<bool> DeleteProduct(int productId);
    }
}
