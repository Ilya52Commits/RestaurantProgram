using Microsoft.EntityFrameworkCore;
using RestaurantProgram.EntityFramework;
using RestaurantProgram.Repositories.Interfaces;

namespace RestaurantProgram.Repositories.Repositories;

public class Repository<T>(Context context) : IRepository<T>
  where T : class
{
  private readonly Context _context = context;
  private readonly DbSet<T> _dbSet = context.Set<T>();

  public async Task<IEnumerable<T?>> GetObjectList()
  {
    return await _dbSet.ToListAsync();
  }

  public async Task<T?> GetObject(int id)
  {
    return await _dbSet.FindAsync(id);
  }

  public async Task Create(T? item)
  {
    await _dbSet.AddAsync(item);
    await _context.SaveChangesAsync();
  }

  public async Task Update(T? item)
  {
    _dbSet.Update(item);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(int id)
  {
    _dbSet.Remove(await _dbSet.FindAsync(id));  
    await _context.SaveChangesAsync();
  }

  public async Task Save()
  {
    await _context.SaveChangesAsync();
  }  
  
  private bool _disposed;

  protected virtual void Dispose(bool disposing)
  {
    if (!_disposed)
    {
      if (disposing)
      {
        _context.Dispose();
      }
    }
    _disposed = true;
  }
    
  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }
}