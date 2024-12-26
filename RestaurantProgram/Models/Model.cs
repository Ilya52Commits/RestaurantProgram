namespace RestaurantProgram.Models;

/// <summary>
/// Продукты
/// </summary>
public class Product
{
    public int Id { get; set; }             // primary key
    public string Name { get; set; }        // название продукта 
    public string Description { get; set; } // описание продукта
    public string Сomposition { get; set; } // состав продукта
    public string Type { get; set; }        // тип продукта
    public decimal Price { get; set; }      // цена продукта
}

/// <summary>
/// Комбо продуктов
/// </summary>
public class Combo
{
    public int Id { get; set; }                             // primary key
    public string Name { get; set; }                        // название комбо продуктов
    public List<ChooseProduct> ChooseProds { get; set; }    // коллекция выбраных продуктов
}

/// <summary>
/// Выбранные продукты
/// </summary>
public class ChooseProduct
{
    public int Id { get; set; }                 // primary key
    public List<Product> Prods { get; set; }    // коллекция продуктов
}

/// <summary>
/// Меню
/// </summary>
public class Menu
{
    public int Id { get; set; }                         // primary key
    public string Name { get; set; }                    // название меню
    public ICollection<Product> Prods { get; set; }     // коллекция продуктов
    public ICollection<Combo> Combos { get; set; }      // коллекция комбо продуктов
}
