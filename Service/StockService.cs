using HighChartpratice.Models;
using System.Text.Json;

namespace HighChartpratice.Service
{
    public interface IStockService
    {
        Task<StockInfo> ReadStockDataAsync(string filePath);
    }

    // Services/StockService.cs
    public class StockService : IStockService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StockService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<StockInfo> ReadStockDataAsync(string fileName)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string dataDirectory = Path.Combine(webRootPath, "data");
            string fullPath = Path.Combine(dataDirectory, fileName);

            if ( !Directory.Exists(dataDirectory) )
            {
                throw new DirectoryNotFoundException($"找不到資料目錄：{dataDirectory}");
            }

            string jsonContent = await File.ReadAllTextAsync(fullPath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            };

            var result = JsonSerializer.Deserialize<StockInfo>(jsonContent, options);

            return result;
        }
    }
}
