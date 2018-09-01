using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    abstract class AbstractComponent
    {
        public abstract CalculationComponentsPanel getComponent();
        public abstract void SetName(string text);
        public abstract void SetDescription(string text);
        public abstract void addKeyValue(string key, string value);
    }
}
