namespace FishingLogMVC.Models
{
    public class TarotText
    {
 
        public string name { get; set; }
        public Upright upright { get; set; }
        public Reversed reversed { get; set; }
    }

    public class Upright
    {
        public string text { get; set; }
        public int emotion { get; set; }
        public Domains domains { get; set; }
    }

    public class Domains
    {
        public string career { get; set; }
        public string love { get; set; }
        public string health { get; set; }
        public string mind { get; set; }
    }

    public class Reversed
    {
        public string text { get; set; }
        public int emotion { get; set; }
        public Domains1 domains { get; set; }
    }

    public class Domains1
    {
        public string career { get; set; }
        public string love { get; set; }
        public string health { get; set; }
        public string mind { get; set; }
    }

}
