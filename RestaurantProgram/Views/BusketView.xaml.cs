using RestaurantProgram.Models;
using RestaurantProgram.ViewModels;
using System.Windows;

namespace RestaurantProgram.View
{
    /// <summary>
    /// Логика взаимодействия для BusketView.xaml
    /// </summary>
    public partial class BusketView : Window
    {
        public BusketView(List<Product> selectedProducts)
        {
            InitializeComponent();

            /* Привязка объекта ViewModel к контексту данных */
            DataContext = new BusketViewModel(selectedProducts);
        }
    }
}
    