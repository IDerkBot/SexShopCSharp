namespace SexShop.Domain.Entity;

/// <summary>
/// Коллекция продукта
/// </summary>
public class Collection
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Продукты в этой коллекции
    /// </summary>
    public virtual ICollection<Product> Products { get; set; }
}