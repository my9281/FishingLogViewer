using FishingLogMVC.Interfaces;

namespace FishingLogMVC.Core
{
    public class CookiesService<T> : ICookiesService<T>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] _supportedLanguages = new[] { "en-US", "zh-CN", "zh-TW" };
        public CookiesService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserLanguage()
        {
            var context = _httpContextAccessor.HttpContext;

            if (context == null)
                return "en-US"; // fallback

            if (context.Request.Cookies.TryGetValue("lan", out var lanCookie) &&
                _supportedLanguages.Contains(lanCookie))
            {
                return lanCookie;
            }

            var acceptLanguage = context.Request.Headers["Accept-Language"].ToString();
            if (!string.IsNullOrEmpty(acceptLanguage))
            {
                var languages = acceptLanguage.Split(',')
                                              .Select(l => l.Split(';').FirstOrDefault())
                                              .Where(l => !string.IsNullOrWhiteSpace(l));

                foreach (var lang in languages)
                {
                    if (_supportedLanguages.Contains(lang))
                        return lang;
                }
            }

            return "en-US";
        }
    }
}
