﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Create(Product entity)
    {
        await _db.Products.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> Get(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x != null && x.Id == id);
    }

    public async Task<List<Product?>> Select()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<bool> Delete(Product entity)
    {
        _db.Products.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> GetByName(string name)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x != null && x.Name == name);
    }
}