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
            labelTongTienItem.Location = new Point(180, 41);
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
            nmrSoLuong.Location = new Point(129, 39);
            nmrSoLuong.Name = "nmrSoLuong";
            nmrSoLuong.Size = new Size(45, 27);
            nmrSoLuong.TabIndex = 4;
            this.nmrSoLuong.ValueChanged += new System.EventHandler(this.nmrSoLuong_ValueChanged);
            // 
            // ucOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
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
    }
}
