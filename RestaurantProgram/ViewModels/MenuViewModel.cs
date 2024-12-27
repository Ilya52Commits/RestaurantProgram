using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RestaurantProgram.Models;
using RestaurantProgram.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace RestaurantProgram.ViewModel;
internal class MenuViewModel : BaseViewModel
{
    #region Свойства
    private readonly DBContext _dbContext;

    public ObservableCollection<Menu> Menues { get; set; }
    private List<Product> _selectedProducts { get; set; }

    public RelayCommand<Product> AddToBascketCommand { get; set; } 
    public RelayCommand NavigateToBusketViewCommand { get; set; }

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
        _dbContext = new DBContext();   
        Menues = new ObservableCollection<Menu>(_dbContext.Menus.Include(menu => menu.Prods));
        _selectedProducts = new List<Product>();
        WindowState = WindowState.Maximized; // Окно будет открываться в максимизированном состоянии

        AddToBascketCommand = new RelayCommand<Product>(AddToBascketCommandExecute);
        NavigateToBusketViewCommand = new RelayCommand(NavigateToBusketViewCommandExecute);
    }

    public MenuViewModel(List<Product> selectedProducts)
    {
        _dbContext = new DBContext();
        Menues = new ObservableCollection<Menu>(_dbContext.Menus.Include(menu => menu.Prods));
        _selectedProducts = selectedProducts;

        AddToBascketCommand = new RelayCommand<Product>(AddToBascketCommandExecute);
        NavigateToBusketViewCommand = new RelayCommand(NavigateToBusketViewCommandExecute);

    }   
    #endregion

    #region Методы
    
    #endregion

    #region События
    public void AddToBascketCommandExecute(Product product)
    {
        _selectedProducts.Add(product);
    }

    public void NavigateToBusketViewCommandExecute()
    {
        var busketWindow = new BusketView(_selectedProducts);
        var openWindows = Application.Current.Windows.OfType<MainMenuView>();

        busketWindow.Show();
        openWindows.FirstOrDefault()?.Close(); // Закрываем все открытые окна типа BusketView
    }
    #endregion
}
