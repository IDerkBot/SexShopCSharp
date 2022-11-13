using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<Category> GetByName(string name);
}