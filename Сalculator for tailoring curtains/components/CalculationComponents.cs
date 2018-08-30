using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Сalculator_for_tailoring_curtains.Properties;

namespace Сalculator_for_tailoring_curtains.components
{
    class CalculationComponents
    {
        private List<IComponent> components;

        public CalculationComponents()
        {
            initComponents();
        }

        private void initComponents()
        {
            
            using (XmlReader reader = XmlReader.Create(new StringReader(Resources.testData)))
            {
                components = new List<IComponent>();
                IComponent component = null;
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "CalculationComponents":
                                Console.Out.WriteLine("Create root component");
                                break;
                            case "Component":
                                int type = Int32.Parse(reader.GetAttribute("type"));
                                component = ComponentFactory.getComponent(type);
                                break;
                            case "Name":
                                component.SetName(reader.ReadElementContentAsString());
                                break;
                            case "Description":
                                component.SetDescription(reader.ReadElementContentAsString());
                                break;
                            case "KeyValue":
                                Console.Out.WriteLine("KeyValue content started");
                                break;
                            case "key":
                                component.addKeyValue(reader.ReadElementContentAsString(), reader.GetAttribute("value"));
                                break;
                        }
                    }
                    else if(reader.NodeType == XmlNodeType.EndElement)
                    {
                        switch (reader.Name)
                        {
                            case "Component":
                                components.Add(component);
                                break;
                        }
                    }
                }
            }
        }

        public List<IComponent> Components
        {
            get { return components; }
            set { this.components = value; }
        }
    }
}
