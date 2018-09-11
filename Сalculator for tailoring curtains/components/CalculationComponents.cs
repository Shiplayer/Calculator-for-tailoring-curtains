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
using System.Drawing;

namespace Сalculator_for_tailoring_curtains.components
{
    public class CalculationComponents : IObserver<CanvasEntity>
    {
        private List<AbstractComponent> components;
        private CanvasEntity entity;
        private GroupBox groupBox;
        private Panel contentPanel;
        private NumericUpDown widthNumeric;
        private NumericUpDown heightNumeric;
        private TextBox widthNumericBox;
        private TextBox heightNumericBox;
        FlowLayoutPanel panel;

        public CalculationComponents(CanvasEntity entity)
        {
            this.entity = entity;
            entity.Subscribe(this);
            initComponents();
        }

        private PropertyCanvas.functionExecution generateFunction()
        {
            return (x, y) => { return y + x * 4; };
        }

        private void initComponents()
        {
            widthNumeric = new NumericUpDown();
            heightNumeric = new NumericUpDown();
            widthNumericBox = new TextBox();
            heightNumericBox = new TextBox();
            components = new List<AbstractComponent>();
            ComponentWithListAndInput component1 = new ComponentWithListAndInput(entity);
            component1.SetName("Боковины");
            component1.AddItemInList("Простой подгиб");
            component1.AddItemInList("Московский шов");
            component1.AddItemInList("Косая бейка");
            PropertyCanvas property = new PropertyCanvas((x, y) => { return y + x * 4; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            component1.AddPropertyCanvas(property);
            components.Add(component1);
            ComponentWithInput component2 = new ComponentWithInput(entity, 5, 50, 1);
            component2.SetName("Дополнительная  обработка боковины \"Ушки\"");
            property = new PropertyCanvas((x, y) => { Console.Out.WriteLine("result = " + (y + x * 2)); return y + x * 2; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            component2.AddPropertyCanvas(property);
            //PropertyCanvas property = new PropertyCanvas();
            //property.function = generateFunction();
            //componentWithInput.PropertyCanvas = new PropertyCanvas();
            components.Add(component2);

            ComponentWithInput component3 = new ComponentWithInput(entity);
            component3.SetName("Подгиб низа");
            property = new PropertyCanvas((x, y) => { return y + x * 2; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;
            component3.AddPropertyCanvas(property);

            components.Add(component3);

            ComponentWithListAndInput component4 = new ComponentWithListAndInput(entity);
            component4.SetName("Обработка верха без шторной ленты");
            component4.AddItemInList("Простой подгиб");
            component4.AddItemInList("Московский шов");
            component4.AddItemInList("Косая бейка");
            component4.AddKeyValue("На кулиске", 2);
            property = new PropertyCanvas((x, y) => { return y + x * 2; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;
            component4.AddPropertyCanvas(property);

            components.Add(component4);

            ComponentWithList component5 = new ComponentWithList(entity);
            component5.SetName("Обработка верха шторной лентой");
            component5.SetDescription("складка \"карандаш\"");
            component5.AddKeyValue("коэфф 1:2,0", 2);
            component5.AddKeyValue("коэфф 1:2,5", 2.5m);
            component5.AddKeyValue("коэфф 1:3,0", 3);
            property = new PropertyCanvas((x, y) => { return y * x; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.WIDTH;
            property.updateValue(1);
            component5.AddPropertyCanvas(property);
            property = new PropertyCanvas((x, y) => { return y + x; });
            property.updateValue(6);
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;
            component5.AddPropertyCanvas(property);
            components.Add(component5);

            ComponentWithInput component6 = new ComponentWithInput(entity);
            component6.SetName("Дополнительная обработка \"Гребешок\"");
            property = new PropertyCanvas((x, y) => { return y + x * 2; });
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;
            component6.AddPropertyCanvas(property);
  
            components.Add(component6);

            ComponentWithList component7 = new ComponentWithList(entity);
            component7.SetName("Обработка верха Люверсами");
            component7.AddKeyValue("внутренний d 35 мм", 12);
            component7.AddKeyValue("внутренний d 40 мм", 12);
            component7.AddKeyValue("внутренний d 50 мм", 16);
            property = new PropertyCanvas((x, y) => { return y + x; });
            property.updateValue(0);
            property.TypeProperties = PropertyCanvas.TYPE_OF_PROPERTIES.HEIGHT;
            component7.AddPropertyCanvas(property);

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
            //groupBox.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            groupBox.Dock = DockStyle.Fill;
            //groupBox.Text = "test";
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

        public Control getControlComponent()
        {
            if (contentPanel == null)
            {
                contentPanel = new Panel();
                contentPanel.Dock = DockStyle.Fill;
                contentPanel.AutoSize = true;
                contentPanel.BackColor = Color.Aqua;
                GroupBox boxTulleSize = new GroupBox();
                boxTulleSize.AutoSize = true;
                boxTulleSize.Location = new System.Drawing.Point(3, 3);
                boxTulleSize.Text = "Размеры готового тюля";
                contentPanel.Controls.Add(boxTulleSize);

                Label widthLabel = new Label();
                widthLabel.Text = "Ширина:";
                widthLabel.Location = new System.Drawing.Point(6, 22);
                widthLabel.Margin = new Padding(3);
                boxTulleSize.Controls.Add(widthLabel);

                widthNumeric.Minimum = 120;
                widthNumeric.Maximum = 500;
                widthNumeric.Value = entity.Width;
                widthNumeric.Margin = new Padding(3);
                int deltaY = (widthNumeric.Height - widthLabel.Height) / 2;
                widthNumeric.Location = new Point(widthLabel.Location.X + widthLabel.Width + widthLabel.Margin.Right + widthNumeric.Margin.Left, widthLabel.Location.Y + deltaY);
                widthNumeric.ValueChanged += UpdateValue;
                boxTulleSize.Controls.Add(widthNumeric);

                Label heightLabel = new Label();
                heightLabel.Text = "Высота:";
                heightLabel.Margin = new Padding(3);
                heightLabel.Location = new System.Drawing.Point(widthLabel.Location.X, widthLabel.Location.Y + widthLabel.Height + widthNumeric.Margin.Top + heightLabel.Margin.Top);
                boxTulleSize.Controls.Add(heightLabel);


                heightNumeric.Minimum = 120;
                heightNumeric.Maximum = 500;
                heightNumeric.Value = entity.Height;
                heightNumeric.Margin = new Padding(3);
                heightNumeric.Location = new Point(heightLabel.Location.X + heightLabel.Width + heightLabel.Margin.Right + heightNumeric.Margin.Left, heightLabel.Location.Y + deltaY);

                boxTulleSize.Controls.Add(heightNumeric);

                GroupBox box = new GroupBox();
                box.AutoSize = true;
                box.Margin = new Padding(3);
                box.Location = new Point(boxTulleSize.Location.X + boxTulleSize.Width + boxTulleSize.Margin.Right + box.Margin.Left, boxTulleSize.Location.Y);
                box.Text = "Размер развернутого тюля";
                contentPanel.Controls.Add(box);

                Label widthLabelBox = new Label();
                widthLabelBox.Text = "Ширина:";
                widthLabelBox.Location = new System.Drawing.Point(6, 22);
                widthLabelBox.Margin = new Padding(3);
                Label heightLabelBox = new Label();
                heightLabelBox.Text = "Высота:";
                heightLabelBox.Margin = new Padding(3);
                heightLabelBox.Location = new System.Drawing.Point(widthLabelBox.Location.X, widthLabelBox.Location.Y + widthLabelBox.Height + widthNumeric.Margin.Top + heightLabelBox.Margin.Top);

                box.Controls.Add(widthLabelBox);
                box.Controls.Add(heightLabelBox);

                widthNumericBox.ReadOnly = true;
                widthNumericBox.Margin = new Padding(3);
                widthNumericBox.Location = new Point(widthLabel.Location.X + widthLabel.Width + widthLabel.Margin.Right + widthNumericBox.Margin.Left, widthLabel.Location.Y + deltaY);
                widthNumericBox.Text = entity.RealWidth.ToString();
                box.Controls.Add(widthNumericBox);

                heightNumericBox.Margin = new Padding(3);
                heightNumericBox.ReadOnly = true;
                heightNumericBox.Location = new Point(heightLabel.Location.X + heightLabel.Width + heightLabel.Margin.Right + heightNumericBox.Margin.Left, heightLabel.Location.Y + deltaY);
                heightNumericBox.Text = entity.RealHeight.ToString();
                box.Controls.Add(heightNumericBox);

                GroupBox groupBox = getRootComponent();
                groupBox.Dock = DockStyle.None;
                groupBox.Location = new System.Drawing.Point(boxTulleSize.Location.X, boxTulleSize.Location.Y + boxTulleSize.Height);
                contentPanel.Controls.Add(groupBox);
                groupBox.Parent.Resize += Parent_Resize;

                /*GroupBox groupBox = getRootComponent();
                groupBox.Dock = DockStyle.None;
                groupBox.Location = new System.Drawing.Point(3, 15);
                //boxTulleSize.Controls.Add(groupBox);
                panel.Controls.Add(groupBox);
                groupBox.Parent.Resize += Parent_Resize;*/
            }
            return contentPanel;
        }

        private void UpdateValue(object sender, EventArgs e)
        {
            entity.Height = (int)heightNumeric.Value;
            entity.Width = (int)widthNumeric.Value;
            entity.updateProperties();
        }

        private void Parent_Resize(object sender, EventArgs e)
        {
            groupBox.Width = groupBox.Parent.ClientSize.Width - 6;
        }

        private void GroupBox_SizeChanged(object sender, EventArgs e)
        {
            panel.MinimumSize = new System.Drawing.Size(groupBox.Width - 12, groupBox.Height - 25);
            panel.Location = new System.Drawing.Point(6, 12);
        }

        public void OnNext(CanvasEntity value)
        {
            if (value != null && widthNumericBox != null && heightNumericBox != null)
            {
                widthNumericBox.Text = value.RealWidth.ToString();
                heightNumericBox.Text = value.RealHeight.ToString();
                Console.Out.WriteLine("hello from observer");
            } else
            {
                Console.Out.WriteLine("value is null? " + (value != null) + " widthNumericBox is null?" + (widthNumericBox != null) + "heightNumericBox is null? " + (heightNumericBox != null));
            }
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public List<AbstractComponent> Components
        {
            get { return components; }
            set { this.components = value; }
        }
    }
}
