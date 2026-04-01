using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response.Report;
using ECoffee.Application.Enums;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace ECoffee.Infrastructure.Repositories
{
    public class ReportQuery : IReportQuery
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public ReportQuery(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<ReportResponse> BuildReportDayAsync(ReportFilter filter)
        {
            await using var _db = _dbFactory.CreateDbContext();
            var now = DateTime.Now.Date;
            var yesterday = DateTime.Now.Date.AddDays(-1);
            int days = 7;

            var currentDays = Enumerable.Range(0, days)
                .Select(i => now.AddDays(-i))
                .Reverse()
                .ToList();

            var previousDays = currentDays.Select(d => d.AddDays(-days)).ToList();

            var startDate = previousDays.First();
            var endDate = now.AddDays(1).AddTicks(-1);

            var orders = await _db.Orders
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .ToListAsync();

            var ordersByDayAmount = orders
                .GroupBy(o => o.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));
            var ordersByDayCount = orders
                .GroupBy(o => o.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Count());


            var currentRevenue = ordersByDayAmount.ContainsKey(now) ? ordersByDayAmount[now] : 0;
            var previousRevenue = ordersByDayAmount.ContainsKey(yesterday) ? ordersByDayAmount[yesterday] : 0;

            var currentCount = ordersByDayCount.ContainsKey(now) ? ordersByDayCount[now] : 0;
            var previousCount = ordersByDayCount.ContainsKey(yesterday) ? ordersByDayCount[yesterday] : 0;

            var currentAvg = currentCount == 0 ? 0 : currentRevenue / currentCount;
            var previousAvg = previousCount == 0 ? 0 : previousRevenue / previousCount;

            var summary = new SummaryDto
            {
                Revenue = MetricCompareDto.Build(currentRevenue, previousRevenue),
                Orders = MetricCompareDto.Build(currentCount, previousCount),
                AvgOrderValue = MetricCompareDto.Build(currentAvg, previousAvg)
            };

            var revenueChart = new LineChartDto
            {
                Labels = currentDays.Zip(previousDays, (cur, prev) => $"{cur:dd MMM}/{prev:dd MMM}").ToList(),
                Current = currentDays.Select(d => ordersByDayAmount.ContainsKey(d) ? ordersByDayAmount[d] : 0).ToList(),
                Previous = previousDays.Select(d => ordersByDayAmount.ContainsKey(d) ? ordersByDayAmount[d] : 0).ToList()
            };

            var orderChart = new BarChartDto
            {
                Labels = currentDays.Select(d => d.ToString("dd MMM")).ToList(),
                Values = currentDays.Select(d => ordersByDayCount.ContainsKey(d) ? ordersByDayCount[d] : 0).ToList()
            };

            var data = await _db.OrderItems
                .Where(oi => oi.CreatedAt >= now.Date && oi.CreatedAt <= now.Date.AddDays(1).AddTicks(-1)) 
                .Join(_db.Menus,
                    oi => oi.MenuId,
                    m => m.Id,
                    (oi, m) => new { oi, m.Name })
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Quantity = g.Sum(x => x.oi.Quantity)
                })
                .ToListAsync();

            var total = data.Sum(x => x.Quantity);

            var topProducts = data.OrderByDescending(x => x.Quantity)
                .Take(5)
                .Select((x, index) => new ProductStatDto
                {
                    Rank = index + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = total == 0 ? 0 : Math.Round((double)x.Quantity / total * 100, 2)
                })
                .ToList();
            var bottomProducts = data.OrderBy(x => x.Quantity)
                .Take(5)
                .Select((x, index) => new ProductStatDto
                {
                    Rank = index + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = total == 0 ? 0 : Math.Round((double)x.Quantity / total * 100, 2)
                })
                .ToList();

            return new ReportResponse
            {
                Summary = summary,
                RevenueChart = revenueChart,
                OrderChart = orderChart,
                TopProducts = topProducts,
                BottomProducts = bottomProducts
            };
        }

        public async Task<ReportResponse> BuildReportWeekAsync(ReportFilter filter)
        {
            await using var _db = _dbFactory.CreateDbContext();
            var today = DateTime.Now.Date;
            var isoDayOfWeek = (int)today.DayOfWeek == 0 ? 7 : (int)today.DayOfWeek; // Sunday = 7
            var startOfThisWeek = today.AddDays(-isoDayOfWeek + 1); // Monday
            var endOfThisWeek = startOfThisWeek.AddDays(7).AddTicks(-1);

            int weeks = 7;

            // --- Current weeks (7 tuần gần nhất)
            var currentWeeks = Enumerable.Range(0, weeks)
                .Select(i => startOfThisWeek.AddDays(-7 * i))
                .Reverse()
                .ToList();

            // --- Previous weeks (7 tuần trước 7 tuần hiện tại)
            var previousWeeks = currentWeeks.Select(d => d.AddDays(-7 * weeks)).ToList();

            // --- Lấy orders trong 14 tuần
            var startDate = previousWeeks.First();
            var endDate = endOfThisWeek;

            var orders = await _db.Orders
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .ToListAsync();

            // --- Tổng doanh thu và số đơn theo tuần
            var ordersByWeekAmount = orders
                .GroupBy(o => {
                    var isoDow = (int)o.CreatedAt.DayOfWeek == 0 ? 7 : (int)o.CreatedAt.DayOfWeek;
                    return o.CreatedAt.Date.AddDays(-isoDow + 1); // map to Monday of that week
                })
                .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));

            var ordersByWeekCount = orders
                .GroupBy(o => {
                    var isoDow = (int)o.CreatedAt.DayOfWeek == 0 ? 7 : (int)o.CreatedAt.DayOfWeek;
                    return o.CreatedAt.Date.AddDays(-isoDow + 1);
                })
                .ToDictionary(g => g.Key, g => g.Count());

            // --- Summary KPI tuần này vs tuần trước
            var currentRevenue = ordersByWeekAmount.Select(kv => kv.Value).Last();

            var previousRevenue = ordersByWeekAmount
                .Select(kv => kv.Value).Skip(ordersByWeekAmount.Count - 2).First();

            var currentCount = ordersByWeekCount
                .Select(kv => kv.Value).Last();

            var previousCount = ordersByWeekCount
                .Select(kv => kv.Value).Skip(ordersByWeekAmount.Count - 2).First();

            var currentAvg = currentCount == 0 ? 0 : currentRevenue / currentCount;
            var previousAvg = previousCount == 0 ? 0 : previousRevenue / previousCount;

            var summary = new SummaryDto
            {
                Revenue = MetricCompareDto.Build(currentRevenue, previousRevenue),
                Orders = MetricCompareDto.Build(currentCount, previousCount),
                AvgOrderValue = MetricCompareDto.Build(currentAvg, previousAvg)
            };

            // --- Revenue line chart 7 tuần current vs 7 tuần previous
            var revenueChart = new LineChartDto
            {
                Labels = currentWeeks.Zip(previousWeeks, (cur, prev) => $"{cur:dd MMM}/{prev:dd MMM}").ToList(),
                Current = currentWeeks.Select(d => ordersByWeekAmount.ContainsKey(d) ? ordersByWeekAmount[d] : 0).ToList(),
                Previous = previousWeeks.Select(d => ordersByWeekAmount.ContainsKey(d) ? ordersByWeekAmount[d] : 0).ToList()
            };

            // --- Order bar chart 7 tuần hiện tại
            var orderChart = new BarChartDto
            {
                Labels = currentWeeks.Select(d => d.ToString("dd MMM")).ToList(),
                Values = currentWeeks.Select(d => ordersByWeekCount.ContainsKey(d) ? ordersByWeekCount[d] : 0).ToList()
            };

            // --- Top / Bottom products trong tuần hiện tại
            var weekOrdersStart = currentWeeks.Last();
            var weekOrdersEnd = endOfThisWeek;

            var productData = await _db.OrderItems
                .Where(oi => oi.CreatedAt >= weekOrdersStart && oi.CreatedAt <= weekOrdersEnd)
                .Join(_db.Menus,
                    oi => oi.MenuId,
                    m => m.Id,
                    (oi, m) => new { oi, m.Name })
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Quantity = g.Sum(x => x.oi.Quantity)
                })
                .ToListAsync();

            var totalQty = productData.Sum(x => x.Quantity);

            var topProducts = productData.OrderByDescending(x => x.Quantity)
                .Take(5)
                .Select((x, i) => new ProductStatDto
                {
                    Rank = i + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = totalQty == 0 ? 0 : Math.Round((double)x.Quantity / totalQty * 100, 2)
                }).ToList();

            var bottomProducts = productData.OrderBy(x => x.Quantity)
                .Take(5)
                .Select((x, i) => new ProductStatDto
                {
                    Rank = i + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = totalQty == 0 ? 0 : Math.Round((double)x.Quantity / totalQty * 100, 2)
                }).ToList();

            return new ReportResponse
            {
                Summary = summary,
                RevenueChart = revenueChart,
                OrderChart = orderChart,
                TopProducts = topProducts,
                BottomProducts = bottomProducts
            };
        }

        public async Task<ReportResponse> BuildReportMonthAsync(ReportFilter filter)
        {
            await using var _db = _dbFactory.CreateDbContext();
            var today = DateTime.Now.Date;
            var startOfThisMonth = new DateTime(today.Year, today.Month, 1);
            var startOfPreviousMonth = startOfThisMonth.AddMonths(-1);

            var endOfThisMonth = startOfThisMonth.AddMonths(1).AddTicks(-1);

            int months = 8;

            // --- Current 8 months (tính từ tháng hiện tại lùi về trước)
            var currentMonths = Enumerable.Range(0, months)
                .Select(i => startOfThisMonth.AddMonths(-i))
                .Reverse()
                .ToList();

            // --- Previous 8 months trước 8 tháng hiện tại
            var previousMonths = currentMonths.Select(m => m.AddMonths(-months)).ToList();

            // --- Lấy orders trong 16 tháng
            var startDate = previousMonths.First();
            var endDate = endOfThisMonth;

            var orders = await _db.Orders
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .ToListAsync();

            // --- Tổng doanh thu và số đơn theo tháng
            var ordersByMonthAmount = orders
                .GroupBy(o => new DateTime(o.CreatedAt.Year, o.CreatedAt.Month, 1))
                .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));

            var ordersByMonthCount = orders
                .GroupBy(o => new DateTime(o.CreatedAt.Year, o.CreatedAt.Month, 1))
                .ToDictionary(g => g.Key, g => g.Count());

            var currentRevenue = ordersByMonthAmount.ContainsKey(startOfThisMonth)
    ? ordersByMonthAmount[startOfThisMonth]
    : 0;

            var previousRevenue = ordersByMonthAmount.ContainsKey(startOfPreviousMonth)
                ? ordersByMonthAmount[startOfPreviousMonth]
                : 0;

            var currentCount = ordersByMonthCount.ContainsKey(startOfThisMonth)
                ? ordersByMonthCount[startOfThisMonth]
                : 0;

            var previousCount = ordersByMonthCount.ContainsKey(startOfPreviousMonth)
                ? ordersByMonthCount[startOfPreviousMonth]
                : 0;

            var currentAvg = currentCount == 0 ? 0 : currentRevenue / currentCount;
            var previousAvg = previousCount == 0 ? 0 : previousRevenue / previousCount;

            var summary = new SummaryDto
            {
                Revenue = MetricCompareDto.Build(currentRevenue, previousRevenue),
                Orders = MetricCompareDto.Build(currentCount, previousCount),
                AvgOrderValue = MetricCompareDto.Build(currentAvg, previousAvg)
            };

            // --- Revenue line chart 8 months current vs 8 months previous
            var revenueChart = new LineChartDto
            {
                Labels = currentMonths.Zip(previousMonths, (cur, prev) => $"{cur:MMM yyyy}/{prev:MMM yyyy}").ToList(),
                Current = currentMonths.Select(m => ordersByMonthAmount.ContainsKey(m) ? ordersByMonthAmount[m] : 0).ToList(),
                Previous = previousMonths.Select(m => ordersByMonthAmount.ContainsKey(m) ? ordersByMonthAmount[m] : 0).ToList()
            };

            // --- Order bar chart 8 months current
            var orderChart = new BarChartDto
            {
                Labels = currentMonths.Select(m => m.ToString("MMM yyyy")).ToList(),
                Values = currentMonths.Select(m => ordersByMonthCount.ContainsKey(m) ? ordersByMonthCount[m] : 0).ToList()
            };

            // --- Top / Bottom products trong tháng hiện tại
            var productData = await _db.OrderItems
                .Where(oi => oi.CreatedAt >= startOfThisMonth && oi.CreatedAt <= endOfThisMonth)
                .Join(_db.Menus,
                    oi => oi.MenuId,
                    m => m.Id,
                    (oi, m) => new { oi, m.Name })
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Quantity = g.Sum(x => x.oi.Quantity)
                })
                .ToListAsync();

            var totalQty = productData.Sum(x => x.Quantity);

            var topProducts = productData.OrderByDescending(x => x.Quantity)
                .Take(5)
                .Select((x, i) => new ProductStatDto
                {
                    Rank = i + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = totalQty == 0 ? 0 : Math.Round((double)x.Quantity / totalQty * 100, 2)
                }).ToList();

            var bottomProducts = productData.OrderBy(x => x.Quantity)
                .Take(5)
                .Select((x, i) => new ProductStatDto
                {
                    Rank = i + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = totalQty == 0 ? 0 : Math.Round((double)x.Quantity / totalQty * 100, 2)
                }).ToList();

            return new ReportResponse
            {
                Summary = summary,
                RevenueChart = revenueChart,
                OrderChart = orderChart,
                TopProducts = topProducts,
                BottomProducts = bottomProducts
            };
        }

        public async Task<ReportResponse> BuildReportAsync(ReportFilter filter)
        {
            var summary = await BuildSummary(filter);
            var revenueChart = await BuildRevenueChart(filter);
            var orderChart = await BuildOrderChart(filter);
            var topProducts = await ProductStats(true);
            var bottomProducts = await ProductStats(false);

            return new ReportResponse
            {
                Summary = summary,
                RevenueChart = revenueChart,
                OrderChart = orderChart,
                TopProducts = topProducts,
                BottomProducts = bottomProducts
            };
        }

        private async Task<SummaryDto> BuildSummary(ReportFilter filter)
        {
            await using var _db = _dbFactory.CreateDbContext();
            var range = filter.To - filter.From;

            var prevFrom = filter.From - range;
            var prevTo = filter.From;

            var currentOrders = _db.Orders
                .Where(o => o.CreatedAt >= filter.From &&
                            o.CreatedAt <= filter.To);

            var previousOrders = _db.Orders
                .Where(o => o.CreatedAt >= prevFrom &&
                            o.CreatedAt < prevTo);

            // ---- CURRENT
            var currentRevenue = await currentOrders.SumAsync(x => x.TotalAmount);
            var currentCount = await currentOrders.CountAsync();
            var currentAvg = currentCount == 0 ? 0 : currentRevenue / currentCount;

            // ---- PREVIOUS
            var prevRevenue = await previousOrders.SumAsync(x => x.TotalAmount);
            var prevCount = await previousOrders.CountAsync();
            var prevAvg = prevCount == 0 ? 0 : prevRevenue / prevCount;

            return new SummaryDto
            {
                Revenue = BuildMetric(currentRevenue, prevRevenue),
                Orders = BuildMetric(currentCount, prevCount),
                AvgOrderValue = BuildMetric(currentAvg, prevAvg)
            };
        }



        private async Task<LineChartDto> BuildRevenueChart(ReportFilter filter)
        {
            var currentData = await AggregateRevenueByGranularity(filter.From, filter.To, filter.Granularity);
            var range = filter.To - filter.From;
            var previousData = await AggregateRevenueByGranularity(filter.From - range, filter.From, filter.Granularity);

            var labels = new List<string>();
            var current = new List<decimal>();
            var previous = new List<decimal>();

            switch (filter.Granularity)
            {
                case ReportGranularity.Day:
                    for (var date = filter.From.Date; date <= filter.To.Date; date = date.AddDays(1))
                    {
                        labels.Add(date.ToString("dd/MM"));
                        current.Add(currentData.TryGetValue(date, out var c) ? c : 0);
                        previous.Add(previousData.TryGetValue(date, out var p) ? p : 0);
                    }
                    break;

                case ReportGranularity.Week:
                    var startWeek = ISOWeek.GetWeekOfYear(filter.From);
                    var endWeek = ISOWeek.GetWeekOfYear(filter.To);
                    var year = filter.From.Year;
                    for (int w = startWeek; w <= endWeek; w++)
                    {
                        labels.Add($"W{w}/{year}");
                        current.Add(currentData.TryGetValue((year, w), out var c) ? c : 0);
                        previous.Add(previousData.TryGetValue((year, w), out var p) ? p : 0);
                    }
                    break;

                case ReportGranularity.Month:
                    for (var date = new DateTime(filter.From.Year, filter.From.Month, 1);
                         date <= filter.To;
                         date = date.AddMonths(1))
                    {
                        labels.Add(date.ToString("MM/yyyy"));
                        current.Add(currentData.TryGetValue((date.Year, date.Month), out var c) ? c : 0);
                        previous.Add(previousData.TryGetValue((date.Year, date.Month), out var p) ? p : 0);
                    }
                    break;

            }

            return new LineChartDto
            {
                Labels = labels,
                Current = current,
                Previous = previous
            };
        }

        private async Task<Dictionary<object, decimal>> AggregateRevenueByGranularity(
            DateTime from,
            DateTime to,
            ReportGranularity granularity)
        {
            await using var _db = _dbFactory.CreateDbContext();
            switch (granularity)
            {
                case ReportGranularity.Day:
                    var daily = await _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt < to.AddDays(1))
                        .GroupBy(o => o.CreatedAt.Date)
                        .Select(g => new { Date = g.Key, Total = g.Sum(x => x.TotalAmount) })
                        .ToListAsync();
                    return daily.ToDictionary(x => (object)x.Date, x => x.Total);

                case ReportGranularity.Week:
                    var ordersByWeek = _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt < to.AddDays(1))
                        .Select(o => new { o.CreatedAt, o.TotalAmount })
                        .ToList();

                    // Group bằng ISOWeek
                    var weekly = ordersByWeek
                        .GroupBy(o => (o.CreatedAt.Year, ISOWeek.GetWeekOfYear(o.CreatedAt)))
                        .Select(g => new { Key = g.Key, Total = g.Sum(x => x.TotalAmount) })
                        .ToList();

                    return weekly.ToDictionary(x => (object)x.Key, x => x.Total);

                case ReportGranularity.Month:
                    var orders = await _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt < to.AddDays(1))
                        .Select(o => new { o.CreatedAt, o.TotalAmount })
                        .ToListAsync();

                    var monthly = orders
                        .GroupBy(o => (o.CreatedAt.Year, o.CreatedAt.Month))
                        .Select(g => new { Key = g.Key, Total = g.Sum(x => x.TotalAmount) })
                        .ToList();

                    return monthly.ToDictionary(x => (object)x.Key, x => x.Total);

                default:
                    return new Dictionary<object, decimal>();
            }
        }

        private async Task<Dictionary<DateTime, decimal>> DailyRevenue(
            DateTime from,
            DateTime to)
        {
            await using var _db = _dbFactory.CreateDbContext();
            from = from.Date;
            to = to.Date;

            var data = await _db.Orders
                .Where(o => o.CreatedAt >= from &&
                            o.CreatedAt < to.AddDays(1))
                .GroupBy(o => new
                {
                    o.CreatedAt.Year,
                    o.CreatedAt.Month,
                    o.CreatedAt.Day
                })
                .Select(g => new
                {
                    Date = new DateTime(
                        g.Key.Year,
                        g.Key.Month,
                        g.Key.Day),
                    Total = g.Sum(x => x.TotalAmount)
                })
                .ToListAsync();

            return data.ToDictionary(x => x.Date, x => x.Total);
        }

        private async Task<BarChartDto> BuildOrderChart(ReportFilter filter)
        {
            var dataDict = await AggregateOrdersByGranularity(filter.From, filter.To, filter.Granularity);

            var labels = new List<string>();
            var values = new List<int>();

            switch (filter.Granularity)
            {
                case ReportGranularity.Day:
                    for (var date = filter.From.Date; date <= filter.To.Date; date = date.AddDays(1))
                    {
                        labels.Add(date.ToString("dd/MM"));
                        values.Add(dataDict.TryGetValue(date, out var v) ? v : 0);
                    }
                    break;

                case ReportGranularity.Week:
                    var startWeek = ISOWeek.GetWeekOfYear(filter.From);
                    var endWeek = ISOWeek.GetWeekOfYear(filter.To);
                    var year = filter.From.Year;
                    for (int w = startWeek; w <= endWeek; w++)
                    {
                        labels.Add($"W{w}/{year}");
                        values.Add(dataDict.TryGetValue((year, w), out var v) ? v : 0);
                    }
                    break;

                case ReportGranularity.Month:
                    for (var date = new DateTime(filter.From.Year, filter.From.Month, 1);
                         date <= filter.To;
                         date = date.AddMonths(1))
                    {
                        labels.Add(date.ToString("MM/yyyy"));
                        values.Add(dataDict.TryGetValue((date.Year, date.Month), out var v) ? v : 0);
                    }
                    break;

            }

            return new BarChartDto
            {
                Labels = labels,
                Values = values
            };
        }

        private async Task<Dictionary<object, int>> AggregateOrdersByGranularity(
    DateTime from,
    DateTime to,
    ReportGranularity granularity)
        {
            await using var _db = _dbFactory.CreateDbContext();
            switch (granularity)
            {
                case ReportGranularity.Day:
                    var daily = await _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt <= to)
                        .GroupBy(o => o.CreatedAt.Date)
                        .Select(g => new { Date = g.Key, Count = g.Count() })
                        .ToListAsync();
                    return daily.ToDictionary(x => (object)x.Date, x => x.Count);

                case ReportGranularity.Week:
                    // materialize data trước rồi group trong memory
                    var weekData = await _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt <= to)
                        .Select(o => new { o.CreatedAt })
                        .ToListAsync();

                    var weekly = weekData
                        .GroupBy(o => (o.CreatedAt.Year, ISOWeek.GetWeekOfYear(o.CreatedAt)))
                        .Select(g => new { Key = g.Key, Count = g.Count() })
                        .ToDictionary(x => (object)x.Key, x => x.Count);

                    return weekly;

                case ReportGranularity.Month:
                    var monthData = await _db.Orders
                        .Where(o => o.CreatedAt >= from && o.CreatedAt <= to)
                        .Select(o => new { o.CreatedAt })
                        .ToListAsync();

                    var monthly = monthData
                        .GroupBy(o => (o.CreatedAt.Year, o.CreatedAt.Month))
                        .Select(g => new { Key = g.Key, Count = g.Count() })
                        .ToDictionary(x => (object)x.Key, x => x.Count);

                    return monthly;



                default:
                    return new Dictionary<object, int>();
            }
        }

        private async Task<List<ProductStatDto>> ProductStats(
            bool top)
        {
            await using var _db = _dbFactory.CreateDbContext();
            var data = await _db.OrderItems
                .Join(_db.Menus,
                    oi => oi.MenuId,
                    m => m.Id,
                    (oi, m) => new { oi, m })
                .GroupBy(x => x.m.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Quantity = g.Sum(x => x.oi.Quantity)
                })
                .ToListAsync();

            var total = data.Sum(x => x.Quantity);

            var ordered = top
                ? data.OrderByDescending(x => x.Quantity)
                : data.OrderBy(x => x.Quantity);

            return ordered
                .Take(5)
                .Select((x, index) => new ProductStatDto
                {
                    Rank = index + 1,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Percent = total == 0
                        ? 0
                        : (double)x.Quantity / total * 100
                })
                .ToList();
        }


        private static MetricCompareDto BuildMetric(decimal current, decimal previous)
        {
            decimal percent = previous == 0 ? 0 : ((current - previous) / previous) * 100;

            return new MetricCompareDto
            {
                Current = current,
                Previous = previous,
                PercentChange = percent
            };
        }

    }
}
