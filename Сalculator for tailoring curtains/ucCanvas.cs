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
            AddnewCanvasPanel();
        }

        private void RemoveCanvas(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove((CanvasPanel)sender);
            groupBoxes.Remove((CanvasPanel)sender);
            for(int i = 0; i < groupBoxes.Count; i++)
            {
                if(!groupBoxes[i].Text.Equals(stGroupBoxTitle + (i + 1)))
                {
                    groupBoxes[i].Text = stGroupBoxTitle + (i + 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddnewCanvasPanel();
        }

        private void AddnewCanvasPanel()
        {
            CanvasPanel box = new CanvasPanel
            {
                Text = stGroupBoxTitle + (groupBoxes.Count + 1)
            };
            box.RemoveCanvas += RemoveCanvas;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Controls.Add(box);
            box.attachCanvasEntity();
            groupBoxes.Add(box);
            OrderEntity.Instance.AddCanvasEntity(box.GetCanvasEntity());
        }
    }
}
