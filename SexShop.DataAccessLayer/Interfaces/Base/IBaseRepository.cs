namespace SexShop.DataAccessLayer.Interfaces.Base;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseRepository<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> Create(T entity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> Get(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<T>> Select();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> Delete(T entity);
}