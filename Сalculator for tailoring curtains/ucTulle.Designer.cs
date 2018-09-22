namespace Сalculator_for_tailoring_curtains
{
    partial class ucTulle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTulle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_send_blank = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btn_preview = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.btn_send_blank);
            this.flowLayoutPanel2.Controls.Add(this.btn_preview);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(294, 160);
            this.flowLayoutPanel2.TabIndex = 6;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер в готовом виде";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 23);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AutoSize = true;
            this.numericUpDown1.Location = new System.Drawing.Point(62, 3);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.numericUpDown2);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 42);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(162, 26);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Высота:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.AutoSize = true;
            this.numericUpDown2.Location = new System.Drawing.Point(61, 3);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(3, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Обработка тюля";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_send_blank
            // 
            this.btn_send_blank.AutoSize = true;
            this.btn_send_blank.Location = new System.Drawing.Point(3, 103);
            this.btn_send_blank.Name = "btn_send_blank";
            this.btn_send_blank.Size = new System.Drawing.Size(104, 23);
            this.btn_send_blank.TabIndex = 7;
            this.btn_send_blank.Text = "Отправить бланк";
            this.btn_send_blank.UseVisualStyleBackColor = true;
            this.btn_send_blank.Visible = false;
            this.btn_send_blank.Click += new System.EventHandler(this.btn_send_blank_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
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
            // btn_preview
            // 
            this.btn_preview.AutoSize = true;
            this.btn_preview.Location = new System.Drawing.Point(3, 132);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(162, 23);
            this.btn_preview.TabIndex = 8;
            this.btn_preview.Text = "Предварительный просмотр";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // ucTulle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucTulle";
            this.Size = new System.Drawing.Size(300, 179);
            this.Load += new System.EventHandler(this.ucTulle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_send_blank;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
