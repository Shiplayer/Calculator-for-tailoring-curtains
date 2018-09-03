using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Сalculator_for_tailoring_curtains.components.entity;
using System.Windows.Forms;
using Сalculator_for_tailoring_curtains.Properties;

namespace Сalculator_for_tailoring_curtains.components
{
    class CalculationComponents
    {
        private List<AbstractComponent> components;
        private CanvasEntity entity;
        private GroupBox groupBox;
        FlowLayoutPanel panel;

        public CalculationComponents(CanvasEntity entity)
        {
            this.entity = entity;
            initComponents();
        }

        private PropertyCanvas.functionExecution generateFunction()
        {
            return (x, y) => { return y + x * 4; };
        }

        private void initComponents()
        {
            components = new List<AbstractComponent>();
            ComponentWithListAndInput listAndInput = new ComponentWithListAndInput(entity);
            listAndInput.SetName("Боковины");
            listAndInput.AddValueInList("Простой подгиб");
            listAndInput.AddValueInList("Московский шов");
            listAndInput.AddValueInList("Косая бейка");
            listAndInput.PropertyCanvas = new PropertyCanvas((x, y) => { return y + x * 4; });
            listAndInput.PropertyCanvas.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            components.Add(listAndInput);
            ComponentWithInput componentWithInput = new ComponentWithInput(entity);
            componentWithInput.SetName("with input");
            //PropertyCanvas property = new PropertyCanvas();
            //property.function = generateFunction();
            //componentWithInput.PropertyCanvas = new PropertyCanvas();
            components.Add(componentWithInput);

            /*using (XmlReader reader = XmlReader.Create(new StringReader(Resources.testData)))
            {
                components = new List<AbstractComponent>();
                AbstractComponent component = null;
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
            }*/
        }

        public GroupBox getRootComponent()
        {
            groupBox = new GroupBox();
            groupBox.AutoSize = true;
            groupBox.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBox.SizeChanged += GroupBox_SizeChanged;
            panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            panel.AutoSize = true;
            groupBox.Controls.Add(panel);

            foreach (AbstractComponent component in components)
            {
                panel.Controls.Add(component.getComponent());
            }

            return groupBox;
        }

        private void GroupBox_SizeChanged(object sender, EventArgs e)
        {
            panel.MinimumSize = new System.Drawing.Size(groupBox.Width - 12, groupBox.Height - 25);
            panel.Location = new System.Drawing.Point(6, 12);
        }

        public List<AbstractComponent> Components
        {
            get { return components; }
            set { this.components = value; }
        }
    }
}
