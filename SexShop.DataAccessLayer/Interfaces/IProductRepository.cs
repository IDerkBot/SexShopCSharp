using SexShop.Model;

namespace SexShop.DataAccessLayer.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    public Product GetByName(string name);
}