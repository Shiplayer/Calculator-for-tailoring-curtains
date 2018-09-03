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
using Сalculator_for_tailoring_curtains.components.entity;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucCalculation : UserControl
    {
        private static int n = 0;
        private static ucCalculation _instance;

        public static ucCalculation Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ucCalculation();
                    _instance.Dock = DockStyle.Fill;
                }
                return _instance;
            }
        }

        public void setData()
        {

        }

        public ucCalculation()
        {
            InitializeComponent();
            for (int i = 0; i < OrderEntity.Instance.Size; i++)
            {
                CalculationComponents calculationComponents = new CalculationComponents(OrderEntity.Instance.GetCanvasEntity(i));
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(calculationComponents.getRootComponent());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ComponentWithList componentWithList = new ComponentWithList();
            label1.Text = "RowCount = " + tableLayoutPanel1.RowCount + "; ColumnCount = " + tableLayoutPanel1.ColumnCount;
            //tableLayoutPanel1.Controls.Add(componentWithList.getComponent(), 1, tableLayoutPanel1.RowCount++);
        }
    }
}
