using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

/// <summary>
/// 
/// </summary>
public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly ApplicationDbContext _db;

    public SubCategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> Create(SubCategory entity)
    {
        if (_db.SubCategory.Any(x => x.Name == entity.Name && x.Category.Name == entity.Category.Name)) return false;
        
        await _db.SubCategory.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public Task<SubCategory?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SubCategory>> Select()
    {
        return await _db.SubCategory.ToListAsync();
    }

    public Task<bool> Delete(SubCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}