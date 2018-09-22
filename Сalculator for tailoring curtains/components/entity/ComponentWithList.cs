using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    class ComponentWithList : AbstractComponent
    {
        public class ItemComponent
        {
            public string name;
            public decimal value;
            public decimal minNumeric;
            public decimal maxNumeric;
            public decimal stepNumeric;

            /*public ItemComponent(string name, decimal value)
            {
                this.name = name;
                this.value = value;
                this.minNumeric = 1;
                this.maxNumeric = 10;
                this.stepNumeric = 1;
            }*/

            public ItemComponent(string name, decimal value, decimal minNumeric = 1, decimal maxNumeric = 10, decimal stepNumeric = 1)
            {
                this.name = name;
                this.value = value;
                this.minNumeric = minNumeric;
                this.maxNumeric = maxNumeric;
                this.stepNumeric = stepNumeric;
            }
        }

        private static int count = 0;
        private string containText;
        private string description;
        private bool checkboxDefaultValue = false;
        private Dictionary<string, ItemComponent> keyValuePairs;
        private List<string> itemList;
        private List<decimal> valueList;
        private Button button;
        private ComboBox comboBox;
        private PictureBox picture;
        private CheckBox checkBox;
        private bool isFirstShowed = false;

        public ComponentWithList(CanvasEntity entity) : base(entity)
        {
            containText = "test value" + count++;
            keyValuePairs = new Dictionary<string, ItemComponent>();
            itemList = new List<string>();
            valueList = new List<decimal>();
        }

        public void AddPropertyCanvas(PropertyCanvas property)
        {
            property.name = containText;
            properties.Add(property);
        }

        public void AddKeyValue(string key, decimal value)
        {
            keyValuePairs.Add(key, new ItemComponent(key, value));
        }

        public override CalculationComponentsPanel getComponent()
        {
            CalculationComponentsPanel panel = new CalculationComponentsPanel();
            checkBox = new CheckBox();
            checkBox.Checked = checkboxDefaultValue;
            checkBox.Text = containText;
            checkBox.CheckedChanged += showList;
            checkBox.AutoSize = true;

            /*ColumnHeader imageHeader = new ColumnHeader();
            imageHeader.Text = "Images";
            imageHeader.Width = 300;
            imageHeader.TextAlign = HorizontalAlignment.Center;

            ColumnHeader descriptionHeader = new ColumnHeader();
            descriptionHeader.Text = "description";
            descriptionHeader.Width = 400;
            descriptionHeader.TextAlign = HorizontalAlignment.Left;*/
            comboBox = new ComboBox();
            comboBox.Text = "Выберите";
            comboBox.Visible = false;
            comboBox.DropDown += ComboBox_DropDown;
            comboBox.VisibleChanged += visibleChangedComboBox;

            //listView.View = View.List;
            //listView.Columns.Add(imageHeader);
            //listView.Columns.Add(descriptionHeader);
            foreach (string item in keyValuePairs.Keys.ToList<string>())
            {
                itemList.Add(item);
            }

            foreach(string text in itemList)
                comboBox.Items.Add(text);
            comboBox.SelectedValueChanged += selectedItem;
            
            panel.addControl(checkBox);
            panel.addControl(button);
            panel.addControl(comboBox);

            return panel;
        }

        private void ComboBox_DropDown(object sender, EventArgs e)
        {
        }

        private int DropDownWidth()
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in comboBox.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), comboBox.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        private void visibleChangedComboBox(object sender, EventArgs e)
        {
            if(comboBox.Visible == false)
            {
                foreach (PropertyCanvas p in properties)
                {
                    p.selected = null;
                    entity.removeProperty(p);
                }
            }
            else
            {
                if (comboBox.SelectedItem != null)
                {
                    foreach (PropertyCanvas p in properties)
                    {
                        p.selected = (string)comboBox.SelectedItem;
                        entity.addPropertyCanvas(p);
                    }
                }
            }
        }

        private void selectedItem(object sender, EventArgs e)
        {
            Console.Out.WriteLine(comboBox.SelectedText + " is selected (index = " + comboBox.SelectedIndex + ")");
            if (!isFirstShowed)
            {
                isFirstShowed = true;
                foreach (PropertyCanvas p in properties)
                {
                    entity.addPropertyCanvas(p);
                }
            }
            foreach (PropertyCanvas p in properties)
            {
                p.selected = (string)comboBox.SelectedItem;
            }
            if (keyValuePairs.ContainsKey((string)comboBox.SelectedItem)) {
                properties[0].updateValue(keyValuePairs[(string)comboBox.SelectedItem].value);
                entity.updateProperties();
            }
            //picture.Image = imageList[e.ItemIndex];
        }

        private void showList(object sender, EventArgs args)
        {
            comboBox.Visible = checkBox.Checked;
                
        }

        private void buttonAction(object sender, EventArgs args)
        {
        }

        public override void SetName(string text)
        {
            containText = text;
        }

        public override void SetDescription(string text)
        {
            description = text;
        }

        public override void AddItemInList(string value)
        {
            itemList.Add(value);
        }

        public void AddValueInList(decimal value)
        {
            valueList.Add(value);
        }

        public override void AddItemInList(string item, decimal value, decimal numMin, decimal numMax, decimal numStep)
        {
            keyValuePairs.Add(item, new ItemComponent(item, value, numMin, numMax, numStep));
        }
    }
}
