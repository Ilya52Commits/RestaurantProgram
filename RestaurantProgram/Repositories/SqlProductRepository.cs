using Microsoft.EntityFrameworkCore;
using RestaurantProgram.EntityFramework;
using RestaurantProgram.EntityFramework.Models;

namespace RestaurantProgram.Repositories;

public class SqlProductRepository : IRepository<Product>
{
    private readonly Context _context = new();

    public IEnumerable<Product> GetObjectList()
    {
        return _context.Products;
    }

    public Product GetObject(int id)
    {
        return _context.Products.Find(id)!;
    }

    public void Create(Product item)
    {
        _context.Products.Add(item);
    }

    public void Update(Product item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);

        if (product != null)
            _context.Products.Remove(product);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if(!_disposed)
        {
            if(disposing)
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