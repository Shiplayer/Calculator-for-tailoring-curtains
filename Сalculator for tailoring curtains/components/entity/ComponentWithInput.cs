using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    class ComponentWithInput : AbstractComponent
    {
        private string name;
        private CheckBox checkBox;
        private string description;
        private bool checkboxDefaultValue = false;
        private NumericUpDown numeric;
        private TYPE_OF_PROPERTIES type;

        public ComponentWithInput()
        {
            numeric = new NumericUpDown();
            numeric.Minimum = 1;
            numeric.Maximum = 200;
        }

        public override void AddValueInList(string value)
        {
            throw new NotImplementedException();
        }

        public override CalculationComponentsPanel getComponent()
        {
            throw new NotImplementedException();
        }

        public override void SetDescription(string text)
        {
            throw new NotImplementedException();
        }

        public override void SetName(string text)
        {
            throw new NotImplementedException();
        }
    }
}
