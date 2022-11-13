using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IManufacturerRepository : IBaseRepository<Manufacturer>
{
    Task<Manufacturer> GetByName(string name);
}