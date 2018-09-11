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
        private static int count = 0;
        private string containText;
        private string description;
        private bool checkboxDefaultValue = false;
        private Dictionary<string, decimal> keyValuePairs;
        private List<string> itemList;
        private List<decimal> valueList;
        private Button button;
        private ComboBox comboBox;
        private PictureBox picture;
        private CheckBox checkBox;

        public ComponentWithList(CanvasEntity entity) : base(entity)
        {
            containText = "test value" + count++;
            keyValuePairs = new Dictionary<string, decimal>();
            itemList = new List<string>();
            valueList = new List<decimal>();
        }

        public void AddPropertyCanvas(PropertyCanvas property)
        {
            properties.Add(property);
        }

        public void AddKeyValue(string key, decimal value)
        {
            keyValuePairs.Add(key, value);
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

        private void selectedItem(object sender, EventArgs e)
        {
            Console.Out.WriteLine(comboBox.SelectedText + " is selected (index = " + comboBox.SelectedIndex + ")");
            if (keyValuePairs.ContainsKey((string)comboBox.SelectedItem)) {
                properties[0].updateValue(keyValuePairs[(string)comboBox.SelectedItem]);
                entity.updateProperties();
            }
            //picture.Image = imageList[e.ItemIndex];
        }

        private void showList(object sender, EventArgs args)
        {
            comboBox.Visible = checkBox.Checked;
            if(checkBox.Checked)
                foreach(PropertyCanvas p in properties)
                {
                    entity.addPropertyCanvas(p);
                }
            else
                foreach(PropertyCanvas p in properties)
                {
                    entity.removeProperty(p);
                }
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
    }
}
