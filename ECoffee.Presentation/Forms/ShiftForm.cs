using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Services;

namespace ECoffee.Presentation.Forms
{
    public partial class ShiftForm : Form
    {
        private readonly ShiftService _shiftService;
        private ShiftResponse? _currentShift;

        public ShiftForm(ShiftService shiftService)
        {
            InitializeComponent();
            _shiftService = shiftService;
        }

        private async void ShiftForm_Load(object sender, EventArgs e)
        {
            LoadCurrentShift();
        }

        private void LoadCurrentShift()
        {
            _currentShift = _shiftService.GetOpenShift();

            if (_currentShift != null)
            {
                lblStatus.Text = "Ca đang mở";
                lblStatus.ForeColor = Color.Green;

                lblInfo.Text = $"Mở ca: {_currentShift.StartTime:dd/MM/yyyy HH:mm}\n" +
                               $"Nhân viên: {_currentShift.UserName}\n" +
                               $"Tiền mở ca: {_currentShift.OpeningCash:N0} VNĐ\n" +
                               $"Tổng doanh thu: {_currentShift.TotalRevenue:N0} VNĐ";

                tbOpeningCash.Enabled = false;
                bOpenShift.Enabled = false;
                tbClosingCash.Enabled = true;
                bCloseShift.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Chưa có ca làm việc";
                lblStatus.ForeColor = Color.Red;

                lblInfo.Text = "Vui lòng nhập tiền mở ca để bắt đầu.";

                tbOpeningCash.Enabled = true;
                bOpenShift.Enabled = true;
                tbClosingCash.Enabled = false;
                bCloseShift.Enabled = false;
            }
        }

        private void bOpenShift_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(tbOpeningCash.Text, out decimal openingCash))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _shiftService.OpenShift(new Application.DTOs.Request.CreateShiftRequest { OpeningCash = openingCash });
                MessageBox.Show("Mở ca thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCurrentShift();
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCloseShift_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentShift == null) return;

                if (!decimal.TryParse(tbClosingCash.Text, out decimal closingCash))
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn đóng ca làm việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                _shiftService.CloseShift(_currentShift.Id, new Application.DTOs.Request.CloseShiftRequest { ClosingCash = closingCash });
                MessageBox.Show("Đóng ca thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCurrentShift();
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
