using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class ColorRepository : IColorRepository
{
    private readonly ApplicationDbContext _db;

    public ColorRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(Color entity)
    {
        if (await _db.Color.AnyAsync(x => x.Name == entity.Name)) return false;
        
        await _db.Color.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Color?> Get(int id)
    {
        return await _db.Color.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Color>> Select()
    {
        return await _db.Color.ToListAsync();
    }

    public async Task<bool> Delete(Color entity)
    {
        _db.Color.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Color?> GetByName(string name)
    {
        return await _db.Color.FirstOrDefaultAsync(x => x.Name == name);
    }
}