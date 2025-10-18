namespace FishingLogMVC.Models
{
    public class TransInfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Lan { get; set; }
    }
    public class TransInfos
    {
        public static void Init()
        {
            string savePath = Path.Combine(AppContext.BaseDirectory, "Dictionary.json");
            var k = File.ReadAllText(savePath);
            Dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TransInfo>>(k)!;
        }
        public static List<TransInfo> Dictionary { get; set; } = [];
    }
}
