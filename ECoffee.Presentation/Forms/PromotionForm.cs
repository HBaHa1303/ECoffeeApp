using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Services;
using ECoffee.Presentation.Enums;
using System.Data;

namespace ECoffee.Presentation.Forms
{
    public partial class PromotionForm : Form
    {
        private readonly FormMode _mode;
        private readonly long? _promotionId;
        private readonly PromotionService _promotionService;

        public PromotionForm(PromotionService promotionService, FormMode mode, long? userId)
        {
            InitializeComponent();
            _mode = mode;
            _promotionId = userId;
            _promotionService = promotionService;
        }

        private async void StaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = Enum.GetValues<PromotionType>().ToList();

                cbType.DataSource = status;

                if (_mode == FormMode.Create)
                {
                    lHeader.Text = "Tạo chương trình khuyến mãi";
                    bSubmit.Text = "Tạo";
                }
                if (_mode == FormMode.Edit)
                {
                    lHeader.Text = "Sửa chương trình khuyến mãi";
                    bSubmit.Text = "Sửa";

                    if (_promotionId is null)
                    {
                        throw new BadRequestException("Sửa thông tin cần thông tin promotion id");
                    }
                    PromotionResponse promotionResponse = _promotionService.FindById(_promotionId.Value);

                    tbDiscountAmount.Text = promotionResponse.DiscountAmount.ToString();
                    tbName.Text = promotionResponse.Name;
                    cbType.Text = promotionResponse.TypeText;
                    tbDiscountPercent.Text = promotionResponse.DiscountPercent.ToString();
                    dtpStartDate.Value = (DateTime)(promotionResponse.StartDate);
                    dtpEndDate.Value = (DateTime)(promotionResponse.EndDate);
                }
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void bSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal discountAmount = decimal.Parse(tbDiscountAmount.Text);
                string name = tbName.Text;
                PromotionType type = PromotionType.BuyXGetYFree;
                decimal discountPercent = decimal.Parse(tbDiscountPercent.Text);
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                string message = string.Empty;
                if (_mode == FormMode.Create)
                {
                    await CreatePromotion(discountAmount, name, type, discountPercent, startDate, endDate);
                    message = "Tạo chương trình khuyến mãi thành công";
                }
                if (_mode == FormMode.Edit)
                {
                    if (_promotionId is null)
                    {
                        throw new BadRequestException("Sửa thông tin cần thông tin user id");
                    }
                    await UpdatePromotion(_promotionId.Value, discountAmount, name, type, discountPercent, startDate, endDate);
                    message = "Cập nhật chương trình khuyến mãi thành công";
                }
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ConflictException ex)
            {
                MessageBox.Show(ex.Message, "Thông tin người dùng đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdatePromotion(long id, decimal discountAmount, string name, PromotionType type, decimal discountPercent, DateTime startDate, DateTime endDate)
        {
            UpdatePromotionRequest request = new UpdatePromotionRequest
            {
                DiscountAmount = discountAmount,
                Name = name,
                DiscountPercent = discountPercent,
                EndDate = endDate,
                StartDate = startDate,
                Type = type
            };

            await _promotionService.UpdatePromotionAsync(id, request);
        }

        private async Task CreatePromotion(decimal discountAmount, string name, PromotionType type, decimal discountPercent, DateTime startDate, DateTime endDate)
        {
            CreatePromotionRequest request = new CreatePromotionRequest
            {
                DiscountAmount = discountAmount,
                Name = name,
                DiscountPercent = discountPercent,
                EndDate = endDate,
                StartDate = startDate,
                Type = type
            };

            await _promotionService.CreatePromotionAsync(request);
        }



        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
