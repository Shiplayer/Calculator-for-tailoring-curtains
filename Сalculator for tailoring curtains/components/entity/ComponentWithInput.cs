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
            set { propertyCanvas = value;
                properties.Add(value);
            }
        }

        public void AddPropertyCanvas(PropertyCanvas property)
        {
            properties.Add(property);
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
            numeric.ValueChanged += Numeric_ValueChanged;

            panel.addControl(checkBox);
            panel.addControl(numeric);
            return panel;
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            Console.Out.WriteLine(entity.ToString());
            if(properties.Count > 0)
            {
                Console.Out.WriteLine("valueChanged");
                properties[0].updateValue(numeric.Value);
                entity.updateProperties();
            }
        }

        private void CheckBox_ShowNumericComponent(object sender, EventArgs e)
        {
            numeric.Visible = checkBox.Checked;
            if (checkBox.Checked && propertyCanvas != null)
            {
                properties[0].updateValue(numeric.Value);
                entity.setPropertiesCanvas(properties);
            }
            else if (!checkBox.Checked && propertyCanvas != null)
            {
                entity.setPropertiesCanvas(null);
            }
            /*foreach(IObserver<CanvasEntityObserver> observer in listObservers)
            {

            }*/
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
            if (!listObservers.Contains(observer))
            {
                listObservers.Add(observer);
            }
            return new Unsubscriber<CanvasEntityObserver>(listObservers, observer);
        }
    }
}
