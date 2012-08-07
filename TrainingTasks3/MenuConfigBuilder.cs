using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks3
{
    public class MenuConfigBuilder:IMenuConfigBuilder
    {
        public bool visible = true;
        public IEnumerable<MenuItem> menuItems;
        public MenuItem menuItem;
        private MenuConfig menuConfig;

        public MenuConfigBuilder()
        {

        }

        public MenuConfigBuilder(MenuConfig menuConfig)
        {
            // TODO: Complete member initialization
            this.menuConfig = menuConfig;
        }

        public void AddStatic(string p, string p_2)
        {
            menuItem.Text = p;
            menuItem.Url = p_2;

        }

        public void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func)
        {
            menuConfig.DynamicMenuItemsFunc = func;
        }

        public void Visible(Func<MenuContext, MenuItem, bool> func)
        {
            menuConfig.IsVisibleFunc = func;

        }
    }
}
