using Microsoft.EntityFrameworkCore;
using SexShop.DataAccessLayer.Interfaces;
using SexShop.Model;

namespace SexShop.DataAccessLayer.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool Create(Product entity)
    {
        throw new NotImplementedException();
    }

    public Product Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> Select()
    {
        return await _db.Products.ToListAsync();
    }

    public bool Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public Product GetByName(string name)
    {
        throw new NotImplementedException();
    }
}