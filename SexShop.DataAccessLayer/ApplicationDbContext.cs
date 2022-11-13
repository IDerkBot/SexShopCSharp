using Microsoft.EntityFrameworkCore;
using SexShop.Domain.Entity;
using SexShop.Model;

namespace SexShop.DataAccessLayer;

public sealed class ApplicationDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Product> Product { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Color> Color { get; set; }
    public DbSet<ProductColor> ProductColor { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Material> Material { get; set; }
    public DbSet<Pack> Pack { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    public DbSet<Image> Image { get; set; }
}