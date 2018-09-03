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

        public PropertyCanvas(functionExecution function)
        {
            this.function = function;
        }

        public TYPE_OF_PROPERTIES TypeProperties { get; set; }
    }
}