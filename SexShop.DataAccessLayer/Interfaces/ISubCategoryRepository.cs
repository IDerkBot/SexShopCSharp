using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ISubCategoryRepository : IBaseRepository<SubCategory>
{
    Task<Product> GetByName(string name);
}