using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components
{
    abstract class SubEntity
    {
        public enum STATE { CHECKBOX, LIST, INPUTTEXT };
        private string contentText;
        public STATE state;

        public STATE getState()
        {
            return state;
        }

        public string ContentText
        {
            get { return contentText; }
        }
    }
}
