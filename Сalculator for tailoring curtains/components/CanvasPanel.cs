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
        private const string stWidthTitleLabel = "Ширина собранной";
        //private const string stWidthExtendedTitleLabel = "Ширина тюля расправленного";
        private const string stHeightTitleLabel = "Высота без учёта припусков";
        private const string stCountOfSplitted = "Количество частей";
        private CanvasEntity canvasEntity;

        private int Distance = 4;

        NumericUpDown numericWidth;
        NumericUpDown numericHeight;
        NumericUpDown numericCountOfSplitted;
        FlowLayoutPanel labelPanel;
        FlowLayoutPanel inputPanel;

        public event EventHandler RemoveCanvas;

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

        public void attachCanvasEntity()
        {
            canvasEntity = new CanvasEntity();
            canvasEntity.Width = (int)numericWidth.Value;
            canvasEntity.RealWidth = canvasEntity.Width;
            canvasEntity.Height = (int)numericHeight.Value;
            canvasEntity.RealHeight = canvasEntity.Height;
            canvasEntity.Count = (int)numericCountOfSplitted.Value;
            numericWidth.ValueChanged += (sender, args) => {
                canvasEntity.Width = (int)numericWidth.Value;
                canvasEntity.DataChangedEvent();
                Console.Out.WriteLine(canvasEntity.ToString());
            };
            numericCountOfSplitted.ValueChanged += (sender, args) => {
                canvasEntity.Count = (int)numericCountOfSplitted.Value;
                numericWidth.Value = canvasEntity.RealWidth / canvasEntity.Count;
                canvasEntity.DataChangedEvent();
                Console.Out.WriteLine(canvasEntity.ToString());
            };
        }

        private void CanvasNumericWidth_ValueChanged(object sender, EventArgs args)
        {
            canvasEntity.Width = (int)numericWidth.Value;
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
            //labelPanel.Controls.Add(createLabel(stWidthExtendedTitleLabel));
            labelPanel.Controls.Add(createLabel(stHeightTitleLabel));
            labelPanel.Controls.Add(createLabel(stCountOfSplitted));

            numericWidth = createNumericUpDown(250);
            inputPanel.Controls.Add(numericWidth);
            //numericWidthExtended = createNumericUpDown(250);
            //inputPanel.Controls.Add(numericWidthExtended);
            numericHeight = createNumericUpDown(260);
            inputPanel.Controls.Add(numericHeight);
            numericCountOfSplitted = createNumericUpDown(1);
            //numericCountOfSplitted.ValueChanged += NumericCountOfSplitted_ValueChanged;
            inputPanel.Controls.Add(numericCountOfSplitted);

            Button button = new Button();
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button.Text = "Удалить полотно";
            button.AutoSize = true;
            button.Click += Button_RemoveCanvas;
            inputPanel.Controls.Add(button);
            Controls.Add(labelPanel);
            Controls.Add(inputPanel);
        }

        private void NumericCountOfSplitted_ValueChanged(object sender, EventArgs e)
        {
            numericWidth.Value = numericWidth.Value / numericCountOfSplitted.Value;
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

        private NumericUpDown createNumericUpDown(decimal value)
        {
            NumericUpDown numeric = new NumericUpDown();
            numeric.Minimum = 1;
            numeric.Maximum = 400;
            numeric.Value = value;
            numeric.TextAlign = HorizontalAlignment.Center;
            numeric.Margin = new Padding(5);
            numeric.KeyDown += Numeric_KeyDown;
//            numeric.ValueChanged += PositiveValueHandler;
            return numeric;
        }

        private void Numeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ((NumericUpDown)sender).Parent.Focus();
            }
        }

        public CanvasEntity GetCanvasEntity()
        {
            return canvasEntity;
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        /*       private void PositiveValueHandler(object sender, EventArgs e)
               {
                   NumericUpDown numeric = (NumericUpDown)sender;
                   Console.Out.WriteLine(numeric.Text + " " + numeric.Value);
               }*/

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
