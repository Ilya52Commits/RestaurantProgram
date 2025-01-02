using System.Windows.Controls;
using RestaurantProgram.EntityFramework.Models;
using RestaurantProgram.MVVM.ViewModels;

namespace RestaurantProgram.MVVM.Views;

public partial class BasketView : Page
{
    public BasketView(List<Product> selectedProducts)
    {
        InitializeComponent();
        
        /* Привязка объекта ViewModel к контексту данных */
        DataContext = new BasketViewModel(selectedProducts);
    }
}