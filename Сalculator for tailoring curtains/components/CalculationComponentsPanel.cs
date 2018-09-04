using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components
{
    public class CalculationComponentsPanel : FlowLayoutPanel
    {
        public CalculationComponentsPanel()
        {
            InitializeComponent();
        }

        public void addControl(Control control)
        {
            base.Controls.Add(control);
        }

        public CalculationComponents CalculationComponents
        {
            set
            {

            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CalculationComponentsPanel
            // 
            this.AutoSize = true;
            this.ResumeLayout(false);

        }
    }
}
