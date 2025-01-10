namespace RestaurantProgram.Repositories.Interfaces;

public interface IRepository<T> : IDisposable
    where T : class
{
    public Task<IEnumerable<T?>> GetObjectList();
    public Task<T?> GetObject(int id);
    public Task Create(T? item);
    public Task Update(T? item);
    public Task Delete(int id);
    public Task Save();
}