using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantProgram.Models;

namespace RestaurantProgram.ViewModel
{
    internal class MenuViewModel:BaseViewModel
    {



        public ObservableCollection<string> MenuNames { get; set; }

        #region Свойства

        #endregion

        #region Методы


        public MenuViewModel()
        {
            MenuNames = new ObservableCollection<string>();
            LoadMenuNames();
        }

        public void LoadMenuNames()
        {
            using (var context = new DBContext())
            {
                var menuNames = context.Menus.Select(m => m.Name).ToList();
               
                foreach (var name in menuNames)
                {
                    MenuNames.Add(name); 
                }
            }
        }

        #endregion

        #region События

        #endregion
    }
}
