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
    public class CalculationComponents
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
            ComponentWithListAndInput component1 = new ComponentWithListAndInput(entity);
            component1.SetName("Боковины");
            component1.AddValueInList("Простой подгиб");
            component1.AddValueInList("Московский шов");
            component1.AddValueInList("Косая бейка");
            component1.PropertyCanvas = new PropertyCanvas((x, y) => { return y + x * 4; });
            component1.PropertyCanvas.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            components.Add(component1);
            ComponentWithInput component2 = new ComponentWithInput(entity, 5, 50, 1);
            component2.SetName("Дополнительная  обработка боковины \"Ушки\"");
            component2.PropertyCanvas = new PropertyCanvas((x, y) => { Console.Out.WriteLine("result = " +  (y + x * 2)); return y + x * 2; });
            component2.PropertyCanvas.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            //PropertyCanvas property = new PropertyCanvas();
            //property.function = generateFunction();
            //componentWithInput.PropertyCanvas = new PropertyCanvas();
            components.Add(component2);

            ComponentWithInput component3 = new ComponentWithInput(entity);
            component3.SetName("Подгиб низа");
            component3.PropertyCanvas = new PropertyCanvas((x, y) => { return y + x * 2; });
            component3.PropertyCanvas.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;

            components.Add(component3);

            ComponentWithListAndInput component4 = new ComponentWithListAndInput(entity);
            component4.SetName("Обработка верха без шторной ленты");
            component4.AddValueInList("Простой подгиб");
            component4.AddValueInList("Московский шов");
            component4.AddValueInList("Косая бейка");
            component4.PropertyCanvas = new PropertyCanvas((x, y) => { return y + x * 2; });
            component4.PropertyCanvas.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;

            components.Add(component4);

            ComponentWithList component5 = new ComponentWithList(entity);
            component5.SetName("Обработка верха шторной лентой");
            component5.SetDescription("складка \"карандаш\"");
            component5.AddValueInList("коэфф 1:2,0");
            component5.AddValueInList("коэфф 1:2,5");
            component5.AddValueInList("коэфф 1:3,0");

            components.Add(component5);

            ComponentWithInput component6 = new ComponentWithInput(entity);
            component6.SetName("Дополнительная обработка \"Гребешок\"");
            component6.PropertyCanvas = new PropertyCanvas((x, y) => { return y + x * 2; });

            components.Add(component6);

            ComponentWithList component7 = new ComponentWithList(entity);
            component7.SetName("Обработка верха Люверсами");
            component7.AddValueInList("внутренний d 35 мм");
            component7.AddValueInList("внутренний d 40 мм");
            component7.AddValueInList("внутренний d 50 мм");

            components.Add(component7);


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
