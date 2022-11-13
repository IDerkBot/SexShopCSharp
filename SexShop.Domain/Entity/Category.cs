namespace SexShop.Domain.Entity;

/// <summary>
/// Категория продукта
/// </summary>
public class Category
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
    /// Под категории
    /// </summary>
    public virtual ICollection<SubCategory> SubCategories { get; set; }
}