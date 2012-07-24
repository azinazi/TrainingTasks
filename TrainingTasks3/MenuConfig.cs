
using System;
using System.Collections.Generic;
namespace TrainingTasks3
{
    public class MenuConfig : IMenuConfig
    {

        public MenuItem menuItem;
        public MenuContext menuContext;
        public IEnumerable<MenuItem> menuItems;
        public bool visibility;

        public MenuConfig(MenuItem menuItem, MenuContext menuContext)
        {
            this.menuItem = menuItem;
            this.menuContext = menuContext;
        }

        public MenuConfig()
        {
            menuItem = new MenuItem();
            menuContext = new MenuContext();
        }

        public void AddStatic(string url, string text)
        {
            this.menuItem.url = url;
            this.menuItem.text = text;
        }

        public void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> addDynamic)
        {
            menuItems = addDynamic(menuContext);
        }

        public void Visible(Func<MenuContext, MenuItem, bool> visible)
        {
            visibility = visible(menuContext, menuItem);
        }
    }
}