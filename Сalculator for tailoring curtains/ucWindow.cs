using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator_for_tailoring_curtains
{
    public partial class ucWindow : UserControl
    {
        private static ucWindow _instance;
        private int oldNumTulle;
        private List<ucTulle> tulles;

        public ucWindow()
        {
            InitializeComponent();
        }

        public static ucWindow Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucWindow();
                    _instance.Dock = DockStyle.Fill;
                }
                return _instance;
            }
        }

        private void ucWindow_Load(object sender, EventArgs e)
        {
            tulles = new List<ucTulle>();
            oldNumTulle = (int)num_tulle_count.Value;
            flp_scheme_win.Height = btn_sсheme_win_1.Height + btn_sсheme_win_1.Margin.Top + btn_sсheme_win_1.Margin.Bottom;
        }

        private void ucWindow_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = Width - 6;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cb_Add_Tulle_CheckedChanged(object sender, EventArgs e)
        {
            lb_tulle_count.Visible = cb_Add_Tulle.Checked;
            num_tulle_count.Visible = cb_Add_Tulle.Checked;
            if (cb_Add_Tulle.Checked)
                updateTableTulle();
            else
                removeTableTulle();
        }

        private void btn_sсheme_win_1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);
            int charactersOnPage = 0;
            int linesPerPage = 0;
            string stringToPrint = "wqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqwewqeqweqweqweqweqweqwe";
            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, new Font(FontFamily.GenericMonospace, 12, FontStyle.Underline, GraphicsUnit.Pixel),
                e.MarginBounds.Size, StringFormat.GenericDefault,
                out charactersOnPage, out linesPerPage);
            //e.Graphics.MeasureString()
            e.Graphics.DrawString(stringToPrint, new Font(FontFamily.GenericMonospace, 12, FontStyle.Underline, GraphicsUnit.Pixel), Brushes.Black,
                e.MarginBounds, StringFormat.GenericDefault);
            //e.Graphics.DrawString("test", Font, brush, 0, 0);
        }

        private void cb_Add_Drapes_CheckedChanged(object sender, EventArgs e)
        {
            lb_drapes_count.Visible = cb_Add_Drapes.Checked;
            num_drapes_count.Visible = cb_Add_Drapes.Checked;
        }

        private void num_tulle_count_ValueChanged(object sender, EventArgs e)
        {
            updateTableTulle();
        }

        public void updateTableTulle()
        {
            if (oldNumTulle < num_tulle_count.Value)
            {
                while (oldNumTulle != num_tulle_count.Value)
                {
                    ucTulle tulle = new ucTulle();
                    tulles.Add(tulle);
                    tulle.Dock = DockStyle.Fill;
                    tulle.Text = "Тюль " + tulles.Count;
                    if (tableLayoutPanel1.RowCount < tulles.Count)
                        tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.Controls.Add(tulle, 0, 2 + tulles.Count);
                    oldNumTulle++;
                }
            }
            if (oldNumTulle > num_tulle_count.Value)
            {
                while (oldNumTulle != num_tulle_count.Value)
                {
                    tableLayoutPanel1.Controls.Remove(tulles[tulles.Count - 1]);
                    tableLayoutPanel1.RowCount--;
                    tulles.RemoveAt(tulles.Count - 1);
                    oldNumTulle--;
                }
            }
        }

        public void removeTableTulle()
        {
            while(oldNumTulle != 0)
            {
                tableLayoutPanel1.Controls.Remove(tulles[tulles.Count - 1]);
                tableLayoutPanel1.RowCount--;
                tulles.RemoveAt(tulles.Count - 1);
                oldNumTulle--;
            }
        }

        public void updateTulle()
        {
            foreach(ucTulle tulle in tulles)
            {
                tulle.updateSize();
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            /*if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);*/
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            OrderEntity.Instance.GetClient().PhoneNamber = textBox2.Text;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            OrderEntity.Instance.GetClient().Name = textBox1.Text;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue >= '0' && e.KeyValue <= '9' )
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
