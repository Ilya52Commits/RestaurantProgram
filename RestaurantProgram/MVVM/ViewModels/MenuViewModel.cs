using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RestaurantProgram.EntityFramework;
using RestaurantProgram.EntityFramework.Models;
using RestaurantProgram.MVVM.Views;

namespace RestaurantProgram.MVVM.ViewModels;

internal partial class MenuViewModel : BaseViewModel
{
    #region Свойства

    /* Коллекция меню*/
    public ObservableCollection<Menu> Menues { get; set; }

    /* Коллекция выбранных продуктов */
    private List<Product> SelectedProducts { get; set; }

    /* Переменная состояния окна */
    private WindowState _windowState;

    /* Переменная изменения состояния окна */
    public WindowState WindowState
    {
        get => _windowState;
        set => Set(ref _windowState, value);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public MenuViewModel()
    {
        var context = new Context();
        Menues = new ObservableCollection<Menu>(context.Menus.Include(menu => menu.Prods));
        SelectedProducts = [];
        WindowState = WindowState.Maximized;
    }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="selectedProducts"></param>
    public MenuViewModel(List<Product> selectedProducts)
    {
        var context = new Context();
        Menues = new ObservableCollection<Menu>(context.Menus.Include(menu => menu.Prods));
        SelectedProducts = selectedProducts;
    }

    #endregion

    #region Команды

    /// <summary>
    /// Команда добавления продукта в корзину
    /// </summary>
    /// <param name="product"></param>
    [RelayCommand]
    private void AddToBasket(Product product) => SelectedProducts.Add(product);

    /// <summary>
    /// Команда перехода в корзину
    /// </summary>
    [RelayCommand]
    private void NavigateToBuketView()
    {
        var mainWindow = Application.Current.MainWindow as MainView;

        mainWindow?.MainFrame.NavigationService.Navigate(new BasketView(SelectedProducts));
    }

    #endregion
}