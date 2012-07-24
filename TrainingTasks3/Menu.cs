using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks3
{
    public class Menu
    {
        public static MenuConfig Config(Action<MenuConfig> config)
        {
            MenuConfig menuConfig = new MenuConfig();
            config(menuConfig);
            return menuConfig;

        }

    }

}