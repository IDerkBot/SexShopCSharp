using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

/// <summary>
/// 
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="db"></param>
    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    /// <summary>
    /// Добавление новой категории
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> Create(Category entity)
    {
        if (_db.Category.Any(x => x.Name == entity.Name)) return false;
        
        await _db.Category.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Category?> Get(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<Category>> Select()
    {
        return await _db.Category.ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<bool> Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Category> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}