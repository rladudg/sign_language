using System.IO;
using System.Text.Json;

namespace WinFormsApp1
{
    public class AppConfig
    {
        public string ServerIP { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 9000;
        public int HoldTime { get; set; } = 30;
        public int CameraIndex { get; set; } = 0;

        private static string FilePath = "config.json";

        public static AppConfig Load()
        {
            if (!File.Exists(FilePath)) return new AppConfig();
            return JsonSerializer.Deserialize<AppConfig>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}