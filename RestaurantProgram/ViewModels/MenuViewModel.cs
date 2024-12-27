using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RestaurantProgram.Models;
using System.Collections.ObjectModel;

namespace RestaurantProgram.ViewModel;
internal class MenuViewModel : BaseViewModel
{
    #region Свойства
    private readonly DBContext _dbContext;

    public ObservableCollection<Menu> Menues { get; set; }
    private List<Product> _selectedProducts { get; set; }

    public RelayCommand<Product> AddToBascketCommand { get; set; } 
    #endregion

    #region Конструкторы
    public MenuViewModel()
    {
        _dbContext = new DBContext();   
        Menues = new ObservableCollection<Menu>(_dbContext.Menus.Include(menu => menu.Prods));
        _selectedProducts = new List<Product>();

        AddToBascketCommand = new RelayCommand<Product>(AddToBascketCommandExecute); 
    }
    #endregion

    #region Методы
    public void AddToBascketCommandExecute(Product product)
    {
        _selectedProducts.Add(product);
    }
    #endregion

    #region События

    #endregion
}
