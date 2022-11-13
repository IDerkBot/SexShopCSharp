namespace SexShop.Domain.Entity;

public class ProductColor
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }

    public virtual Product Product { get; set; }
    public virtual Color Color { get; set; }
}