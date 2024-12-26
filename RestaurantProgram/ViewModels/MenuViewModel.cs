using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantProgram.Models;

namespace RestaurantProgram.ViewModel
{
    internal class MenuViewModel:BaseViewModel
    {


        public List<string> MenuNames { get; set; }

        #region Свойства

        #endregion

        #region Методы

        public MenuViewModel()
        {
            MenuNames = new List<string>();
        }

        public void LoadMenuNames()
        {
            using (var context = new DBContext())
            {
                MenuNames = context.Menus.Select(m => m.Name).ToList();
            }
        }

        #endregion

        #region События

        #endregion
    }
}
