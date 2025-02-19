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
        public async Task<IActionResult> GetStockData()
        {
            var stockInfo = await _stockService.ReadStockDataAsync(STOCK_FILE_NAME);
            var processedData = ProcessStockData(stockInfo);
            return Ok(processedData);

            object ProcessStockData(StockInfo stockInfo)
            {
                var ohlcData = new List<object[]>();
                var volumeData = new List<object[]>();

                foreach ( var day in stockInfo.dayMkDataList.OrderBy(x => x.mdate) )
                {
                    var dateTime = DateTime.ParseExact(day.mdate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    var timestamp = new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();

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
                    ohlc = ohlcData,
                    volume = volumeData
                };
            }
        }
    }
}
