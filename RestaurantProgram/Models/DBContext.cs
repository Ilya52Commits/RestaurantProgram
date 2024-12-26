using Microsoft.EntityFrameworkCore;

namespace RestaurantProgram.Model;

internal class DBContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");


}
