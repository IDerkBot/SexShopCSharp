using SexShop.Model;

namespace SexShop.DataAccessLayer.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<Product?> GetByName(string name);
}