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
            userControls.Add(ucCanvas.Instance);
            userControls.Add(ucCalculation.Instance);
            splitContainer1.Panel1.Controls.Add(ucCanvas.Instance);
            ucCanvas.Instance.BringToFront();
            button2.Visible = false;
            //panel1.Controls.Add(ucCalculation.Instance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1.Controls.Contains(userControls[++index]))
            {
                splitContainer1.Panel1.Controls.Add(userControls[index]);
            }
            userControls[index].BringToFront();
            if (index == userControls.Count - 1)
                button1.Visible = false;
            if (!button2.Visible && index > 0)
            {
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1.Controls.Contains(userControls[--index]))
            {
                splitContainer1.Panel1.Controls.Add(userControls[index]);
            }
            userControls[index].BringToFront();
            if (index == 0)
                button2.Visible = false;
            if (!button1.Visible && index < userControls.Count - 1)
            {
                button1.Visible = true;
            }
        }
    }
}
