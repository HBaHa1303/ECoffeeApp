using ECoffee.Infrastructure.Entities;
using ECoffee.Presentation.Helpers;
using ECoffee.Presentation.Services;
using ECoffee.Presentation.ViewModels;

namespace ECoffee.Presentation.Forms
{
    public partial class PaymentManagementForm : Form
    {
        private readonly PaymentModuleService _paymentModuleService;
        private readonly System.Windows.Forms.Timer _searchTimer = new();

        public PaymentManagementForm(PaymentModuleService paymentModuleService)
        {
            InitializeComponent();
            _paymentModuleService = paymentModuleService;
            _searchTimer.Interval = 400;
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private async void PaymentManagementForm_Load(object sender, EventArgs e)
        {
            dgvPayments.AutoGenerateColumns = false;
            cboMethod.DisplayMember = "Key";
            cboMethod.ValueMember = "Value";
            cboMethod.DataSource = _paymentModuleService.GetMethods();
            await LoadPaymentsAsync();
        }

        private async Task LoadPaymentsAsync()
        {
            dgvPayments.DataSource = null;
            dgvPayments.DataSource = await _paymentModuleService.GetPaymentsAsync(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private async void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            await LoadPaymentsAsync();
        }

        private async void btnCreatePayment_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new PaymentCreateViewModel
                {
                    OrderId = (long)nudOrderId.Value,
                    Amount = nudAmount.Value,
                    Method = cboMethod.SelectedValue is PaymentMethod method ? method : PaymentMethod.Cash,
                    TransactionRef = txtTransactionRef.Text,
                    Status = PaymentStatus.Pending,
                    CreatedBy = "system"
                };

                var id = await _paymentModuleService.CreatePaymentAsync(model);
                MessageBox.Show($"Tạo payment thành công. PaymentId = {id}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPaymentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateQr_Click(object sender, EventArgs e)
        {
            var orderId = (long)nudOrderId.Value;
            var amount = nudAmount.Value;
            var content = string.IsNullOrWhiteSpace(txtTransactionRef.Text)
                ? _paymentModuleService.BuildTransactionRef(orderId)
                : txtTransactionRef.Text.Trim();

            txtTransactionRef.Text = content;
            picQr.Image?.Dispose();
            picQr.Image = VietQrHelper.GenerateQrBitmap(
                txtBankName.Text.Trim(),
                txtAccountNo.Text.Trim(),
                txtAccountName.Text.Trim(),
                amount,
                content);
        }

        private async void btnCheckSuccess_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow?.DataBoundItem is not PaymentGridItemViewModel item)
            {
                MessageBox.Show("Vui lòng chọn 1 payment để kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _paymentModuleService.MarkAsPaidAsync(item.Id, "system");
            MessageBox.Show("Payment đã được cập nhật sang Paid.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadPaymentsAsync();
        }

        private async void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvPayments.Columns[e.ColumnIndex].Name != "ViewPayment")
            {
                return;
            }

            if (dgvPayments.Rows[e.RowIndex].DataBoundItem is not PaymentGridItemViewModel item)
            {
                return;
            }

            var detail = await _paymentModuleService.FindByIdAsync(item.Id);
            if (detail == null)
            {
                MessageBox.Show("Không tìm thấy payment.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                $"PaymentId: {detail.Id}\nOrderId: {detail.OrderId}\nMethod: {detail.Method}\nAmount: {detail.Amount:n0}\nStatus: {detail.Status}\nTransactionRef: {detail.TransactionRef}",
                "Chi tiết payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
