using RestaurantProgram.Models;
using RestaurantProgram.ViewModel;
using System.Windows;

namespace RestaurantProgram.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainMenuView : Window
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        public MainMenuView(List<Product> products) 
        {
            InitializeComponent();

            /* Привязка объекта ViewModel к контексту данных */
            DataContext = new MenuViewModel(products);
        }
    }
}
