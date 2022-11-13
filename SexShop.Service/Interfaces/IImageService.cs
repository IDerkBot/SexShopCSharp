using SexShop.Domain.Entity;
using SexShop.Model.Response;

namespace SexShop.Service.Interfaces;

public interface IImageService
{
    Task<IBaseResponse<IEnumerable<Image>>> GetImage();
    Task<IBaseResponse<IEnumerable<Image>>> GetImages(Product product);
    Task<IBaseResponse<Image>> Get(int id);
    Task<IBaseResponse<Image>> GetByLink(string link);
    Task<IBaseResponse<Image>> Create(Image product);
    Task<IBaseResponse<bool>> Delete(int id);
}