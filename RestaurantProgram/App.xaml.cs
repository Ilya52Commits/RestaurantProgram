using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
    /// Метод добавления сущностей для таблицы Product
    /// </summary>
    private void AddProductOnjects()
    {
        var isMenuExist = _dbContext.Menus.Any();
        var isProductExist = _dbContext.Products.Any();

        if (!isProductExist && !isMenuExist)
        {
            Menu burgerMenu = new Menu
            {
                Name = "Бургеры",
                Prods = new List<Product>(),
            };

            Menu rollMenu = new Menu
            {
                Name = "Роллы",
                Prods = new List<Product>(),
            };

            Menu frenchMenu = new Menu
            {
                Name = "Картофель",
                Prods = new List<Product>(),
            };

            Menu drinkMenu = new Menu
            {
                Name = "Напитки",
                Prods = new List<Product>(),
            };

            _dbContext.Menus.AddRange(burgerMenu, rollMenu, frenchMenu, drinkMenu);
            _dbContext.SaveChanges();

            Product firstBurgerObject = new Product
            {
                Name = "Маэстро бургер оригинальный",
                Description = "Для настоящих ценителей представляем - маэстро бургер оригенальный.",
                Сomposition = "Улочка бриошь, Филе куриное оригинальное, Соус Бургер классический, Сыр плавленый ломтевой, Огурцы маринованные, Салат айсберг.",
                MenuId = burgerMenu.Id, 
                Price = 239
            };

            Product secondBurgerObject = new Product
            {
                Name = "Маэстро бургер острый",
                Description = "Простая рецептура, продуманная до мелочей – для создания неповторимого вкуса премиального куриного бургера.",
                Сomposition = "Булочка бриошь, Соус Бургер классический, Сыр плавленый ломтевой, Огурцы маринованные, Салат айсберг, Филе куриное острое.",
                MenuId = burgerMenu.Id,
                Price = 239
            };

            Product thirdBurgerObject = new Product
            {
                Name = "Шефбургер оригенальный",
                Description = "В составе оригинального Шефбургера есть всё, чтобы вкусно и сытно перекусить. Нежная и сочная курица — главный ингредиент.",
                Сomposition = "Булочка с кунжутом, Филе Куриное оригинальное, Соус Цезарь, Томаты свежие, Салат Айсберг.",
                MenuId = burgerMenu.Id,
                Price = 179
            };

            Product fourthBurgerObject = new Product
            {
                Name = "Шефбургер острый",
                Description = "Состав острого Шефбургера прост и в меру наполнен любимыми ингредиентами.",
                Сomposition = "Филе куриное острое, Булочка с кунжутом, Соус Бургер, Салат Айсберг, Огурцы маринованные, Лук репчатый.",
                MenuId = burgerMenu.Id,
                Price = 179
            };

            _dbContext.Products.AddRange(firstBurgerObject, secondBurgerObject, thirdBurgerObject, fourthBurgerObject);

            Product firstRolleObject = new Product
            {
                Name = "Ростмастер острый",
                Description = "Нужно взбодриться и долго оставаться сытым? Попробуйте Ростмастер острый, состав которого еще и необычайно вкусен!",
                Сomposition = "Тортилья пшеничная, Филе куриное острое, Томаты свежие, Салат Айсберг, Сыр плавленый ломтевой, Картофель по-деревенски, Соус майонезный.",
                MenuId = rollMenu.Id,
                Price = 269
            };

            Product secondRolleObject = new Product
            {
                Name = "Ростмастер оригинальный",
                Description = "Невероятно вкусный и сытный Ростмастер оригинальный ждет тебя. Энергетическая ценность Ростмастера оригинального впечатляет!",
                Сomposition = "Тортилья пшеничная, Филе куриное оригинальное, Томаты свежие, Салат Айсберг, Сыр плавленый ломтевой, Картофель по-деревенски, Соус майонезный.",
                MenuId = rollMenu.Id,
                Price = 269
            };

            _dbContext.Products.AddRange(firstRolleObject, secondRolleObject);

            Product firstFrenchObject = new Product
            {
                Name = "Картофель фри",
                Description = "Закажите Картофель фри по вкусной цене! У нас он именно такой, каким любят его во всем мире — мягкий, рассыпчатый внутри и аппетитно хрустящий снаружи.",
                Сomposition = "Картофель фри (Картофель фри, масло растительное), Соль поваренная пищевая.",
                MenuId = frenchMenu.Id,
                Price = 77
            };

            Product secondFrenchObject = new Product
            {
                Name = "Картофель по-деревенски",
                Description = "Никто не готовит Картофель по-деревенски так, как делают это у нас!",
                Сomposition = "Картофель по-деревенски, Масло растительное.",
                MenuId = frenchMenu.Id,
                Price = 82
            };

            _dbContext.Products.AddRange(firstFrenchObject, secondFrenchObject);

            Product firstDrinkObject = new Product
            {
                Name = "Эвервесс Кола",
                Description = "И снова с нами! Любимый напиток, который идеально подходит к хрустящей курочке.",
                Сomposition = null,
                MenuId = drinkMenu.Id,
                Price = 129
            };

            Product secondDrinkObject = new Product
            {
                Name = "Фрустайл Апельсин",
                Description = "Лимонад Фрустайл Апельсин - удовольствие с первого глотка!",
                Сomposition = null,
                MenuId = drinkMenu.Id,
                Price = 129
            };

            _dbContext.Products.AddRange(firstDrinkObject, secondDrinkObject);
            _dbContext.SaveChanges();
        }
    }
  

    /// <summary>
    /// Виртуальный метод для логики перед запуском программы
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        if (!((RelationalDatabaseCreator)_dbContext.Database.GetService<IDatabaseCreator>()).Exists())
            _dbContext.Database.EnsureCreated();

        AddProductOnjects();


        /* Вызов логики виртульного класса */
        base.OnStartup(e);
    }
}

