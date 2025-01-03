using Microsoft.EntityFrameworkCore;
using RestaurantProgram.EntityFramework;
using RestaurantProgram.EntityFramework.Models;

namespace RestaurantProgram.Repositories;

public class SqlMenuRepository : IRepository<Menu>
{
    private readonly Context _context = new();

    public IEnumerable<Menu> GetObjectList()
    {
        return _context.Menus;
    }

    public Menu GetObject(int id)
    {
        return _context.Menus.Find(id)!;
    }

    public void Create(Menu item)
    {
        _context.Menus.Add(item);
    }

    public void Update(Menu item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var menu = _context.Menus.Find(id);

        if (menu != null)
            _context.Menus.Remove(menu);
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

    








 