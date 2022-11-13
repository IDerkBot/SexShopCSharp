using SexShop.DataAccessLayer.Interfaces;
using SexShop.Domain.Entity;

namespace SexShop.DataAccessLayer.Repositories;

public class MaterialRepository : IMaterialRepository
{
    public Task<bool> Create(Material entity)
    {
        throw new NotImplementedException();
    }

    public Task<Material?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Material>> Select()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Material entity)
    {
        throw new NotImplementedException();
    }
}