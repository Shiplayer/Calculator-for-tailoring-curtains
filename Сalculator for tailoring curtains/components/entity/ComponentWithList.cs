using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    class ComponentWithList : ISubEntity
    {
        private static int count = 0;
        private string containText;
        private bool checkboxDefaultValue = false;
        private List<string> valueList;
        private List<Image> imageList;
        private Button button;
        private ListView listView;

        public ComponentWithList()
        {
            containText = "test value" + count++;
            valueList = new List<string>();
            imageList = new List<Image>();
        }

        public CalculationComponentsPanel getComponent()
        {
            CalculationComponentsPanel panel = new CalculationComponentsPanel();
            CheckBox checkBox = new CheckBox();
            checkBox.Checked = checkboxDefaultValue;
            checkBox.Text = containText;
            checkBox.CheckedChanged += new EventHandler(showList);
            button = new Button();
            button.Text = "Показать список";
            button.Visible = false;
            button.Click += new EventHandler(buttonAction);
            listView = new ListView();
            ColumnHeader imageHeader = new ColumnHeader();
            imageHeader.Text = "Images";
            imageHeader.Width = 300;
            imageHeader.TextAlign = HorizontalAlignment.Center;
            ColumnHeader descriptionHeader = new ColumnHeader();
            descriptionHeader.Text = "description";
            descriptionHeader.Width = 400;
            descriptionHeader.TextAlign = HorizontalAlignment.Left;
            listView.Columns.Add(imageHeader);
            listView.Columns.Add(descriptionHeader);
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.
            listView.Items.Add()
            panel.addControl(checkBox);
            panel.addControl(button);
            return panel;
        }

        private void showList(object sender, EventArgs args)
        {
            Console.Out.WriteLine("hello");
            if (button.Visible)
                button.Visible = false;
            else
                button.Visible = true;
        }

        private void buttonAction(object sender, EventArgs args)
        {
            Console.Out.WriteLine("show list from " + containText);
        }


    }
}
