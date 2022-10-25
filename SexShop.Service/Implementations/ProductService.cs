using SexShop.DataAccessLayer.Interfaces;
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
            return new BaseResponse<IEnumerable<Product>>()
            {
                Description = $"[GetProducts] : {e.Message}"
            };
        }
    }
}