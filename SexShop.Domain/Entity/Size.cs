namespace SexShop.Domain.Entity;

public class Size
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}