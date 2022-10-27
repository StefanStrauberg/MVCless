using Mongo.Web.Models.DTOs;
using Mongo.Web.Services.IServices;

namespace Mongo.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) 
            : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
            => await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductApiBase + "/api/Product",
                AccessToken = ""
            });
        public async Task<T> DeleteProductAsync<T>(int id)
            => await this.SendAsync<T>(new Models.ApiRequest()
                {
                    ApiType = SD.ApiType.DELETE,
                    Url = SD.ProductApiBase + "/api/Product/"+ id,
                    AccessToken = ""
                });
        public async Task<T> GetAllProductsAsync<T>()
            => await this.SendAsync<T>(new Models.ApiRequest()
                {
                    ApiType = SD.ApiType.GET,
                    Url = SD.ProductApiBase + "/api/Product",
                    AccessToken = ""
                });
        public async Task<T> GetProductByIdAsync<T>(int id)
            => await this.SendAsync<T>(new Models.ApiRequest()
                {
                    ApiType = SD.ApiType.GET,
                    Url = SD.ProductApiBase + "/api/Product/" + id,
                    AccessToken = ""
                });
        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
            => await this.SendAsync<T>(new Models.ApiRequest()
                {
                    ApiType = SD.ApiType.PUT,
                    Data = productDto,
                    Url = SD.ProductApiBase + "/api/Product",
                    AccessToken = ""
                });
    }
}
