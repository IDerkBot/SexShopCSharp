using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;
using SexShop.Model.Response;
using SexShop.Service.Interfaces;

namespace SexShop.Service.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public Task<IBaseResponse<IEnumerable<Image>>> GetImage()
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<IEnumerable<Image>>> GetImages(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Image>> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Image>> GetByLink(string link)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<Image>> Create(Image product)
    {
        throw new NotImplementedException();
    }

    public Task<IBaseResponse<bool>> Delete(int id)
    {
        throw new NotImplementedException();
    }
}