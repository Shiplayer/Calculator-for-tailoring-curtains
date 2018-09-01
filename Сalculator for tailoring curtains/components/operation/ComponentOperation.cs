using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components.operation
{
    class ComponentOperation
    {
        private delegate double function(double x, double y);

        public static ComponentOperation getOperation(string formula)
        {
            ComponentOperation componentOperation = new ComponentOperation();
            if(formula.Replace("\t", "").Contains("+")){
                //componentOperation.MemberwiseClone.componentOperation = (x, y) => { return x + y; };
            }
            return componentOperation;
        }

    }
}
