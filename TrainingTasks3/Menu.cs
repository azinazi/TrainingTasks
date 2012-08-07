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
        public static MenuConfig Config(Action<IMenuConfigBuilder> config)
        {
            MenuConfig menuConfig = new MenuConfig();
            MenuConfigBuilder menuConfigBuilder = new MenuConfigBuilder(menuConfig);

            config(menuConfigBuilder);
            return menuConfig;

        }

    }

}