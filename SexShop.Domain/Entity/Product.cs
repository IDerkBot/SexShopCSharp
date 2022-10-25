namespace SexShop.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal OriginPrice { get; set; }
    public string VendorCode { get; set; }
    public decimal Price { get; set; }
    public string Material { get; set; } // TODO Change
    public decimal Discount { get; set; }
    public string[] Pictures { get; set; }
    public uint BarCode { get; set; }
    public string Pack { get; set; } // TODO Change
    public ICollection<string> Colors { get; set; } // TODO Change
    public int Weight { get; set; }
    public decimal Lenght {get; set; }
    public decimal Diameter { get; set; }
    public string Battery { get; set; }
    
    
    public virtual Manufacture Manufacture { get; set; }
    public virtual SubCategory Category { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual Collection Collection { get; set; }

    // public string Name { get; set; }
    // public string Name { get; set; }
    // public string Name { get; set; }
    // public string Name { get; set; }
}