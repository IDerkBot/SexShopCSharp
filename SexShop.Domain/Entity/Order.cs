namespace SexShop.Domain.Entity;

public class Order
{
    public int Id { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}