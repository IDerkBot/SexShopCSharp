using SexShop.Domain.Entity;
using SexShop.Model;
using SexShop.Model.Response;

namespace SexShop.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
    Task<IBaseResponse<IEnumerable<Product>>> GetProducts(int count);
    Task<IBaseResponse<Product>> Get(int id);
    Task<IBaseResponse<Product>> GetByName(string name);
    Task<IBaseResponse<Product>> Create(Product product);
    Task<IBaseResponse<bool>> Delete(int id);
}