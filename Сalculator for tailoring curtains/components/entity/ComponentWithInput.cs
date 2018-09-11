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

        public ComponentWithInput(CanvasEntity entity) : base(entity)
        {
        }

        public ComponentWithInput(CanvasEntity entity, decimal min, decimal max, decimal step) : base(entity)
        {
            numericMin = min;
            numericMax = max;
            numericStep = step;
        }

        public void AddPropertyCanvas(PropertyCanvas property)
        {
            properties.Add(property);
        }

        public override void AddItemInList(string value)
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
                entity.removeProperty(properties[0]);
                properties[0].updateValue(numeric.Value);
                entity.addPropertyCanvas(properties[0]);
            }
        }

        private void CheckBox_ShowNumericComponent(object sender, EventArgs e)
        {
            numeric.Visible = checkBox.Checked;
            if (checkBox.Checked && properties.Count > 0)
            {
                properties[0].updateValue(numeric.Value);
                if (!entity.containsPropertyCanvas(properties[0]))
                {
                    foreach (PropertyCanvas p in properties)
                        entity.addPropertyCanvas(p);
                }
                else
                    entity.updateProperties();
            }
            else if (!checkBox.Checked && properties.Count > 0)
            {
                for(int i = 0; i < properties.Count; i++)
                    entity.removeProperty(properties[i]);
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
    }
}
