using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сalculator_for_tailoring_curtains.components;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucTulle : UserControl
    {
        public CalculationComponents calculationForm;
        CanvasEntity entity;

        public ucTulle()
        {
            InitializeComponent();
            
        }

        public string Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Application.OpenForms[0];
            form.mainPanel.BringToFront();
            form.mainPanel.Visible = true;
            if (!form.mainPanelContent.Controls.Contains(calculationForm.getControlComponent()))
                form.mainPanelContent.Controls.Add(calculationForm.getControlComponent());
            else
                calculationForm.getRootComponent().Visible = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            entity.Width = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            entity.Height = (int)numericUpDown2.Value;
        }

        private void ucTulle_Load(object sender, EventArgs e)
        {
            entity = new CanvasEntity();
            calculationForm = new CalculationComponents(entity);
            numericUpDown1.Minimum = 120;
            numericUpDown1.Maximum = 500;
            numericUpDown2.Minimum = 120;
            numericUpDown2.Maximum = 500;
            entity.Width = (int)numericUpDown1.Value;
            entity.Height = (int)numericUpDown2.Value;
        }
    }
}
