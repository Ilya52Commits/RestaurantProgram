using Microsoft.EntityFrameworkCore;
using RestaurantProgram.EntityFramework.Models;

namespace RestaurantProgram.EntityFramework;

/// <summary>
/// Контекст подключения и создания базы данных, а также наполнения базы начальными данными
/// </summary>
internal sealed class Context : DbContext
{
    #region Объекты базы данных

    public DbSet<Product> Products { get; set; }
    public DbSet<Menu> Menus { get; set; }

    #endregion

    /* Конструктор */
    public Context()
    {
        Database.EnsureCreated();
    }

    /* Строка подключения к MS SQL */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-MGTPBOP;Database=RestaurantProgramDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    /// <summary>
    /// Метод добавления моделей
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Инициализация объектов для таблицы Menu

        var burgerMenu = new Menu { Id = 1, Name = "Бургеры", Prods = new List<Product>() };
        var rollMenu = new Menu { Id = 2, Name = "Роллы", Prods = new List<Product>() };
        var frenchMenu = new Menu { Id = 3, Name = "Картофель", Prods = new List<Product>() };
        var drinkMenu = new Menu { Id = 4, Name = "Напитки", Prods = new List<Product>() };

        #endregion

        #region Инициализация объектов для таблицы Product

        var firstBurgerObject = new Product
        {
            Id = 1, Name = "Маэстро бургер оригинальный",
            Description = "Для настоящих ценителей представляем - маэстро бургер оригенальный.",
            Сomposition =
                "Улочка бриошь, Филе куриное оригинальное, Соус Бургер классический, Сыр плавленый ломтевой, Огурцы маринованные, Салат айсберг.",
            MenuId = burgerMenu.Id, Price = 239
        };

        var secondBurgerObject = new Product
        {
            Id = 2, Name = "Маэстро бургер острый",
            Description =
                "Простая рецептура, продуманная до мелочей – для создания неповторимого вкуса премиального куриного бургера.",
            Сomposition =
                "Булочка бриошь, Соус Бургер классический, Сыр плавленый ломтевой, Огурцы маринованные, Салат айсберг, Филе куриное острое.",
            MenuId = burgerMenu.Id, Price = 239
        };

        var thirdBurgerObject = new Product
        {
            Id = 3, Name = "Шефбургер оригенальный",
            Description =
                "В составе оригинального Шефбургера есть всё, чтобы вкусно и сытно перекусить. Нежная и сочная курица — главный ингредиент.",
            Сomposition = "Булочка с кунжутом, Филе Куриное оригинальное, Соус Цезарь, Томаты свежие, Салат Айсберг.",
            MenuId = burgerMenu.Id, Price = 179
        };

        var fourthBurgerObject = new Product
        {
            Id = 4, Name = "Шефбургер острый",
            Description = "Состав острого Шефбургера прост и в меру наполнен любимыми ингредиентами.",
            Сomposition =
                "Филе куриное острое, Булочка с кунжутом, Соус Бургер, Салат Айсберг, Огурцы маринованные, Лук репчатый.",
            MenuId = burgerMenu.Id, Price = 179
        };


        var firstRolleObject = new Product
        {
            Id = 5, Name = "Ростмастер острый",
            Description =
                "Нужно взбодриться и долго оставаться сытым? Попробуйте Ростмастер острый, состав которого еще и необычайно вкусен!",
            Сomposition =
                "Тортилья пшеничная, Филе куриное острое, Томаты свежие, Салат Айсберг, Сыр плавленый ломтевой, Картофель по-деревенски, Соус майонезный.",
            MenuId = rollMenu.Id, Price = 269
        };

        var secondRolleObject = new Product
        {
            Id = 6, Name = "Ростмастер оригинальный",
            Description =
                "Невероятно вкусный и сытный Ростмастер оригинальный ждет тебя. Энергетическая ценность Ростмастера оригинального впечатляет!",
            Сomposition =
                "Тортилья пшеничная, Филе куриное оригинальное, Томаты свежие, Салат Айсберг, Сыр плавленый ломтевой, Картофель по-деревенски, Соус майонезный.",
            MenuId = rollMenu.Id, Price = 269
        };


        var firstFrenchObject = new Product
        {
            Id = 7, Name = "Картофель фри",
            Description =
                "Закажите Картофель фри по вкусной цене! У нас он именно такой, каким любят его во всем мире — мягкий, рассыпчатый внутри и аппетитно хрустящий снаружи.",
            Сomposition = "Картофель фри (Картофель фри, масло растительное), Соль поваренная пищевая.",
            MenuId = frenchMenu.Id, Price = 77
        };

        var secondFrenchObject = new Product
        {
            Id = 8, Name = "Картофель по-деревенски",
            Description = "Никто не готовит Картофель по-деревенски так, как делают это у нас!",
            Сomposition = "Картофель по-деревенски, Масло растительное.",
            MenuId = frenchMenu.Id, Price = 82
        };

        var firstDrinkObject = new Product
        {
            Id = 9, Name = "Эвервесс Кола",
            Description = "И снова с нами! Любимый напиток, который идеально подходит к хрустящей курочке.",
            Сomposition = null,
            MenuId = drinkMenu.Id, Price = 129
        };

        var secondDrinkObject = new Product
        {
            Id = 10, Name = "Фрустайл Апельсин",
            Description = "Лимонад Фрустайл Апельсин - удовольствие с первого глотка!",
            Сomposition = null,
            MenuId = drinkMenu.Id, Price = 129
        };

        #endregion

        #region Добавление данных в БД

        modelBuilder.Entity<Menu>().HasData(burgerMenu, rollMenu, frenchMenu, drinkMenu);
        modelBuilder.Entity<Product>().HasData(firstBurgerObject,
            secondBurgerObject,
            firstRolleObject,
            secondRolleObject,
            firstFrenchObject,
            secondFrenchObject,
            firstDrinkObject,
            secondDrinkObject);

        #endregion
    }
}