using System.ComponentModel.DataAnnotations;

namespace SexShop.Domain.Entity;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string HexCode { get; set; }

    public virtual ICollection<ProductColor> ProductColor { get; set; }
}