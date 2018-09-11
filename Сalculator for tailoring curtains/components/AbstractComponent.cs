﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalculator_for_tailoring_curtains.components.entity;

namespace Сalculator_for_tailoring_curtains.components
{
    public enum TYPE_OF_COMPONENTS { INPUT, LIST, INPUT_AND_LIST}
    public abstract class AbstractComponent
    {
        protected decimal numericMin = 0.1m;
        protected decimal numericMax = 10;
        protected decimal numericStep = 0.1m;
        protected List<IObserver<CanvasEntity>> listObservers;
        protected List<PropertyCanvas> properties;

        protected CanvasEntity entity;
        protected AbstractComponent(CanvasEntity entity)
        {
            listObservers = new List<IObserver<CanvasEntity>>();
            properties = new List<PropertyCanvas>();
            this.entity = entity;
        }
        public abstract CalculationComponentsPanel getComponent();
        public abstract void SetName(string text);
        public abstract void SetDescription(string text);
        public abstract void AddItemInList(string value);

        public TYPE_OF_COMPONENTS Type { get; set; }
    }
}
