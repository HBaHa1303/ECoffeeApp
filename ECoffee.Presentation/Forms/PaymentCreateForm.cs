using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class PaymentCreateForm : Form
    {
        private readonly PaymentService _paymentService;
        public PaymentCreateForm(PaymentService paymentService)
        {
            InitializeComponent();
            _paymentService = paymentService;
        }
        private async void PaymentCreateForm_Load(object sender, EventArgs e)
        {
            cbMethod.DataSource = await _paymentService.GetMethodsAsync();
            cbMethod.DisplayMember = nameof(PaymentMethodOptionResponse.Name);
            cbMethod.ValueMember = nameof(PaymentMethodOptionResponse.Name);
        }
        private async void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new CreatePaymentRequest{ OrderId=(long)nudOrderId.Value, Method=(cbMethod.SelectedItem as PaymentMethodOptionResponse)?.Name ?? string.Empty, Amount=nudAmount.Value <= 0 ? null : nudAmount.Value, TransactionRef=string.IsNullOrWhiteSpace(tbTransactionRef.Text) ? null : tbTransactionRef.Text.Trim()};
                await _paymentService.CreateAsync(request);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) when (ex is BadRequestException || ex is NotFoundException)
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void bCancel_Click(object sender, EventArgs e) => Close();
    }
}
