using Core.Abstractions;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class EfRepository<T>(DataContext dataContext) : IRepository<T>
    where T : BaseEntity
{
    public Task<T?> GetByIdAsync(string id)
    {
        return dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T?>> GetByPaginationAsync(int pageSize, int pageNumber)
    {
        return await dataContext.Set<T>().AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public Task<string> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void CreateRange(IEnumerable<T> entity)
    {
        dataContext.Set<T>().AddRange(entity);
        dataContext.SaveChanges();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}