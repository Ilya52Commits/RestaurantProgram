using Microsoft.EntityFrameworkCore;

namespace RestaurantProgram.Models;

internal class DBContext : Microsoft.EntityFrameworkCore.DbContext
{
    /* Строка подключения к базе данных SQL Server */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-34SGMAN\LOCALDB;Database=RestaurantProgramDB;Trusted_Connection=True;TrustServerCertificate=True;");

    #region Объекты базы данных
    public DbSet<Product> Products { get; set; }        // Объект таблицы продукта
    public DbSet<Menu> Menus { get; set; }              // Объект таблицы меню
    #endregion
}
