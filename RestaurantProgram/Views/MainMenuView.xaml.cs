using RestaurantProgram.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainMenuWindowView : Window
    {
        public MainMenuWindowView()
        {
           
            var viewModel = new MenuViewModel();
            viewModel.LoadMenuNames(); // Загружаем названия меню
            this.DataContext = viewModel; // Устанавливаем DataContext
        }
    }
}
