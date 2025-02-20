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

                var closePrices = ohlcData.Select(x => (decimal) x[4]).ToList();
                var highPrices = ohlcData.Select(x => (decimal) x[2]).ToList();
                var lowPrices = ohlcData.Select(x => (decimal) x[3]).ToList();
                var timestamps = ohlcData.Select(x => (long) x[0]).ToList();

                // 計算 KD 指標
                var kdData = CalculateKD(closePrices, highPrices, lowPrices, timestamps);

                // 計算 MACD 指標
                var macdData = CalculateMACD(closePrices, timestamps);

                return new
                {
                    stockInfo = new
                    {
                        code = stockInfo.stock_code,
                        name = stockInfo.stock_name,
                    },
                    ohlc = ohlcData.OrderBy(x => x[0]),
                    volume = volumeData.OrderBy(x => x[0]),
                    kd = kdData.OrderBy(x => x[0]),
                    macd = macdData.OrderBy(x => x[0])
                };
            }
        }

        // KD (Stochastic) 指標計算，適用於 Highcharts
        private List<object[]> CalculateKD(List<decimal> closePrices, List<decimal> highPrices, List<decimal> lowPrices, List<long> timestamps)
        {
            int period = 14; // Stochastic 常用的週期
            decimal k = 50m, d = 50m; // 初始 %K 和 %D 設為 50
            List<object[]> kdData = new();

            for ( int i = 0; i < closePrices.Count; i++ )
            {
                if ( i < period - 1 )
                {
                    kdData.Add(new object[] { timestamps[i], null, null });
                    continue;
                }

                // 取最近 period 天的最高價與最低價，確保不會越界
                int startIndex = Math.Max(0, i - (period - 1));
                var highN = highPrices.Skip(startIndex).Take(period).Max();
                var lowN = lowPrices.Skip(startIndex).Take(period).Min();

                // 避免分母為 0
                decimal rsv = (highN == lowN) ? 50m : (closePrices[i] - lowN) / (highN - lowN) * 100m;

                k = k * 2 / 3 + rsv / 3; // 計算 %K
                d = d * 2 / 3 + k / 3;   // 計算 %D

                kdData.Add(new object[] { timestamps[i], Math.Round(k, 2), Math.Round(d, 2) });
            }

            return kdData;
        }



        // MACD 指標計算
        private List<object[]> CalculateMACD(List<decimal> closePrices, List<long> timestamps)
        {
            int shortPeriod = 12, longPeriod = 26, signalPeriod = 9;
            List<object[]> macdData = new();

            List<decimal?> emaShort = CalculateEMA(closePrices, shortPeriod);
            List<decimal?> emaLong = CalculateEMA(closePrices, longPeriod);

            // 計算 MACD Line
            List<decimal?> macdLine = emaShort.Zip(emaLong, (shortEMA, longEMA) =>
                (shortEMA.HasValue && longEMA.HasValue) ? shortEMA - longEMA : (decimal?) null
            ).ToList();

            // 計算 Signal Line
            List<decimal?> signalLine = CalculateEMA(macdLine.Where(x => x.HasValue).Cast<decimal>().ToList(), signalPeriod);

            // 計算 Histogram
            List<decimal?> histogram = macdLine.Zip(signalLine, (macd, signal) =>
                (macd.HasValue && signal.HasValue) ? macd - signal : (decimal?) null
            ).ToList();

            for ( int i = 0; i < macdLine.Count; i++ )
            {
                macdData.Add(new object[] { timestamps[i], macdLine[i], signalLine.ElementAtOrDefault(i), histogram.ElementAtOrDefault(i) });
            }

            return macdData;
        }


        // 計算 EMA (Exponential Moving Average)
        private List<decimal?> CalculateEMA(List<decimal> prices, int period)
        {
            List<decimal?> emaList = new();
            decimal multiplier = 2m / (period + 1);

            // 若數據不足，無法計算 EMA，則全部填 null
            if ( prices.Count < period )
            {
                return prices.Select(_ => (decimal?) null).ToList();
            }

            // 計算第一個 EMA，使用前 period 筆的平均值
            decimal ema = prices.Take(period).Average();

            // 前面 (period - 1) 天填入 null，確保對齊時間戳記
            for ( int i = 0; i < period - 1; i++ )
            {
                emaList.Add(null);
            }

            emaList.Add(ema);

            // 開始計算後續 EMA
            for ( int i = period; i < prices.Count; i++ )
            {
                ema = (prices[i] - ema) * multiplier + ema;
                emaList.Add(ema);
            }

            return emaList;
        }
    }
}
