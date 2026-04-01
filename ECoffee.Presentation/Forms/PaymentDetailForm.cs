using ECoffee.Application.DTOs.Response;

namespace ECoffee.Presentation.Forms
{
    public partial class PaymentDetailForm : Form
    {
        private readonly PaymentResponse _payment;
        public PaymentDetailForm(PaymentResponse payment)
        {
            InitializeComponent();
            _payment = payment;
        }
        private void PaymentDetailForm_Load(object sender, EventArgs e)
        {
            lPaymentIdValue.Text = _payment.Id.ToString();
            lOrderIdValue.Text = _payment.OrderId.ToString();
            lMethodValue.Text = _payment.Method;
            lAmountValue.Text = _payment.Amount.ToString("0,0");
            lStatusValue.Text = _payment.Status;
            lTransactionValue.Text = _payment.TransactionRef ?? "(chưa có)";
            lCreatedValue.Text = _payment.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            lUpdatedValue.Text = _payment.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            tbQrContent.Text = _payment.QrContent;
        }
        private void bClose_Click(object sender, EventArgs e) => Close();
    }
}
