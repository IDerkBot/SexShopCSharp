using SexShop.DataAccessLayer.Interfaces.Base;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Interfaces;

public interface IImageRepository : IBaseRepository<Image>
{
    Task<Image?> GetByProduct(Product product);
    Task<List<Image>> GetAllByProduct(Product product);
}