using Core.Domain;

namespace Core.Abstractions;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T?> GetByIdAsync(string id);
    
    public Task<IEnumerable<T?>> GetByPaginationAsync(int pageSize, int pageNumber);

    public Task<string> CreateAsync(T entity);
    public void CreateRange(IEnumerable<T> entity);


    public Task UpdateAsync(T entity);


    public Task DeleteAsync(string id);
}