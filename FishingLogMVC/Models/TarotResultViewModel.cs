namespace FishingLogMVC.Models
{
    public class TarotCardResult
    {
        public int CardIndex { get; set; }
        public string LocalizedName { get; set; } = string.Empty;
        public string BaseName { get; set; } = string.Empty;
        public string DomainKey { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsReversed { get; set; }
        public string ImagePath => $"/img/{CardIndex}.jpg";
    }
}

