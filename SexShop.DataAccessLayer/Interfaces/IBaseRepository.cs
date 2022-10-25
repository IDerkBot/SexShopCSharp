using SexShop.Model;

namespace SexShop.DataAccessLayer.Interfaces;

public interface IBaseRepository<T>
{
    public bool Create(T entity);

    public T Get(int id);

    public Task<List<Product>> Select();

    public bool Delete(T entity);
}