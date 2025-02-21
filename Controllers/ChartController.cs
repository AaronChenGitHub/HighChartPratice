using HighChartpratice.Models;
using HighChartpratice.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace HighChartpratice.Controllers
{
    public class ChartController :Controller
    {
        private readonly IStockService _stockService;
        private const string STOCK_FILE_NAME = "2330.txt";

        public ChartController(IStockService stockService)
        {
            _stockService = stockService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetStockDataAsync()
        {
            var stockInfo = await _stockService.ReadStockDataAsync(STOCK_FILE_NAME);
            var processedData = ProcessStockData(stockInfo);
            return Ok(processedData);

            object ProcessStockData(StockInfo stockInfo)
            {
                var ohlcData = new List<object[]>();
                var volumeData = new List<object[]>();

                // 使用台灣時區
                TimeZoneInfo taipeiZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Taipei");

                foreach ( var day in stockInfo.dayMkDataList.OrderBy(x => x.mdate) )
                {
                    // 使用 InvariantCulture 而不是 taiwanese culture
                    var dateTime = DateTime.ParseExact(day.mdate, "yyyyMMdd", CultureInfo.InvariantCulture);

                    // 確保日期是台灣時間的凌晨零點
                    var taipeiTime = TimeZoneInfo.ConvertTime(dateTime, taipeiZone);
                    taipeiTime = taipeiTime.Date; // 設為凌晨零點

                    // 轉換為 UTC 時間戳
                    var timestamp = new DateTimeOffset(taipeiTime, taipeiZone.GetUtcOffset(taipeiTime))
                        .ToUnixTimeMilliseconds();

                    if ( decimal.TryParse(day.open_d, out decimal open) &&
                        decimal.TryParse(day.high_d, out decimal high) &&
                        decimal.TryParse(day.low_d, out decimal low) &&
                        decimal.TryParse(day.close_d, out decimal close) &&
                        long.TryParse(day.volume, out long volume) )
                    {
                        ohlcData.Add(new object[] { timestamp, open, high, low, close });
                        volumeData.Add(new object[] { timestamp, volume });
                    }
                }

                return new
                {
                    stockInfo = new
                    {
                        code = stockInfo.stock_code,
                        name = stockInfo.stock_name,
                    },
                    ohlc = ohlcData.OrderBy(x => x[0]),
                    volume = volumeData.OrderBy(x => x[0]),
                };
            }
        }
    }
}
