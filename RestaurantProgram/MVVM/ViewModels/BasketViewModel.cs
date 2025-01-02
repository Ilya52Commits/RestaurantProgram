using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using RestaurantProgram.EntityFramework.Models;
using RestaurantProgram.MVVM.Views;

namespace RestaurantProgram.MVVM.ViewModels;
internal partial class BasketViewModel : BaseViewModel
{
    #region Свойства

    public ObservableCollection<Product> SelectProducts { get; }
    private int _price;

    public int Price
    {
        get => _price;
        set
        {
            _price = value;
            RaisePropertyChanged();
        }
    }
    #endregion

    #region Конструкторы

    public BasketViewModel()
    {
        
    }
    public BasketViewModel(List<Product> selectProducts)
    {
        SelectProducts = new ObservableCollection<Product>(selectProducts);

        foreach (var product in SelectProducts)
        {
            Price += (int)product.Price;
        }
    }

    #endregion

    #region Команды
    [RelayCommand]
    private void Order()
    {
        SelectProducts.Clear();
        Price = 0;
        MessageBox.Show("Ваш заказ выполнен!", "Успешно!");
    }
    
    [RelayCommand]
    private void RemoveProduct(Product product)
    { 
        SelectProducts.Remove(product);       
        Price -= (int)product.Price;
    }

    [RelayCommand]
    private void Remove()
    {
        SelectProducts.Clear();
    }

    [RelayCommand]
    private void NavigationToMainMenuView()
    {
        var mainWindow = Application.Current.MainWindow as MainView;

        mainWindow?.MainFrame.NavigationService.Navigate(new MenuView());
    }
    #endregion
}
