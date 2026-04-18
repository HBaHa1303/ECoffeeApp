namespace ECoffee.Presentation.Forms
{
    partial class ucOrderItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTenMon = new Label();
            labelGiaMon = new Label();
            labelTongTienItem = new Label();
            label4 = new Label();
            nmrSoLuong = new NumericUpDown();
            cboSize = new ComboBox();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)nmrSoLuong).BeginInit();
            SuspendLayout();
            // 
            // labelTenMon
            // 
            labelTenMon.AutoSize = true;
            labelTenMon.Location = new Point(13, 27);
            labelTenMon.Name = "labelTenMon";
            labelTenMon.Size = new Size(66, 20);
            labelTenMon.TabIndex = 0;
            labelTenMon.Text = "Tên món";
            // 
            // labelGiaMon
            // 
            labelGiaMon.AutoSize = true;
            labelGiaMon.Location = new Point(13, 57);
            labelGiaMon.Name = "labelGiaMon";
            labelGiaMon.Size = new Size(17, 20);
            labelGiaMon.TabIndex = 1;
            labelGiaMon.Text = "0";
            // 
            // labelTongTienItem
            // 
            labelTongTienItem.AutoSize = true;
            labelTongTienItem.Location = new Point(180, 27);
            labelTongTienItem.Name = "labelTongTienItem";
            labelTongTienItem.Size = new Size(72, 20);
            labelTongTienItem.TabIndex = 2;
            labelTongTienItem.Text = "Tổng tiền";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 57);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 3;
            label4.Text = "VND";
            // 
            // nmrSoLuong
            // 
            nmrSoLuong.Location = new Point(115, 27);
            nmrSoLuong.Name = "nmrSoLuong";
            nmrSoLuong.Size = new Size(59, 27);
            nmrSoLuong.TabIndex = 4;
            nmrSoLuong.ValueChanged += nmrSoLuong_ValueChanged;
            // 
            // cboSize
            // 
            cboSize.FormattingEnabled = true;
            cboSize.Location = new Point(115, 60);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(59, 28);
            cboSize.TabIndex = 5;
            cboSize.SelectedIndexChanged += cboSize_SelectedIndexChanged;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(193, 60);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(43, 29);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "X";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // ucOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            Controls.Add(btnXoa);
            Controls.Add(cboSize);
            Controls.Add(nmrSoLuong);
            Controls.Add(label4);
            Controls.Add(labelTongTienItem);
            Controls.Add(labelGiaMon);
            Controls.Add(labelTenMon);
            Name = "ucOrderItem";
            Size = new Size(250, 100);
            ((System.ComponentModel.ISupportInitialize)nmrSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        public Label labelTenMon;
        public Label labelGiaMon;
        public Label labelTongTienItem;
        public NumericUpDown nmrSoLuong;
        private Button btnXoa;
        public ComboBox cboSize;
    }
}
