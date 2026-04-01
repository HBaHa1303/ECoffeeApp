using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class PaymentManagementForm : Form
    {
        private readonly PaymentService _paymentService;
        public PaymentManagementForm(PaymentService paymentService)
        {
            InitializeComponent();
            _paymentService = paymentService;
        }

        private async void PaymentManagementForm_Load(object sender, EventArgs e)
        {
            lbMethods.DataSource = await _paymentService.GetMethodsAsync();
            lbMethods.DisplayMember = nameof(PaymentMethodOptionResponse.Name);
            await LoadPaymentsAsync();
        }

        private async Task LoadPaymentsAsync(string? keyword = null)
        {
            try
            {
                dgvPayments.AutoGenerateColumns = false;
                dgvPayments.DataSource = await _paymentService.FindAllAsync(keyword);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private PaymentResponse? SelectedPayment() => dgvPayments.CurrentRow?.DataBoundItem as PaymentResponse;
        private async void bSearch_Click(object sender, EventArgs e) => await LoadPaymentsAsync(tbSearch.Text);
        private async void bRefresh_Click(object sender, EventArgs e) { tbSearch.Clear(); await LoadPaymentsAsync(); }
        private async void bCreate_Click(object sender, EventArgs e) { using var f = new PaymentCreateForm(_paymentService); if (f.ShowDialog(this) == DialogResult.OK) await LoadPaymentsAsync(tbSearch.Text); }
        private void bView_Click(object sender, EventArgs e) { var p=SelectedPayment(); if (p==null){MessageBox.Show("Hãy chọn một payment trước."); return;} using var f=new PaymentDetailForm(p); f.ShowDialog(this); }
        private void bQr_Click(object sender, EventArgs e) { var p=SelectedPayment(); if (p==null){MessageBox.Show("Hãy chọn một payment trước."); return;} using var f=new QrPreviewForm(p); f.ShowDialog(this); }
        private async void bCheckSuccess_Click(object sender, EventArgs e)
        {
            try
            {
                var p=SelectedPayment(); if (p==null){MessageBox.Show("Hãy chọn một payment trước."); return;}
                using var prompt = new SimplePromptForm("Nhập mã giao dịch", p.TransactionRef ?? $"TXN-{p.Id}-{DateTime.Now:yyyyMMddHHmmss}");
                if (prompt.ShowDialog(this) != DialogResult.OK) return;
                await _paymentService.CheckSuccessAsync(p.Id, prompt.Value);
                await LoadPaymentsAsync(tbSearch.Text);
            }
            catch (Exception ex) when (ex is BadRequestException || ex is NotFoundException)
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void dgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex>=0) bView_Click(sender, EventArgs.Empty); }
    }
}
