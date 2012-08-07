using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks3
{
    public interface IMenuConfigBuilder
    {
         void AddStatic(string url, string text);

         void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> addDynamic);

         void Visible(Func<MenuContext, MenuItem, bool> visible);

    }
}
