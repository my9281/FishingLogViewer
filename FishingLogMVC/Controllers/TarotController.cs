using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FishingLogMVC.Controllers
{
    public class TarotController : Controller
    {
        private static readonly FishingLog.BLL.user _u = new FishingLog.BLL.user();
        private readonly WebSocketConnectionManager _wsManager;
        private readonly INoSQLDB<TarotController> _db;
        private readonly ICookiesService<TarotController> _cookies;

        public TarotController(INoSQLDB<TarotController> db, ICookiesService<TarotController> cookies, WebSocketConnectionManager wsManager)
        {
            _wsManager = wsManager;
            _db = db;
            _cookies = cookies;
        }
        public IActionResult Index()
        {
            List<string> majorArcana = new List<string> { "愚者", "魔术师", "女祭司", "女皇", "皇帝", "教皇", "恋人", "战车", "力量", "隐者", "命运之轮", "正义", "倒吊人", "死神", "节制", "恶魔", "塔", "星星", "月亮", "太阳", "审判", "世界" };
            List<int> mint = new List<int>();
            for (int i = 0; i < 22; i++)
            {
                mint.Add(i);
            }
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Redirect("/Users/Login");
            }
            var VModel = _u.GetModel(userId);
            ViewBag.Model = VModel;

            TarptModel m = new TarptModel();
            m.Salt = "Thomas_Magic_Chen";
            m.Name = VModel.nickname;
            m.TestTime = DateTime.Now.ToString("yyyy-MM-dd");
            m.Localtion = VModel.location ?? "";
            m.BirthDay = VModel.birthday.ToString("yyyy-MM-dd");
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(m));
                byte[] hashBytes = sha512.ComputeHash(bytes);
                BigInteger bigInt = new BigInteger(hashBytes, isUnsigned: true, isBigEndian: true);
                long mod = 2808960;
                long result = (long)(bigInt % mod);
                bool isutd0, isutd1, isutd2, isutd3 = false;
                int v0 = (int)(result % 44);
                var vv0 = (int)(result / 44);

                int v1 = (int)(vv0 % 42);
                var vv1 = (int)(vv0 / 42);

                int v2 = (int)(vv1 % 40);
                var vv2 = (int)(vv1 / 40);

                int v3 = (int)(vv2 % 38);

                isutd0 = v0 % 2 == 1;
                isutd1 = v1 % 2 == 1;
                isutd2 = v2 % 2 == 1;
                isutd3 = v3 % 2 == 1;
                List<string> li = new List<string>();
                int currentIndex = 0; // 初始从第0位开始
                List<int> s = new List<int>() { v0 / 2, v1 / 2, v2 / 2, v3 / 2 };
                List<int> re = new List<int>();
                foreach (int i in s)
                {
                    if (majorArcana.Count == 0)
                        break;
                    currentIndex = (currentIndex + i - 1) % majorArcana.Count;

                    string selected = majorArcana[currentIndex];
                    var p = mint[currentIndex];
                    re.Add(p);
                    li.Add(selected);
                    majorArcana.RemoveAt(currentIndex);
                    mint.RemoveAt(currentIndex);
                    if (currentIndex >= majorArcana.Count)
                    {
                        currentIndex = 0;
                    }
                }


                ViewBag.CardIndexs = re.ToArray();
                ViewBag.Cards = li.ToArray();
                ViewBag.CardsUtd = new bool[] { isutd0, isutd1, isutd2, isutd3 };



                string json = System.IO.File.ReadAllText("tarottext.json");

                var ss = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TarotText>>(json);

                var textli = new List<string>();
                if (isutd0)
                {
                    var tt = (ss[0] as TarotText).reversed.domains.career;
                    textli.Add(tt);
                }
                else
                { 
                    var tt = (ss[0] as TarotText).upright.domains.career;
                    textli.Add(tt);
                }


                if (isutd1)
                {
                    var tt = (ss[1] as TarotText).reversed.domains.love;
                    textli.Add(tt);
                }
                else
                {
                    var tt = (ss[1] as TarotText).upright.domains.love;
                    textli.Add(tt);
                }


                if (isutd2)
                {
                    var tt = (ss[2] as TarotText).reversed.domains.health;
                    textli.Add(tt);
                }
                else
                {
                    var tt = (ss[2] as TarotText).upright.domains.health;
                    textli.Add(tt);
                }


                if (isutd3)
                {
                    var tt = (ss[3] as TarotText).reversed.domains.mind;
                    textli.Add(tt);
                }
                else
                {
                    var tt = (ss[3] as TarotText).upright.domains.mind;
                    textli.Add(tt);
                }



                ViewBag.TarotText = textli.ToArray();

                ViewBag.result = result;
            }
            return View();
        }
    }
}
