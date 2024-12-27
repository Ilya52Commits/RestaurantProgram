using CommunityToolkit.Mvvm.Input;
using RestaurantProgram.Models;
using RestaurantProgram.View;
using RestaurantProgram.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace RestaurantProgram.ViewModels;
internal class BusketViewModel : BaseViewModel
{
    #region Свойства
    public ObservableCollection<Product> SelectProducts { get; set; }
    private int _price;
    public int Price
    {
        get => _price;
        private set
        {
            _price = value;
            RaisePropertyChanged(nameof(Price));
        }
    }

    public RelayCommand OrderCommand { get; set; }
    public RelayCommand RemoveCommand { get; set; }
    public RelayCommand<Product> RemoveProductCommand { get; set; }
    public RelayCommand NavigationToMainMenuView { get; set; } 
    #endregion

    #region Конструкторы
    public BusketViewModel(List<Product> selectProducts)
    {
        SelectProducts = new ObservableCollection<Product>(selectProducts);

        foreach (Product product in SelectProducts)
        {
            Price += (int)product.Price;
        }

        OrderCommand = new RelayCommand(OrderCommandExecute);
        RemoveCommand = new RelayCommand(RemoveCommandExecute);
        RemoveProductCommand = new RelayCommand<Product>(RemoveProductCommandExecute);
        NavigationToMainMenuView = new RelayCommand(NavigationToMainMenuViewExecute);
    }
    #endregion

    #region События
    public void OrderCommandExecute()
    {
        SelectProducts.Clear();
        Price = 0;
        MessageBox.Show("Ваш заказ выполнен!", "Успешно!");
    }

    public void RemoveProductCommandExecute(Product product)
    { 
        SelectProducts.Remove(product);       
        Price -= (int)product.Price;
    }

    public void RemoveCommandExecute()
    {
        SelectProducts.Clear();
    }

    public void NavigationToMainMenuViewExecute()
    {
        var opentWindow = new MainMenuView(SelectProducts.ToList());
        var busketWindows = Application.Current.Windows.OfType<BusketView>();

        opentWindow.Show();
        busketWindows.FirstOrDefault()?.Close(); // Закрываем все открытые окна типа BusketView
    }
    #endregion
}
