using Microsoft.EntityFrameworkCore;

namespace RestaurantProgram.Models;

internal class DBContext : Microsoft.EntityFrameworkCore.DbContext
{
    // строка подключения к базе данных
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-MGTPBOP;Database=RestaurantProgramDB;Trusted_Connection=True;TrustServerCertificate=True;");

    #region Объекты базы данных
    public DbSet<Product> Products { get; set; }
    public DbSet<Combo> Combos { get; set; }
    public DbSet<ChooseProduct> Choices { get; set; }
    public DbSet<Menu> Menus { get; set; }
    #endregion
}
