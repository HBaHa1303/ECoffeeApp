using ECoffee.Application.DTOs.Response;

namespace ECoffee.Presentation.Forms
{
    public partial class QrPreviewForm : Form
    {
        private readonly PaymentResponse _payment;
        public QrPreviewForm(PaymentResponse payment)
        {
            InitializeComponent();
            _payment = payment;
        }
        private void QrPreviewForm_Load(object sender, EventArgs e)
        {
            tbQrAscii.Text = BuildAsciiQr(_payment);
        }
        private static string BuildAsciiQr(PaymentResponse payment)
        {
            var lines = new List<string>{"████████████████████████████","██ ▄▄▄▄▄ █ ▀▄▀ █ ▄▄▄▄▄ ██","██ █   █ █▄▀▄█ █ █   █ ██","██ █▄▄▄█ █ ▀ █ █ █▄▄▄█ ██","██▄▄▄▄▄▄▄█ █▄█ █▄▄▄▄▄▄▄██","██▄▀█▄ ▄▄▄▄▀█ ▄ ▀▀▄█▀█▄██","██ █▄▄▀▄▄▄█▀▄▀█▀▀▄  ▄▄██","██ ▀▄▄▄▀▄▀▀▄██▄▀ ▀▀▄▄▄██","████████████████████████████", string.Empty, "QR Content:", payment.QrContent};
            return string.Join(Environment.NewLine, lines);
        }
        private void bClose_Click(object sender, EventArgs e) => Close();
    }
}
