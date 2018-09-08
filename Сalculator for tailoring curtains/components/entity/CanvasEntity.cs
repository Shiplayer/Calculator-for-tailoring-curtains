using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Сalculator_for_tailoring_curtains.components;
using Сalculator_for_tailoring_curtains.components.entity;

namespace Сalculator_for_tailoring_curtains
{
    public class CanvasEntity : IObserver<CanvasEntityObserver>
    {
        /*
         "width": Math.floor(def_Eave['width']),
	"widthFactor": 1.8,
	"widthLush": Math.floor(def_Eave['width'] * 1.8),
	"widthFull": Math.floor(def_Eave['width'] * 1.8 + 1.5*4*1), // *1 - do_side_work
	"height": 120,
	"heightFull": 125,
         */
        private int width;
        private int height;
        private int realHeight;
        private int realWidth;
        private int resultHeight;
        private int resultWidth;
        private int count;
        private IDisposable cancellation;
        private List<PropertyCanvas> properties;

        public CanvasEntity()
        {
            properties = new List<PropertyCanvas>();
        }

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

        public int RealHeight
        {
            get { return realHeight; }
            set { realHeight = value; }
        }

        public int RealWidth
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

        public virtual void Subscribe(AbstractComponent provider)
        {
            cancellation = provider.Subscribe(this);
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

        public void addPropertyCanvas(PropertyCanvas property)
        {
            properties.Add(property);

        }

        public void updateProperties()
        {
            if(properties != null)
            {
                foreach (PropertyCanvas property in properties)
                {
                    if (!property.Updated)
                    {
                        if (property.TypeProperties == PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT)
                            realHeight = property.apply(realHeight);
                        else
                            realWidth = property.apply(realWidth);
                        Console.Out.WriteLine(property.apply(300));
                        property.Updated = true;
                        Console.Out.WriteLine("CanvasEntity: " + this.ToString());
                    }
                }
            }
        }

        public void OnNext(CanvasEntityObserver value)
        {
            //width = value.Width;
            if (realWidth != value.Width * value.Count)
                realWidth = width * count;
            if(realHeight != value.Height)
            {
                realHeight = value.Height;
            }
            width = realWidth / value.Count;
            height = value.Height;
            Console.Out.WriteLine(this.ToString());
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}