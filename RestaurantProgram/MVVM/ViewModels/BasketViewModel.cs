using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using RestaurantProgram.EntityFramework.Models;
using RestaurantProgram.MVVM.Views;

namespace RestaurantProgram.MVVM.ViewModels;

internal partial class BasketViewModel : BaseViewModel
{
    #region Свойства
    
    /* Коллекция выбранных продуктов */
    public ObservableCollection<Product> SelectProducts { get; }
    
    /* Значение цены */
    private int _price;
    
    /* Изменяемый параметр цены */ 
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

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public BasketViewModel()
    {
        SelectProducts = [];   
        Price = 0;
    }
    
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="selectProducts"></param>
    public BasketViewModel(List<Product> selectProducts)
    {
        SelectProducts = new ObservableCollection<Product>(selectProducts);

        foreach (var product in SelectProducts)
            Price += (int)product.Price!;
    }

    #endregion

    #region Команды
    /// <summary>
    /// Команда выполнения заказа
    /// </summary>
    [RelayCommand]
    private void Order()
    {
        SelectProducts.Clear();
        Price = 0;
        MessageBox.Show("Ваш заказ выполнен!", "Успешно!");
    }
    
    /// <summary>
    /// Команда удаления продукта из корзины
    /// </summary>
    /// <param name="product"></param>
    [RelayCommand]
    private void RemoveProduct(Product product)
    { 
        SelectProducts.Remove(product);       
        Price -= (int)product.Price!;
    }

    /// <summary>
    /// Команда очистки корзины
    /// </summary>
    [RelayCommand]
    private void Remove()
    {
        SelectProducts.Clear();
        Price = 0;  
    }

    /// <summary>
    /// Команда перехода в меню из корзины
    /// </summary>
    [RelayCommand]
    private void NavigationToMainMenuView()
    {
        var mainWindow = Application.Current.MainWindow as MainView;

        mainWindow?.MainFrame.NavigationService.Navigate(new MenuView(SelectProducts.ToList()));
    }
    #endregion
}
