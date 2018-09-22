using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Сalculator_for_tailoring_curtains
{

    public class PropertyCanvas
    {
        public enum TYPE_OF_PROPERTIES { WIDTH, HEIGHT, BOTH }
        public delegate decimal functionExecution(decimal x, decimal y);
        public functionExecution function;
        public string name;
        public string selected;
        private decimal result;
        private decimal value;

        public PropertyCanvas(functionExecution function)
        {
            this.function = function;
        }

        public decimal apply(decimal x)
        {
            result = function(value, x) - x;
            return function(value, x);
        }

        public void updateValue(decimal value)
        {
            this.value = value;
            Updated = false;
        }

        public bool Updated { get; set; }

        public TYPE_OF_PROPERTIES TypeProperties { get; set; }

        public string ToString()
        {
            return name + (selected != null ? " (" + selected + ")" : "") + " " + result + " см " + TypeProperties;
        }
    }
}