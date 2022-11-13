using System.ComponentModel.DataAnnotations;
using SexShop.Model;

namespace SexShop.Domain.Entity;

public class Product
{
    public int Id { get; set; }
    public int Article { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal OriginPrice { get; set; }
    public string VendorCode { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public string BarCode { get; set; }
    // public Material Material { get; set; }
    public int? Weight { get; set; }
    public decimal? Lenght {get; set; }
    public decimal? Diameter { get; set; }
    public string? Battery { get; set; }

    public int? ManufacturerId { get; set; }
    public int? SubCategoryId { get; set; }
    public virtual Manufacturer? Manufacturer { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Color> Colors { get; set; }
    public virtual ICollection<Pack> Packs { get; set; }
    public virtual ICollection<Material> Materials { get; set; }
    public virtual ICollection<Image> Images { get; set; }
    public virtual ICollection<ProductColor> ProductColor { get; set; }


    // public string Name { get; set; }
    // public string Name { get; set; }
    // public string Name { get; set; }
    // public string Name { get; set; }
}