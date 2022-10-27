using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.ProductAPI.DbContexts;
using Mongo.Services.ProductAPI.Modles;
using Mongo.Services.ProductAPI.Modles.DTOs;

namespace Mongo.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _db;
        IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        } 
        public async Task<ProductDto> CreateUpdateProduct(ProductDto model)
        {
            Product product = _mapper.Map<ProductDto, Product>(model);
            
            if(product.ProductId > 0)
                _db.Products.Update(product);
            else
                _db.Products.Add(product);

            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products
                    .FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product is null)
                    return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productList);
        }
    }
}
