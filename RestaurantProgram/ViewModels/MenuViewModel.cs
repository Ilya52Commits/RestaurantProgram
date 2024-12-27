using Microsoft.EntityFrameworkCore;
using RestaurantProgram.Models;
using System.Collections.ObjectModel;

namespace RestaurantProgram.ViewModel;
internal class MenuViewModel : BaseViewModel
{
    #region Свойства
    private readonly DBContext _dbContext; 
    public ObservableCollection<Menu> Menues { get; set; }
    #endregion

    #region Конструкторы
    public MenuViewModel()
    {
        _dbContext = new DBContext();   
        Menues = new ObservableCollection<Menu>(_dbContext.Menus.Include(menu => menu.Prods));
    }
    #endregion

    #region Методы

    #endregion

    #region События

    #endregion
}
