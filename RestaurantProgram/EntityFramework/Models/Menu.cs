namespace RestaurantProgram.EntityFramework.Models;

/// <summary>
/// Описание таблицы меню
/// </summary>
public class Menu
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public virtual ICollection<Product> Prods { get; set; } = new List<Product>();
}
