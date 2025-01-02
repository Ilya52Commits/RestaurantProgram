using System.Windows.Controls;
using RestaurantProgram.EntityFramework.Models;
using RestaurantProgram.MVVM.ViewModels;

namespace RestaurantProgram.MVVM.Views;

public partial class MenuView
{
    public MenuView() => InitializeComponent();
    
    public MenuView(List<Product> products) 
    {
        InitializeComponent();

        /* Привязка объекта ViewModel к контексту данных */
        DataContext = new MenuViewModel(products);
    }
}