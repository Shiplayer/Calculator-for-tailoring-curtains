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
        private List<string> valueComboBox;
        private string description;
        private bool checkboxDefaultValue = false;
        private ComboBox comboBox;
        private NumericUpDown numeric;
        private PropertyCanvas propertyCanvas;

        public ComponentWithListAndInput(CanvasEntity entity) : base(entity)
        {
            valueComboBox = new List<string>();
            //initValueList();
        }

        public PropertyCanvas PropertyCanvas
        {
            get { return propertyCanvas; }
            set { propertyCanvas = value; }
        }

        public override void AddValueInList(string value)
        {
            valueComboBox.Add(value);
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

            numeric = new NumericUpDown();
            numeric.DecimalPlaces = 2;
            numeric.Visible = false;
            numeric.Minimum = 0.1M;
            numeric.Increment = 0.1M;
            numeric.Maximum = 10;


            //listView.View = View.List;
            //listView.Columns.Add(imageHeader);
            //listView.Columns.Add(descriptionHeader);

            foreach (string text in valueComboBox)
                comboBox.Items.Add(text);
            comboBox.SelectedValueChanged += ComboBox_SelectedItem;

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

        private void ComboBox_SelectedItem(object sender, EventArgs e)
        {
            numeric.Visible = true;
        }

        private void showList(object sender, EventArgs eventArgs)
        {
            comboBox.Visible = checkBox.Checked;
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
            valueComboBox.Add("Простой подгиб");
            valueComboBox.Add("Московский шов");
            valueComboBox.Add("Косая бейка");
        }
    }
}
