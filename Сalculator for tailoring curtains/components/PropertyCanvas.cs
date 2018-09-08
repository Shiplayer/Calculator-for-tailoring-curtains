using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Сalculator_for_tailoring_curtains
{

    public class PropertyCanvas
    {
        public enum TYPE_OF_PROPERTIES { WIDTH, HEIGHT }
        public delegate int functionExecution(int x, int y);
        public functionExecution function;
        private decimal value;

        public PropertyCanvas(functionExecution function)
        {
            this.function = function;
        }

        public int apply(int x)
        {
            return function((int)value, x);
        }

        public void updateValue(decimal value)
        {
            this.value = value;
            Updated = false;
        }

        public bool Updated { get; set; }

        public TYPE_OF_PROPERTIES TypeProperties { get; set; }
    }
}