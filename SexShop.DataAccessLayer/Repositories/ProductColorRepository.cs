using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class ProductColorRepository : IProductColorRepository
{
    private readonly ApplicationDbContext _db;
    
    public ProductColorRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(ProductColor entity)
    {
        await _db.ProductColor.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<ProductColor?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductColor>> Select()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(ProductColor entity)
    {
        throw new NotImplementedException();
    }
}