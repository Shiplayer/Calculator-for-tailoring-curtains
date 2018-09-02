using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сalculator_for_tailoring_curtains.Properties;
using Сalculator_for_tailoring_curtains.components;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucCanvas : UserControl
    {
        private string stWidthTitleLabel = "Ширина собранной";
        private string stWidthExtendedTitleLabel = "Ширина тюля расправленного";
        private string stHeightTitleLable = "Высота без учёта припусков";
        private string stCountOfSplited = "Количество частей";
        private string stGroupBoxTitle = "Тюль ";
        private static ucCanvas _instance;
        private List<GroupBox> groupBoxes;

        public static ucCanvas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucCanvas();
                    _instance.Dock = DockStyle.Fill;
                }
                return _instance;
            }
        }
        public ucCanvas()
        {
            InitializeComponent();
            groupBoxes = new List<GroupBox>();
            tableLayoutPanel1.Controls.Clear();
            /*groupBoxes.Add(AddNewCanvasPanel());
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Controls.Add(groupBoxes[groupBoxes.Count - 1]);*/
            CanvasPanel canvasPanel = new CanvasPanel();
            canvasPanel.RemoveCanvas += RemoveCanvas;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Controls.Add(canvasPanel);
            //createOutlookUI();
        }

        private void RemoveCanvas(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove((CanvasPanel)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanvasPanel box = new CanvasPanel
            {
                Text = stGroupBoxTitle + (groupBoxes.Count + 1)
            };
            box.RemoveCanvas += RemoveCanvas;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Controls.Add(box);
            groupBoxes.Add(box);
        }

        private GroupBox AddNewCanvasPanel()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = stGroupBoxTitle + (groupBoxes.Count + 1);
            SplitContainer container = new SplitContainer();
            container.Orientation = Orientation.Vertical;
            container.SplitterDistance = 290;
            container.SplitterWidth = 4;
            container.Location = new Point(6, 19);
            container.Size = new Size(673, 124);
            container.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Dock = DockStyle.Fill;
            InitLabel(panel.Controls);
            container.Panel1.Controls.Add(panel);
            FlowLayoutPanel panelUpDownNumeric = new FlowLayoutPanel();
            panelUpDownNumeric.FlowDirection = FlowDirection.TopDown;
            panelUpDownNumeric.AutoSize = true;
            panelUpDownNumeric.Dock = DockStyle.Fill;
            panelUpDownNumeric.Controls.Add(new NumericUpDown());
            container.Panel2.Controls.Add(panelUpDownNumeric);
            groupBox.Controls.Add(container);
            return groupBox;
        }

        private void InitLabel(ControlCollection control)
        {
            Label widthLabel = new Label();
            widthLabel.Text = stWidthTitleLabel;
            widthLabel.AutoSize = true;
            Label widthExtendedCanvasTitleLabel = new Label();
            widthExtendedCanvasTitleLabel.Text = stWidthExtendedTitleLabel;
            widthLabel.AutoSize = true;
            Label heightTitleLabel = new Label();
            heightTitleLabel.Text = stHeightTitleLable;
            heightTitleLabel.AutoSize = true;
            Label countOfSplitedLabel = new Label();
            countOfSplitedLabel.Text = stCountOfSplited;
            countOfSplitedLabel.AutoSize = true;
            control.Add(widthLabel);
            control.Add(widthExtendedCanvasTitleLabel);
            control.Add(heightTitleLabel);
            control.Add(countOfSplitedLabel);
        }
    }
}
