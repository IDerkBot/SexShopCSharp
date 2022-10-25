using SexShop.Model;
using SexShop.Model.Response;

namespace SexShop.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
}