namespace SexShop.Domain.Entity;

public class Image
{
    public int Id { get; set; }
    public string Link { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}