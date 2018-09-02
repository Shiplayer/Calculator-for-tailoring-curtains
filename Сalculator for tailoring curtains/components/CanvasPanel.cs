using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components
{
    public partial class CanvasPanel : GroupBox
    {
        public event EventHandler RemoveCanvas;
        private string stWidthTitleLabel = "Ширина собранной";
        private string stWidthExtendedTitleLabel = "Ширина тюля расправленного";
        private string stHeightTitleLabel = "Высота без учёта припусков";
        private string stCountOfSplited = "Количество частей";
        FlowLayoutPanel labelPanel;
        FlowLayoutPanel inputPanel;
        private int Distance = 4;
        public CanvasPanel()
        {
            InitializeComponent();
            Init();
        }

        public CanvasPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }


        public void Init()
        {

            Text = "panel";
            labelPanel = new FlowLayoutPanel();
            inputPanel = new FlowLayoutPanel();

            labelPanel.WrapContents = false;
            inputPanel.WrapContents = false;

            labelPanel.Location = new Point(6, 19);
            labelPanel.AutoSize = true;
            inputPanel.AutoSize = true;
            //labelPanel.Size = new Size((Size.Width - 16 + Distance) / 2, 125);
            //inputPanel.Size = new Size((Size.Width - 16 + Distance) / 2, 125);
            inputPanel.Location = new Point((Size.Width - 6) / 2 + Distance / 2, 19);

            labelPanel.FlowDirection = FlowDirection.TopDown;
            inputPanel.FlowDirection = FlowDirection.TopDown;

            labelPanel.Controls.Add(createLabel(stWidthTitleLabel));
            labelPanel.Controls.Add(createLabel(stWidthExtendedTitleLabel));
            labelPanel.Controls.Add(createLabel(stHeightTitleLabel));
            labelPanel.Controls.Add(createLabel(stCountOfSplited));
            for(int i = 0; i < 4; i++)
            {
                inputPanel.Controls.Add(createNumericUpDown());
            }

            Button button = new Button();
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button.Text = "Удалить полотно";
            button.AutoSize = true;
            button.Click += Button_RemoveCanvas;
            inputPanel.Controls.Add(button);
            Controls.Add(labelPanel);
            Controls.Add(inputPanel);
        }

        protected void Button_RemoveCanvas(object obj, EventArgs eventArgs)
        {
            if(RemoveCanvas != null)
            {
                RemoveCanvas(this, eventArgs);
            }
        }

        private Label createLabel(string title)
        {
            Label label = new Label();
            label.Text = title;
            label.AutoSize = true;
            label.Margin = new Padding(8);

            return label;
        }

        private NumericUpDown createNumericUpDown()
        {
            NumericUpDown numeric = new NumericUpDown();
            numeric.Margin = new Padding(5);
            return numeric;
        }

        private void CanvasPanel_SizeChanged(object sender, EventArgs e)
        {
            if (labelPanel != null && inputPanel != null)
            {
                labelPanel.MinimumSize = new Size((Size.Width - 12) / 2 - Distance, 125);
                
                inputPanel.MinimumSize = new Size((Size.Width - 12) / 2, 125);
                Console.Out.WriteLine(labelPanel.Size.Width + " " + labelPanel.Size.Height + " vs " + Size.Width + " " + Size.Height);
                inputPanel.Location = new Point((Size.Width - 6) / 2 + Distance, 19);
            }
        }
    }
}
