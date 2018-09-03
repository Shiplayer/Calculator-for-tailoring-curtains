using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    internal enum TYPE_OF_COMPONENTS { INPUT, LIST, INPUT_AND_LIST}
    abstract class AbstractComponent
    {
        protected CanvasEntity entity;
        protected AbstractComponent(CanvasEntity entity)
        {
            this.entity = entity;
        }
        public abstract CalculationComponentsPanel getComponent();
        public abstract void SetName(string text);
        public abstract void SetDescription(string text);
        public abstract void AddValueInList(string value);
        public TYPE_OF_COMPONENTS Type { get; set; }
    }
}
