using LiteDB;
using System.Text.RegularExpressions;

namespace ReaderInHTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Loginfo> li = new List<Loginfo>();
            var qq = "d:\\log\\changelog";
            for (int ii = 2016; ii <= 2025; ii++)
            {
                var t = File.ReadAllText(qq + ii + ".htm");
                var c = t.Split(new string[] { "<table>", "</table>" }, StringSplitOptions.None)[1];
                c = c.Replace("\r", "").Replace("\t", "").Replace("\n", "").Replace("<span>", "").Replace("<span >", "").Replace("</span>", "").Replace("</span >", "");
                c = c.Replace("<br>", "\r\n");
                var k = c.Split(new string[] { "<tr>", "</tr>" }, StringSplitOptions.TrimEntries).Where(ex => ex.Length > 10).ToList();
                k.RemoveAt(0);
                foreach (var item in k)
                {
                    var pp = item.Split(new string[] { "</td>" }, StringSplitOptions.None).ToList();
                    if (pp.Count == 3)
                    {
                        li.Add(new Loginfo()
                        {
                            Updatetime = Regex.Replace(pp[0], "<.*?>", string.Empty),
                            Content = Regex.Replace(pp[1], "<.*?>", string.Empty),
                            Files = Regex.Replace(pp[2], "<.*?>", string.Empty),

                        });
                    }
                    else
                    {
                        li.Add(new Loginfo()
                        {
                            Updatetime = Regex.Replace(pp[0], "<.*?>", string.Empty),
                            Content = Regex.Replace(pp[1], "<.*?>", string.Empty),
                            Files = "",

                        });
                    }
                }

            }
            var o = new LiteDatabase("NoSQLData.db");
            foreach (var item in li)
            {
                item.Guid = Guid.NewGuid().ToString();
                o.GetCollection<Loginfo>("logs").Insert(item);
            }
        }
    }
    public class Loginfo
    {
        public string Guid { get; set; }
        public string Updatetime { get; set; }
        public string Content { get; set; }
        public string Files { get; set; }
    }
}
