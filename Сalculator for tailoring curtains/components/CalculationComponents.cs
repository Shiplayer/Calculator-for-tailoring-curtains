using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    class CalculationComponents
    {
        private List<string> nameOfCheckbocks;

        public CalculationComponents()
        {
            nameOfCheckbocks = new List<string>();
        }

        public List<string> NameOfCheckbocks
        {
            get { return nameOfCheckbocks; }
            set { this.nameOfCheckbocks = value; }
        }
    }
}
