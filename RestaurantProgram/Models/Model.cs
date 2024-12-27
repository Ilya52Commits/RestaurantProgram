namespace RestaurantProgram.Models;

/// <summary>
/// Продукты
/// </summary>
public class Product
{
    public int Id { get; set; }             // primary key
    public string Name { get; set; }        // название продукта 
    public string Description { get; set; } // описание продукта
    public string? Сomposition { get; set; } // состав продукта
    public decimal Price { get; set; }      // цена продукта
    public int MenuId { get; set; }
    public virtual Menu Menu { get; set; }
}

/// <summary>
/// Меню
/// </summary>
public class Menu
{
    public int Id { get; set; }                         // primary key
    public string Name { get; set; }                    // название меню
    public ICollection<Product> Prods { get; set; } = new List<Product>(); // коллекция продуктов
}
