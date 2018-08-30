using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    interface IComponent
    {
        CalculationComponentsPanel getComponent();
        void SetName(string text);
        void SetDescription(string text);
        void addKeyValue(string key, string value);
    }
}
