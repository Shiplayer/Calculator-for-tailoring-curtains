using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    class TulleComponent : GroupBox
    {
        public TulleComponent()
        {
            InitComponent();
        }

        private void InitComponent()
        {
            Parent.Resize += changeOnSize;
        }

        private void changeOnSize(object sender, EventArgs eventArgs)
        {
            Width = Parent.Width - 6;
        }
    }
}
