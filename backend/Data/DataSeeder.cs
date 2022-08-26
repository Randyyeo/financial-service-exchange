using System.Text.Json;

namespace rainbow_unicorn.Data;

public class DataSeeder
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _env;

    public DataSeeder(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    
    // private method for Seeder Methods to get the data according to the specified model
    private string GetData(string modelName)
    {
        string rootPath = _env.ContentRootPath;
        string fileName = modelName + ".json";
        string filePath = Path.GetFullPath(Path.Combine(rootPath, "Data", "JsonFiles", fileName));
        using (var r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            return json;
        }
    }
    
    // Seeder Methods for each model

    public void SeedStocks()
    {
        string data = GetData("Stocks");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            float currentClose = float.Parse(item["CurrentClose"]);
            DateTime lastUpdated = DateTime.Parse(item["LastUpdated"]);
            var s = new Stock(item["Ticker"], currentClose, lastUpdated, item["Currency"]);
            _db.Stocks.Add(s);
            _db.SaveChanges();
        }
    }
}