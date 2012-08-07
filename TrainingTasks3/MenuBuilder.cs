using System.Collections.Generic;

namespace TrainingTasks3
{
    public class MenuBuilder
    {
        private readonly MenuContext _context;
        private readonly MenuConfig _config;

        public MenuBuilder(MenuContext context, MenuConfig config)
        {
            _context = context;
            _config = config;
        }

        public List<MenuItem> Build()
        {
            List<MenuItem> menuItmes = new List<MenuItem>();

            foreach (MenuItem menuItem in _config.StaticMenuItems)
            {
                if (_context.IsUserAdmin && !menuItem.Url.StartsWith("/admin"))
                    menuItmes.Add(menuItem);
            }


            //menuItmes.AddRange(_config.StaticMenuItems);

            // menuItmes.AddRange(_config.DynamicMenuItemsFunc);
            // _context.CurrentUrl

            return menuItmes;
        }
    }
}