using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains
{
    public partial class Form1 : Form
    {
        private List<UserControl> userControls;
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
            userControls = new List<UserControl>();
            OrderEntity.CreateInstance();
            userControls.Add(ucWindow.Instance);
            userControls.Add(ucCanvas.Instance);
            userControls.Add(ucCalculation.Instance);
            splitContainer1.Panel1.Controls.Add(ucWindow.Instance);
            ucCanvas.Instance.BringToFront();
            btn_prev.Visible = false;
            //panel1.Controls.Add(ucCalculation.Instance);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1.Controls.Contains(userControls[++index]))
            {
                splitContainer1.Panel1.Controls.Add(userControls[index]);
            }
            userControls[index].Visible = true;
            userControls[index - 1].Visible = false;
            if (index == userControls.Count - 1)
                btn_next.Visible = false;
            if (!btn_prev.Visible && index > 0)
            {
                btn_prev.Visible = true;
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1.Controls.Contains(userControls[--index]))
            {
                splitContainer1.Panel1.Controls.Add(userControls[index]);
            }
            userControls[index].Visible = true;
            userControls[index + 1].Visible = false;
            if (index == 0)
                btn_prev.Visible = false;
            if (!btn_next.Visible && index < userControls.Count - 1)
            {
                btn_next.Visible = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Console.Out.WriteLine(splitContainer1.Location + " " + splitContainer1.Size + " " + Size + " " + ClientSize);
            splitContainer1.Width = ClientSize.Width - (splitContainer1.Location.X + splitContainer1.Margin.Left) * 2;
            int oldDistance = splitContainer1.SplitterDistance;
            splitContainer1.Height = ClientSize.Height - (splitContainer1.Location.Y + splitContainer1.Margin.Top) * 2;
            splitContainer1.SplitterDistance = splitContainer1.Height - btn_next.Height - btn_next.Margin.Top - btn_next.Margin.Bottom - 5;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Out.WriteLine(splitContainer1.Location + " " + splitContainer1.Size + " " + Size);
            splitContainer1.Width = ClientSize.Width - (splitContainer1.Location.X + splitContainer1.Margin.Left) * 2;
            int oldDistance = splitContainer1.SplitterDistance;
            splitContainer1.Height = ClientSize.Height - (splitContainer1.Location.Y + splitContainer1.Margin.Top) * 2;
            splitContainer1.SplitterDistance = splitContainer1.Height - btn_next.Height - btn_next.Margin.Top - btn_next.Margin.Bottom - 5;
            //splitContainer1.Width = Width - splitContainer1.Location.X * 2;
        }
    }
}
