namespace ECoffee.Presentation.Forms
{
    partial class ucKdsCard
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
            lblOrderNumber = new Label();
            flpItems = new FlowLayoutPanel();
            panel1 = new Panel();
            lblNote = new Label();
            panel2 = new Panel();
            btnAction = new Button();
            lblTimeAgo = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderNumber.Location = new Point(18, 9);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(133, 23);
            lblOrderNumber.TabIndex = 0;
            lblOrderNumber.Text = "#OrderNumber";
            // 
            // flpItems
            // 
            flpItems.Location = new Point(3, 54);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(244, 128);
            flpItems.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNote);
            panel1.Location = new Point(0, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 36);
            panel1.TabIndex = 2;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(18, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(42, 20);
            lblNote.TabIndex = 0;
            lblNote.Text = "Note";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAction);
            panel2.Location = new Point(18, 239);
            panel2.Name = "panel2";
            panel2.Size = new Size(201, 47);
            panel2.TabIndex = 3;
            // 
            // btnAction
            // 
            btnAction.Dock = DockStyle.Fill;
            btnAction.Location = new Point(0, 0);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(201, 47);
            btnAction.TabIndex = 0;
            btnAction.Text = "Hoàn tất";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // lblTimeAgo
            // 
            lblTimeAgo.AutoSize = true;
            lblTimeAgo.Location = new Point(18, 32);
            lblTimeAgo.Name = "lblTimeAgo";
            lblTimeAgo.Size = new Size(42, 20);
            lblTimeAgo.TabIndex = 4;
            lblTimeAgo.Text = "Time";
            // 
            // ucKdsCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(lblTimeAgo);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flpItems);
            Controls.Add(lblOrderNumber);
            Name = "ucKdsCard";
            Size = new Size(250, 300);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNumber;
        private FlowLayoutPanel flpItems;
        private Panel panel1;
        private Label lblNote;
        private Panel panel2;
        private Button btnAction;
        private Label lblTimeAgo;
    }
}
