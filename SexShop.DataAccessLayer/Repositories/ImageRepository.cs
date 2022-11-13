using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _db;

    public ImageRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(Image entity)
    {
        await _db.Image.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Image?> Get(int id)
    {
        return await _db.Image.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Image>> Select()
    {
        return await _db.Image.ToListAsync();
    }

    public async Task<bool> Delete(Image entity)
    {
        _db.Image.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Image?> GetByProduct(Product product)
    {
        return await _db.Image.FirstOrDefaultAsync(x => x.Product.Id == product.Id);
    }

    public Task<List<Image>> GetAllByProduct(Product product)
    {
        return Task.FromResult(_db.Image.Where(x => x.Product.Id == product.Id).ToList());
    }
}