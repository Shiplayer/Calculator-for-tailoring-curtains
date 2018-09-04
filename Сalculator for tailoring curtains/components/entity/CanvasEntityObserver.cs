using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator_for_tailoring_curtains.components.entity
{
    public class CanvasEntityObserver
    {
        private int width;
        private int height;
        private int count;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
