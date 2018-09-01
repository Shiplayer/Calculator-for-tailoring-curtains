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
        private List<string> valueList;
        private List<Image> imageList;
        private Button button;
        private ListView listView;
        private PictureBox picture;
        private CheckBox checkBox;

        public ComponentWithList()
        {
            containText = "test value" + count++;
            valueList = new List<string>();
            initValueList();
            imageList = new List<Image>();
            initImageList();
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

            listView = new ListView();
            listView.Visible = false;
            listView.FullRowSelect = true;
            listView.View = View.List;
            //listView.Columns.Add(imageHeader);
            //listView.Columns.Add(descriptionHeader);
            foreach(string text in valueList)
                listView.Items.Add(text);
            if(imageList.Count > 1)
                listView.ItemSelectionChanged += selectedItem;
            
            panel.addControl(checkBox);
            panel.addControl(button);
            panel.addControl(listView);
            if (imageList.Count == 1)
            {
                picture = new PictureBox();
                picture.Size = new Size(70, 70);

                picture.Image = imageList[0];
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                panel.addControl(picture);
            }
            return panel;
        }

        private void initValueList()
        {
            //valueList.
        }

        private void initImageList()
        {

        }

        private void selectedItem(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.Out.WriteLine(e.ItemIndex + " is selected");
            picture.Image = imageList[e.ItemIndex];
        }

        private void showList(object sender, EventArgs args)
        {
            listView.Visible = checkBox.Checked;
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

        public override void addKeyValue(string key, string value)
        {
            valueList.Add(key);
        }
    }
}
