using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IColorRepository : IBaseRepository<Color>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<Color?> GetByName(string name);
}