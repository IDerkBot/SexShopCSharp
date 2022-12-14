using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IProductRepository : IBaseRepository<Product>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<Product?> GetByName(string name);

    Task AddImage(Product product, Image image);
}