using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Сalculator_for_tailoring_curtains
{
    public class OrderEntity
    {
        private static List<CanvasEntity> listCanvas;
        private static OrderEntity _instance;

        private OrderEntity()
        {
            listCanvas = new ArrayList<CanvasEntity>();
        }

        public static OrderEntity Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OrderEntity();
                return _instance;
            }
        }

        public static void CreateInstance()
        {
            if(_instance == null)
            {
                _instance = new OrderEntity();
            }
        }

        public void AddCanvasEntity(CanvasEntity entity)
        {
            listCanvas.Add(entity);
        }

        public int Size
        {
            get { return listCanvas.Count; }
        }

        public CanvasEntity GetCanvasEntity(int index)
        {
            if(index >= 0 && index < listCanvas.Count)
                return listCanvas[index];
            else
                throw new IndexOutOfRangeException();
        }
    }
}