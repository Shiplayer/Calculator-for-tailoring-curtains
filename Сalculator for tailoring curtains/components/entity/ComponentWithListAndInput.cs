using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    class ComponentWithListAndInput : AbstractComponent
    {
        private string name;
        private CheckBox checkBox;
        private List<string> itemList;
        private List<decimal> valueList;
        private Dictionary<string, decimal> keyValuePairs;
        private string description;
        private bool checkboxDefaultValue = false;
        private ComboBox comboBox;
        private NumericUpDown numeric;
        private bool isFirstShowed = false;

        public ComponentWithListAndInput(CanvasEntity entity) : base(entity)
        {
            keyValuePairs = new Dictionary<string, decimal>();
            itemList = new List<string>();
            valueList = new List<decimal>();
            //initValueList();
        }

        public void AddKeyValue(string key, decimal value)
        {
            keyValuePairs.Add(key, value);
        }

        public ComponentWithListAndInput(CanvasEntity entity, decimal min, decimal max, decimal step) : base(entity)
        {
            numericMin = min;
            numericMax = max;
            numericStep = step;
        }

        public void AddPropertyCanvas(PropertyCanvas property)
        {
            property.name = name;
            properties.Add(property);
        }

        public override void AddItemInList(string value)
        {
            itemList.Add(value);
        }

        public override CalculationComponentsPanel getComponent()
        {
            CalculationComponentsPanel panel = new CalculationComponentsPanel();
            checkBox = new CheckBox();
            checkBox.Checked = checkboxDefaultValue;
            checkBox.Text = name;
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
            comboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox.VisibleChanged += visibleChangedComboBox;
            //comboBox.DropDown += ComboBox_DropDown;

            numeric = new NumericUpDown();
            numeric.DecimalPlaces = 1;
            numeric.Visible = false;
            numeric.Minimum = 1;
            numeric.Increment = 0.5M;
            numeric.Maximum = 10;
            numeric.ValueChanged += Numeric_ValueChanged;


            //listView.View = View.List;
            //listView.Columns.Add(imageHeader);
            //listView.Columns.Add(descriptionHeader);
            foreach (string item in keyValuePairs.Keys.ToList<string>())
            {
                itemList.Add(item);
            }
            foreach (string text in itemList)
                comboBox.Items.Add(text);
            //comboBox.Width = DropDownWidth() + 15;

            panel.addControl(checkBox);
            panel.addControl(comboBox);
            panel.addControl(numeric);
            /*if (imageList.Count == 1)
            {
                picture = new PictureBox();
                picture.Size = new Size(70, 70);

                picture.Image = imageList[0];
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                panel.addControl(picture);
            }*/
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
            if (!comboBox.Visible)
            {
                numeric.Visible = false;
                foreach(PropertyCanvas p in properties)
                {
                    p.selected = null;
                    entity.removeProperty(p);   
                }
            } else
            {
                if(comboBox.SelectedItem != null)
                {
                    numeric.Visible = true;
                    foreach (PropertyCanvas p in properties)
                    {
                        properties[0].updateValue(numeric.Value);
                        properties[0].selected = (string)comboBox.SelectedItem;
                        if (!entity.containsPropertyCanvas(p))
                            entity.addPropertyCanvas(p);
                    }
                    entity.updateProperties();
                }
            }
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            properties[0].updateValue(numeric.Value);
            entity.updateProperties();
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            numeric.Visible = true;
            if (!isFirstShowed)
            {
                isFirstShowed = true;
                foreach (PropertyCanvas p in properties)
                {
                    p.selected = (string)comboBox.SelectedItem;
                    properties[0].updateValue(numeric.Value);
                    if (!entity.containsPropertyCanvas(p))
                        entity.addPropertyCanvas(p);
                }
            }

            if (keyValuePairs.ContainsKey((string)comboBox.SelectedItem))
            {
                properties[0].updateValue(keyValuePairs[(string)comboBox.SelectedItem]);
                entity.updateProperties();
            }
        }

        private void showList(object sender, EventArgs eventArgs)
        {
            comboBox.Visible = checkBox.Checked;
            if (checkBox.Checked && properties.Count > 0)
            {
                /*if (comboBox.SelectedItem == null)
                {
                    properties[0].updateValue(numeric.Value);
                    if (!entity.containsPropertyCanvas(properties[0]))
                    {
                        foreach (PropertyCanvas p in properties)
                            entity.addPropertyCanvas(p);
                    }
                    else
                        entity.updateProperties();
                }*/
            }
        }

        public override void SetDescription(string text)
        {
            throw new NotImplementedException();
        }

        public override void SetName(string text)
        {
            name = text;
        }

        private void initValueList()
        {
            itemList.Add("Простой подгиб");
            itemList.Add("Московский шов");
            itemList.Add("Косая бейка");
        }

        public override void AddItemInList(string item, decimal value, decimal numMin, decimal numMax, decimal numStep)
        {
            throw new NotImplementedException();
        }
    }
}
