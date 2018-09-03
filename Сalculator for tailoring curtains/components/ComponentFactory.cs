using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    class ComponentFactory
    {
        public static AbstractComponent getComponent(int type)
        {
            if(type == 0)
            {
                return null;//new entity.ComponentWithList();
            }
            return null;
        }
    }
}
