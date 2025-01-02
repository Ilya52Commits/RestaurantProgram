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

    public ObservableCollection<Menu> Menues { get; set; }
    private List<Product> SelectedProducts { get; set; }

    private WindowState _windowState;

    public WindowState WindowState
    {
        get => _windowState;
        set => Set(ref _windowState, value);
    }
    #endregion

    #region Конструкторы
    public MenuViewModel()
    {
        var context = new Context();   
        Menues = new ObservableCollection<Menu>(context.Menus.Include(menu => menu.Prods));
        SelectedProducts = [];
        WindowState = WindowState.Maximized;
    }

    public MenuViewModel(List<Product> selectedProducts)
    {
        var context = new Context();
        Menues = new ObservableCollection<Menu>(context.Menus.Include(menu => menu.Prods));
        SelectedProducts = selectedProducts;
    }   
    #endregion
    

    #region События
    [RelayCommand]
    private void AddToBasket(Product product) => SelectedProducts.Add(product);

    [RelayCommand]
    private void NavigateToBuketView()
    {
        var mainWindow = Application.Current.MainWindow as MainView;

        mainWindow?.MainFrame.NavigationService.Navigate(new BasketView(SelectedProducts));
    }
    #endregion
}
