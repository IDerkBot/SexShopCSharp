using System.Xml.Serialization;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;
using SexShop.Model;
using SexShop.Model.Enum;
using SexShop.Model.Response;
using SexShop.Service.Interfaces;

namespace SexShop.Service.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
    {
        var baseResponse = new BaseResponse<IEnumerable<Product>>();
        try
        {
            var products = await _productRepository.Select();
            if (products.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = products;
            baseResponse.StatusCode = StatusCode.Ok;
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Product>>
            {
                Description = $"[GetProducts] : {e.Message}"
            };
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts(int count)
    {
        var baseResponse = new BaseResponse<IEnumerable<Product>>();
        try
        {
            var products = await _productRepository.Select();
            if (products.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            var list = new List<Product>();
            if (products.Count >= count)
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add(products[new Random().Next(1, products.Count - 1)]);
                }
            }
            else list = products;
            
            baseResponse.Data = list;
            baseResponse.StatusCode = StatusCode.Ok;
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Product>>
            {
                Description = $"[GetProducts] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Product>> Get(int id)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                baseResponse.Description = "Ничего не найдено";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = product;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Product>
            {
                Description = $"[GetIdProduct] : {e.Message}"
            };
        }
    }
    
    public async Task<IBaseResponse<Product>> GetByName(string name)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetByName(name);
            if (product == null)
            {
                baseResponse.Description = "Ничего не найдено";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = product;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Product>
            {
                Description = $"[GetByNameProduct] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Product>> Create(Product product)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            await _productRepository.Create(product);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Product>
            {
                Description = $"[CreateProduct] : {e.Message} {e.InnerException}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> Delete(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                baseResponse.Description = "Ничего не найдено";
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }

            await _productRepository.Delete(product);

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>
            {
                Description = $"[DeleteProduct] : {e.Message}"
            };
        }
    }

    public async void Update()
    {
        
        
        // xml.Deserialize()
    }
}