namespace ECoffee.Presentation.Forms
{
    public partial class SimplePromptForm : Form
    {
        public string Value => tbValue.Text.Trim();
        public SimplePromptForm(string title, string initialValue = "")
        {
            InitializeComponent();
            Text = title;
            lTitle.Text = title;
            tbValue.Text = initialValue;
        }
        private void bOk_Click(object sender, EventArgs e) { DialogResult = DialogResult.OK; Close(); }
        private void bCancel_Click(object sender, EventArgs e) => Close();
    }
}
