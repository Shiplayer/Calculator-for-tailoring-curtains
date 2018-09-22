using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Сalculator_for_tailoring_curtains.components;
using Сalculator_for_tailoring_curtains.components.entity;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucTulle : UserControl
    {
        public NetworkCredential credential;
        public SmtpClient client;
        public MailMessage mail;
        public CalculationComponents calculationForm;
        CanvasEntity entity;
        private string documentContent;
        private string stringToPrint;

        public ucTulle()
        {
            InitializeComponent();
            
        }

        public string Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Application.OpenForms[0];
            form.mainPanel.BringToFront();
            form.mainPanel.Visible = true;
            if (!form.mainPanelContent.Controls.Contains(calculationForm.getControlComponent()))
                form.mainPanelContent.Controls.Add(calculationForm.getControlComponent());
            else
                calculationForm.getControlComponent().Visible = true;
            form.SetSelected = calculationForm;
            calculationForm.getControlComponent().Visible = true;
        }

        public void updateSize()
        {
            numericUpDown1.Value = entity.Width;
            numericUpDown2.Value = entity.Height;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            entity.Width = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            entity.Height = (int)numericUpDown2.Value;
        }

        private void ucTulle_Load(object sender, EventArgs e)
        {
            entity = new CanvasEntity();
            calculationForm = new CalculationComponents(entity);
            numericUpDown1.Minimum = 120;
            numericUpDown1.Maximum = 500;
            numericUpDown2.Minimum = 120;
            numericUpDown2.Maximum = 500;
            entity.Width = (int)numericUpDown1.Value;
            entity.Height = (int)numericUpDown2.Value;
        }

        private void btn_send_blank_Click(object sender, EventArgs e)
        {

        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            ClientEntity client = OrderEntity.Instance.GetClient();
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.PhoneNamber))
            {
                MessageBox.Show("Не заполнены Ф.И.О. клиента или телефон", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                documentContent = "";
                documentContent += "Ф.И.О. клиента: " + OrderEntity.Instance.GetClient().Name + " телефон: " + OrderEntity.Instance.GetClient().PhoneNamber + "\n";
                documentContent += "Дата: " + DateTime.Now.ToString("dd.MM.yyyy") + "\n";
                documentContent += "Размеры тюля: " + entity.Width + "x" + entity.Height + "\n";
                documentContent += "Размеры расправленного тюля: " + entity.RealWidth + "x" + entity.RealHeight + "\n";
                foreach (PropertyCanvas property in entity.GetPropertiesCanvas())
                {
                    documentContent += property.ToString() + "\n";
                }
                stringToPrint = documentContent;
                printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ClientSize = new Size(600, 800);
                printPreviewDialog1.Show();
            }
        }

        private void EmailClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.Out.WriteLine("Completed");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            e.Graphics.MeasureString(stringToPrint, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);

            stringToPrint = stringToPrint.Substring(charactersOnPage);

            e.HasMorePages = (stringToPrint.Length > 0);

            if (!e.HasMorePages)
            {
                stringToPrint = documentContent;
            }

        }
    }
}
