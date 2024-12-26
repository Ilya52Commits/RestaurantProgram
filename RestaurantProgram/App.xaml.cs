using RestaurantProgram.Models;
using System.Windows;

namespace RestaurantProgram;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /* Переменная для взаимодействия с базой данных */
    private readonly DBContext _dbContext = new();

   
    /// <summary>
    /// Виртуальный метод для логики перед запуском программы
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        var isProductExist = _dbContext.Products.Any();

        if (!isProductExist)
        {
            Product product1 = new Product 
            {
                Name = "Маэстро бургер",
                Description = "Острый маэстро бургер", 
                Сomposition = "Катлета, соус", 
                Type = "Бургер",
                Price = 414 
            };

            _dbContext.Products.Add(product1);
            _dbContext.SaveChanges();
        } 

        /* Вызов логики виртульного класса */
        base.OnStartup(e);
    }
}

