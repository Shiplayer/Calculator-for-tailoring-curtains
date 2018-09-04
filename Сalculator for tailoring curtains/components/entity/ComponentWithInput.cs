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
        private PropertyCanvas propertyCanvas;

        public ComponentWithInput(CanvasEntity entity) : base(entity)
        {
        }

        public ComponentWithInput(CanvasEntity entity, decimal min, decimal max, decimal step) : base(entity)
        {
            numericMin = min;
            numericMax = max;
            numericStep = step;
        }

        public PropertyCanvas PropertyCanvas
        {
            get { return propertyCanvas; }
            set { propertyCanvas = value; }
        }

        public override void AddValueInList(string value)
        {
            throw new NotImplementedException();
        }

        public override CalculationComponentsPanel getComponent()
        {
            CalculationComponentsPanel panel = new CalculationComponentsPanel();
            checkBox = new CheckBox();
            checkBox.Text = name;
            checkBox.AutoSize = true;
            checkBox.CheckedChanged += CheckBox_ShowNumericComponent;
            
            numeric = new NumericUpDown();
            numeric.Minimum = numericMin;
            numeric.Maximum = numericMax;
            numeric.DecimalPlaces = 2;
            numeric.Increment = numericStep;
            numeric.Visible = false;

            panel.addControl(checkBox);
            panel.addControl(numeric);
            return panel;
        }

        private void CheckBox_ShowNumericComponent(object sender, EventArgs e)
        {
            numeric.Visible = checkBox.Checked;
        }

        public override void SetDescription(string text)
        {
            throw new NotImplementedException();
        }

        public override void SetName(string text)
        {
            name = text;
        }

        public override IDisposable Subscribe(IObserver<CanvasEntityObserver> observer)
        {
            throw new NotImplementedException();
        }
    }
}
