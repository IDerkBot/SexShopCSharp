using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

/// <summary>
/// 
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="db"></param>
    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> Create(Product entity)
    {
        await _db.Product.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Product?> Get(int id)
    {
        return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<Product>> Select()
    {
        return await _db.Product.ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> Delete(Product entity)
    {
        _db.Product.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<Product?> GetByName(string name)
    {
        return await _db.Product.FirstOrDefaultAsync(x => x.Name == name);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public async Task AddImage(Product product, Image image)
    {
        var productForChange = await _db.Product.FirstOrDefaultAsync(x => x.Id == product.Id);
        productForChange?.Images.Add(image);
        await _db.SaveChangesAsync();
    }
}