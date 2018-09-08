using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucTulle : UserControl
    {
        public ucTulle()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }


    }
}
