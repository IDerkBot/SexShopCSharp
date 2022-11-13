using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class PackRepository : IPackRepository
{
    private readonly ApplicationDbContext _db;

    public PackRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Pack entity)
    {
        if (_db.Pack.Any(x => x.Name == entity.Name)) return false;
        
        await _db.Pack.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<Pack?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pack>> Select()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Pack entity)
    {
        throw new NotImplementedException();
    }
}