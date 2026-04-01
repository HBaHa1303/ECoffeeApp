namespace ECoffee.Presentation
{
    partial class ItemBox
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
            imgItem = new PictureBox();
            labelNameItem = new Label();
            labelPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)imgItem).BeginInit();
            SuspendLayout();
            // 
            // imgItem
            // 
            imgItem.Location = new Point(39, 26);
            imgItem.Name = "imgItem";
            imgItem.Size = new Size(125, 84);
            imgItem.TabIndex = 0;
            imgItem.TabStop = false;
            // 
            // labelNameItem
            // 
            labelNameItem.AutoSize = true;
            labelNameItem.Location = new Point(74, 125);
            labelNameItem.Name = "labelNameItem";
            labelNameItem.Size = new Size(66, 20);
            labelNameItem.TabIndex = 1;
            labelNameItem.Text = "Tên món";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(74, 159);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(64, 20);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "giá món";
            // 
            // ItemBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            Controls.Add(labelPrice);
            Controls.Add(labelNameItem);
            Controls.Add(imgItem);
            Name = "ItemBox";
            Size = new Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)imgItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imgItem;
        public Label labelNameItem;
        public Label labelPrice;
    }
}
