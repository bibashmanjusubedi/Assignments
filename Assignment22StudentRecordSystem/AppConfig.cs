using System.IO;
using System.Text.Json;

namespace Assignment22StudentRecordSystem
{
    public class AppConfig
    {
        public string CsvFilePath { get; set; } = @"E:\\AmnilTechnologies\\Files\\students.csv";

        public static AppConfig LoadConfig(string path = "config.json")
        {
            if (!File.Exists(path))
            {
                var defaultConfig = new AppConfig();
                string defaultJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, defaultJson);
                return defaultConfig;
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
        }

        public void Save(string path = "config.json")
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
