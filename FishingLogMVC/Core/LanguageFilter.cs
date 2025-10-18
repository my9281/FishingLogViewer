using FishingLogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FishingLogMVC.Core
{
    public class LanguageFilter : IActionFilter
    {
        private readonly string[] _supportedLanguages = new[] { "en", "zh-CN", "zh-TW" };
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var laning = "en";
            if (context != null)
            {
                if (context.HttpContext.Request.Query.Keys.Contains("lan"))
                {
                    var templan = context.HttpContext.Request.Query["lan"].ToString();
                    if (_supportedLanguages.Contains(templan))
                    {
                        laning = templan;
                        context.HttpContext.Response.Cookies.Append("UserLang", laning, new CookieOptions
                        {
                            Expires = DateTimeOffset.UtcNow.AddYears(1)
                        });
                        context.HttpContext.Request.RouteValues["UserLang"] = laning;
                    }

                }
                else if (context.HttpContext.Request.Cookies.TryGetValue("UserLang", out var lanCookie) &&
                     _supportedLanguages.Contains(lanCookie))
                {
                    laning = lanCookie;
                }
                else
                {
                    var acceptLanguage = context.HttpContext.Request.Headers["Accept-Language"].ToString();
                    if (!string.IsNullOrEmpty(acceptLanguage))
                    {
                        var languages = acceptLanguage.Split(',')
                                                      .Select(l => l.Split(';').FirstOrDefault())
                                                      .Where(l => !string.IsNullOrWhiteSpace(l));
                        foreach (var lang in languages)
                        {
                            if (_supportedLanguages.Contains(lang))
                            {
                                laning = lang;
                                break;
                            }
                        }
                    }
                }
            }
            if (context.Controller is Controller)
            {
                var c = context.Controller as Controller;
                var dic = TransInfos.Dictionary.Where(ex => ex.Lan == laning).ToList();




                var nowdi = new Dictionary<string, string>();
                foreach (var item in dic)
                {
                    nowdi.Add(item.Key, item.Value);
                }
                c.ViewBag.Dic = nowdi;
                c.ViewBag.Lan = laning;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // 可选：Action 执行后
        }

    }
}
