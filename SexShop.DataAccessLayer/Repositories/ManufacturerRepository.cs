using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="db"></param>
    public ManufacturerRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Manufacturer entity)
    {
        if (_db.Manufacturer.Any(x => x.Name == entity.Name)) return false;
        
        await _db.Manufacturer.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Manufacturer?> Get(int id)
    {
        return await _db.Manufacturer.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Manufacturer>> Select()
    {
        return await _db.Manufacturer.ToListAsync();
    }

    public Task<bool> Delete(Manufacturer entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Manufacturer> GetByName(string name)
    {
        return await _db.Manufacturer.FirstOrDefaultAsync(x => x.Name == name);
    }
}