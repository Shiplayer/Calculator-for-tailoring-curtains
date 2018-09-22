using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Сalculator_for_tailoring_curtains.components;
using Сalculator_for_tailoring_curtains.components.entity;

namespace Сalculator_for_tailoring_curtains
{
    public class CanvasEntity : IObservable<CanvasEntity>
    {
        /*
         "width": Math.floor(def_Eave['width']),
	"widthFactor": 1.8,
	"widthLush": Math.floor(def_Eave['width'] * 1.8),
	"widthFull": Math.floor(def_Eave['width'] * 1.8 + 1.5*4*1), // *1 - do_side_work
	"height": 120,
	"heightFull": 125,
         */
        private decimal width;
        private decimal height;
        private decimal realHeight;
        private decimal realWidth;
        private int count;
        private IDisposable cancellation;
        private IObserver<CanvasEntity> observer;
        private List<PropertyCanvas> properties;


        public CanvasEntity()
        {
            properties = new List<PropertyCanvas>();
        }

        public decimal Width
        {
            get { return width; }
            set { width = value;
                realWidth = value;
                updateProperties();
            }
        }

        public decimal Height
        {
            get { return height; }
            set { height = value;
                realHeight = value;
                updateProperties();
            }
        }

        public decimal RealHeight
        {
            get { return realHeight; }
            set { realHeight = value; }
        }

        public decimal RealWidth
        {
            get { return realWidth; }
            set { realWidth = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public void DataChangedEvent()
        {
            if (realWidth != width * count)
                realWidth = width * count;
            width = realWidth / count;

        }

        public override string ToString()
        {
            return "CanvasEntity = { \n" +
                "width = " + width + ";\n" +
                "height = " + height + ";\n" +
                "realWidth = " + realWidth + ";\n" +
                "realHeight = " + realHeight + ";\n" +
                "count = " + count + "\n}";
        }

        public void Unsubscribe()
        {
            cancellation.Dispose();
        }

        public void setPropertiesCanvas(List<PropertyCanvas> properties)
        {
            this.properties = properties;
            updateProperties();
        }

        public List<PropertyCanvas> GetPropertiesCanvas()
        {
            return this.properties;
        }

        public bool containsPropertyCanvas(PropertyCanvas property)
        {
            return properties.Contains(property);
        }

        public void addPropertyCanvas(PropertyCanvas property)
        {
            properties.Add(property);
            updateProperties();
        }

        public void removeProperty(PropertyCanvas property) 
        {
            if (properties.Contains(property))
            {

                    if (property.TypeProperties == PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT)
                        realHeight += height - property.apply(height);
                    else
                        realWidth += width - property.apply(width);
                    if(observer != null)
                    observer.OnNext(this);
                
                properties.Remove(property);
            }
        }

        public void updateProperties()
        {
            if(properties != null)
            {
                realHeight = height;
                realWidth = width;
                foreach (PropertyCanvas property in properties)
                {
                    ExecuteProperty(property);
                }
                if (observer != null) 
                    observer.OnNext(this);
            }
        }

        public void ExecuteProperty(PropertyCanvas property)
        {
            
                if (property.TypeProperties == PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT)
                    realHeight += property.apply(height) - height;
                else
                    realWidth += property.apply(width) - width;
                Console.Out.WriteLine(property.apply(width));
                Console.Out.WriteLine("CanvasEntity: " + this.ToString());
        }

        public IDisposable Subscribe(IObserver<CanvasEntity> observer)
        {
            if(this.observer != observer)
            {
                this.observer = observer;
                if(observer != null)
                    observer.OnNext(this);
            }
            return new Unsubscriber<CanvasEntity>(this.observer, observer);
        }
    }
}