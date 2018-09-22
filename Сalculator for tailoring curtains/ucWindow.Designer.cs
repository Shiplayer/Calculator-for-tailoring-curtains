namespace Сalculator_for_tailoring_curtains
{
    partial class ucWindow
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flp_scheme_win = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_sсheme_win = new System.Windows.Forms.Label();
            this.btn_sсheme_win_1 = new System.Windows.Forms.Button();
            this.btn_sсheme_win_2 = new System.Windows.Forms.Button();
            this.btn_sсheme_win_3 = new System.Windows.Forms.Button();
            this.btn_sсheme_win_4 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_Add_Tulle = new System.Windows.Forms.CheckBox();
            this.lb_tulle_count = new System.Windows.Forms.Label();
            this.num_tulle_count = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_Add_Drapes = new System.Windows.Forms.CheckBox();
            this.lb_drapes_count = new System.Windows.Forms.Label();
            this.num_drapes_count = new System.Windows.Forms.NumericUpDown();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flp_scheme_win.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_tulle_count)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_drapes_count)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flp_scheme_win, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 118);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flp_scheme_win
            // 
            this.flp_scheme_win.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.flp_scheme_win, 2);
            this.flp_scheme_win.Controls.Add(this.lb_sсheme_win);
            this.flp_scheme_win.Controls.Add(this.btn_sсheme_win_1);
            this.flp_scheme_win.Controls.Add(this.btn_sсheme_win_2);
            this.flp_scheme_win.Controls.Add(this.btn_sсheme_win_3);
            this.flp_scheme_win.Controls.Add(this.btn_sсheme_win_4);
            this.flp_scheme_win.Location = new System.Drawing.Point(3, 35);
            this.flp_scheme_win.Name = "flp_scheme_win";
            this.flp_scheme_win.Size = new System.Drawing.Size(816, 37);
            this.flp_scheme_win.TabIndex = 1;
            this.flp_scheme_win.WrapContents = false;
            // 
            // lb_sсheme_win
            // 
            this.lb_sсheme_win.AutoSize = true;
            this.lb_sсheme_win.Location = new System.Drawing.Point(10, 10);
            this.lb_sсheme_win.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.lb_sсheme_win.Name = "lb_sсheme_win";
            this.lb_sсheme_win.Size = new System.Drawing.Size(68, 13);
            this.lb_sсheme_win.TabIndex = 0;
            this.lb_sсheme_win.Text = "Схемы окон";
            // 
            // btn_sсheme_win_1
            // 
            this.btn_sсheme_win_1.AutoSize = true;
            this.btn_sсheme_win_1.Location = new System.Drawing.Point(81, 5);
            this.btn_sсheme_win_1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_sсheme_win_1.Name = "btn_sсheme_win_1";
            this.btn_sсheme_win_1.Size = new System.Drawing.Size(85, 23);
            this.btn_sсheme_win_1.TabIndex = 1;
            this.btn_sсheme_win_1.Text = "Схема окна 1";
            this.btn_sсheme_win_1.UseVisualStyleBackColor = true;
            this.btn_sсheme_win_1.Click += new System.EventHandler(this.btn_sсheme_win_1_Click);
            // 
            // btn_sсheme_win_2
            // 
            this.btn_sсheme_win_2.AutoSize = true;
            this.btn_sсheme_win_2.Location = new System.Drawing.Point(172, 5);
            this.btn_sсheme_win_2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_sсheme_win_2.Name = "btn_sсheme_win_2";
            this.btn_sсheme_win_2.Size = new System.Drawing.Size(85, 23);
            this.btn_sсheme_win_2.TabIndex = 2;
            this.btn_sсheme_win_2.Text = "Схема окна 2";
            this.btn_sсheme_win_2.UseVisualStyleBackColor = true;
            // 
            // btn_sсheme_win_3
            // 
            this.btn_sсheme_win_3.AutoSize = true;
            this.btn_sсheme_win_3.Location = new System.Drawing.Point(263, 5);
            this.btn_sсheme_win_3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_sсheme_win_3.Name = "btn_sсheme_win_3";
            this.btn_sсheme_win_3.Size = new System.Drawing.Size(85, 23);
            this.btn_sсheme_win_3.TabIndex = 3;
            this.btn_sсheme_win_3.Text = "Схема окна 3";
            this.btn_sсheme_win_3.UseVisualStyleBackColor = true;
            // 
            // btn_sсheme_win_4
            // 
            this.btn_sсheme_win_4.AutoSize = true;
            this.btn_sсheme_win_4.Location = new System.Drawing.Point(354, 5);
            this.btn_sсheme_win_4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btn_sсheme_win_4.Name = "btn_sсheme_win_4";
            this.btn_sсheme_win_4.Size = new System.Drawing.Size(85, 23);
            this.btn_sсheme_win_4.TabIndex = 4;
            this.btn_sсheme_win_4.Text = "Схема окна 4";
            this.btn_sсheme_win_4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cb_Add_Tulle);
            this.flowLayoutPanel1.Controls.Add(this.lb_tulle_count);
            this.flowLayoutPanel1.Controls.Add(this.num_tulle_count);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(405, 37);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cb_Add_Tulle
            // 
            this.cb_Add_Tulle.AutoSize = true;
            this.cb_Add_Tulle.Location = new System.Drawing.Point(10, 10);
            this.cb_Add_Tulle.Margin = new System.Windows.Forms.Padding(10);
            this.cb_Add_Tulle.Name = "cb_Add_Tulle";
            this.cb_Add_Tulle.Size = new System.Drawing.Size(104, 17);
            this.cb_Add_Tulle.TabIndex = 2;
            this.cb_Add_Tulle.Text = "Добавить тюль";
            this.cb_Add_Tulle.UseVisualStyleBackColor = true;
            this.cb_Add_Tulle.CheckedChanged += new System.EventHandler(this.cb_Add_Tulle_CheckedChanged);
            // 
            // lb_tulle_count
            // 
            this.lb_tulle_count.AutoSize = true;
            this.lb_tulle_count.Location = new System.Drawing.Point(134, 10);
            this.lb_tulle_count.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.lb_tulle_count.Name = "lb_tulle_count";
            this.lb_tulle_count.Size = new System.Drawing.Size(69, 13);
            this.lb_tulle_count.TabIndex = 3;
            this.lb_tulle_count.Text = "Количество:";
            this.lb_tulle_count.Visible = false;
            // 
            // num_tulle_count
            // 
            this.num_tulle_count.AutoSize = true;
            this.num_tulle_count.Location = new System.Drawing.Point(213, 8);
            this.num_tulle_count.Margin = new System.Windows.Forms.Padding(5, 8, 10, 8);
            this.num_tulle_count.Name = "num_tulle_count";
            this.num_tulle_count.Size = new System.Drawing.Size(41, 20);
            this.num_tulle_count.TabIndex = 4;
            this.num_tulle_count.Visible = false;
            this.num_tulle_count.ValueChanged += new System.EventHandler(this.num_tulle_count_ValueChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.cb_Add_Drapes);
            this.flowLayoutPanel2.Controls.Add(this.lb_drapes_count);
            this.flowLayoutPanel2.Controls.Add(this.num_drapes_count);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(414, 78);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(405, 37);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // cb_Add_Drapes
            // 
            this.cb_Add_Drapes.AutoSize = true;
            this.cb_Add_Drapes.Location = new System.Drawing.Point(10, 10);
            this.cb_Add_Drapes.Margin = new System.Windows.Forms.Padding(10);
            this.cb_Add_Drapes.Name = "cb_Add_Drapes";
            this.cb_Add_Drapes.Size = new System.Drawing.Size(126, 17);
            this.cb_Add_Drapes.TabIndex = 3;
            this.cb_Add_Drapes.Text = "Добавить партьера";
            this.cb_Add_Drapes.UseVisualStyleBackColor = true;
            this.cb_Add_Drapes.CheckedChanged += new System.EventHandler(this.cb_Add_Drapes_CheckedChanged);
            // 
            // lb_drapes_count
            // 
            this.lb_drapes_count.AutoSize = true;
            this.lb_drapes_count.Location = new System.Drawing.Point(156, 10);
            this.lb_drapes_count.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.lb_drapes_count.Name = "lb_drapes_count";
            this.lb_drapes_count.Size = new System.Drawing.Size(69, 13);
            this.lb_drapes_count.TabIndex = 3;
            this.lb_drapes_count.Text = "Количество:";
            this.lb_drapes_count.Visible = false;
            // 
            // num_drapes_count
            // 
            this.num_drapes_count.AutoSize = true;
            this.num_drapes_count.Location = new System.Drawing.Point(235, 8);
            this.num_drapes_count.Margin = new System.Windows.Forms.Padding(5, 8, 10, 8);
            this.num_drapes_count.Name = "num_drapes_count";
            this.num_drapes_count.Size = new System.Drawing.Size(41, 20);
            this.num_drapes_count.TabIndex = 4;
            this.num_drapes_count.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.textBox1);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.textBox2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(816, 26);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ф.И.О. клиента:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Телефон:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(418, 3);
            this.textBox2.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.textBox2.MaxLength = 11;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // ucWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucWindow";
            this.Size = new System.Drawing.Size(828, 411);
            this.Load += new System.EventHandler(this.ucWindow_Load);
            this.Resize += new System.EventHandler(this.ucWindow_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flp_scheme_win.ResumeLayout(false);
            this.flp_scheme_win.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_tulle_count)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_drapes_count)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_sсheme_win;
        private System.Windows.Forms.FlowLayoutPanel flp_scheme_win;
        private System.Windows.Forms.Button btn_sсheme_win_1;
        private System.Windows.Forms.Button btn_sсheme_win_2;
        private System.Windows.Forms.Button btn_sсheme_win_3;
        private System.Windows.Forms.Button btn_sсheme_win_4;
        private System.Windows.Forms.CheckBox cb_Add_Tulle;
        private System.Windows.Forms.CheckBox cb_Add_Drapes;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lb_tulle_count;
        private System.Windows.Forms.NumericUpDown num_tulle_count;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lb_drapes_count;
        private System.Windows.Forms.NumericUpDown num_drapes_count;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}
