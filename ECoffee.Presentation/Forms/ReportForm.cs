using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response.Report;
using ECoffee.Application.Enums;
using ECoffee.Application.Services;
using System.Text.Json;

namespace ECoffee.Presentation.Forms
{
    public partial class ReportForm : Form
    {
        private readonly ReportService reportService;
        private bool _isInitializing = true;

        private ReportResponse _lastResponse;

        public ReportForm(ReportService reportService)
        {
            InitializeComponent();
            this.reportService = reportService;
        }

        private async void ReportForm_Load(object sender, EventArgs e)
        {
            await wv2Report.EnsureCoreWebView2Async();

            // Chuẩn bị combobox
            var items = new List<KeyValuePair<ReportGranularity, string>>
            {
                new(ReportGranularity.Day, "Ngày"),
                new(ReportGranularity.Week, "Tuần"),
                new(ReportGranularity.Month, "Tháng")
            };

            cbReportGranularity.DataSource = items;
            cbReportGranularity.DisplayMember = "Value";
            cbReportGranularity.ValueMember = "Key";
            cbReportGranularity.SelectedIndex = 0;
            _isInitializing = false;

            // Đăng ký DOMContentLoaded 1 lần duy nhất
            wv2Report.CoreWebView2.DOMContentLoaded += async (s, args) =>
            {
                if (_lastResponse != null)
                {
                    await InjectReportData(_lastResponse);
                }
            };

            // Load HTML 1 lần
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "report_day.html");
            wv2Report.Source = new Uri(path);

            // Render report lần đầu
            var selected = ((KeyValuePair<ReportGranularity, string>)cbReportGranularity.SelectedItem).Key;
            var (from, to) = GetDateRange(selected);
            await RenderReportAsync(new ReportFilter(from, to, selected));
        }

        private async void cbReportGranularity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            if (wv2Report.CoreWebView2 == null) return;

            var selected = ((KeyValuePair<ReportGranularity, string>)cbReportGranularity.SelectedItem).Key;
            var (from, to) = GetDateRange(selected);
            await RenderReportAsync(new ReportFilter(from, to, selected));
        }

        private async Task RenderReportAsync(ReportFilter filter)
        {
            _lastResponse = await reportService.GetReportAsync(filter);

            if (wv2Report.CoreWebView2 != null)
            {
                await InjectReportData(_lastResponse);
            }
        }

        private async Task InjectReportData(ReportResponse response)
        {
            string json = JsonSerializer.Serialize(response);

            // JS: clear chart cũ trước khi vẽ
            string scriptInject = $@"
                window.reportData = {json};

                function updateCharts() {{
                    renderSummary(window.reportData.Summary);

                    // Line chart revenue
                    if(window.revenueChartInstance) window.revenueChartInstance.destroy();
                    renderLineChart('revenueChart', window.reportData.RevenueChart);

                    // Bar chart orders
                    if(window.orderChartInstance) window.orderChartInstance.destroy();
                    renderBarChart('orderChart', window.reportData.OrderChart);

                    // Top / bottom products
                    renderProducts('topProducts', window.reportData.TopProducts);
                    renderProducts('bottomProducts', window.reportData.BottomProducts);
                }}

                // Wait for chart elements
                function waitForElement(id, callback) {{
                    var el = document.getElementById(id);
                    if(el) callback();
                    else setTimeout(() => waitForElement(id, callback), 50);
                }}

                waitForElement('revenueChart', updateCharts);
            ";

            await wv2Report.ExecuteScriptAsync(scriptInject);
        }

        private (DateTime from, DateTime to) GetDateRange(ReportGranularity granularity)
        {
            var now = DateTime.Now;
            switch (granularity)
            {
                case ReportGranularity.Day:
                    return (now.Date, now.Date.AddDays(1).AddTicks(-1));
                case ReportGranularity.Week:
                    int diff = (7 + (int)now.DayOfWeek - 1) % 7; 
                    var startOfWeek = now.Date.AddDays(-diff);
                    var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);
                    return (startOfWeek, endOfWeek);
                case ReportGranularity.Month:
                    var startOfMonth = new DateTime(now.Year, now.Month, 1);
                    var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);
                    return (startOfMonth, endOfMonth);
                default:
                    return (now.Date, now.Date.AddDays(1).AddTicks(-1));
            }
        }
    }
}