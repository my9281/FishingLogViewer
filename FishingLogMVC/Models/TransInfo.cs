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
            Dictionary.Add(new TransInfo()
            {
                Key="Title",
                Lan="en",
                Value= "Fishing project log viewer"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Title",
                Lan = "zh-TW",
                Value = "摸魚記錄瀏覽器"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Title",
                Lan = "zh-CN",
                Value = "摸鱼日志查看器"
            });

            Dictionary.Add(new TransInfo()
            {
                Key = "logout",
                Lan = "en",
                Value = "Logout"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "logout",
                Lan = "zh-TW",
                Value = "註銷"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "logout",
                Lan = "zh-CN",
                Value = "退出"
            });


            Dictionary.Add(new TransInfo()
            {
                Key = "Login",
                Lan = "en",
                Value = "Login"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Login",
                Lan = "zh-TW",
                Value = "登錄"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Login",
                Lan = "zh-CN",
                Value = "登录"
            });





            Dictionary.Add(new TransInfo()
            {
                Key = "AccountID",
                Lan = "en",
                Value = "Account ID :"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "AccountID",
                Lan = "zh-TW",
                Value = "通行證號 ："
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "AccountID",
                Lan = "zh-CN",
                Value = "账号 :"
            });





            Dictionary.Add(new TransInfo()
            {
                Key = "AccountIDPH",
                Lan = "en",
                Value = "Input your accountid"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "AccountIDPH",
                Lan = "zh-TW",
                Value = "您的通行證號碼"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "AccountIDPH",
                Lan = "zh-CN",
                Value = "您的账号"
            });


            Dictionary.Add(new TransInfo()
            {
                Key = "Password",
                Lan = "en",
                Value = "Password :"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Password",
                Lan = "zh-TW",
                Value = "密鑰 ："
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Password",
                Lan = "zh-CN",
                Value = "密码 ："
            });


            Dictionary.Add(new TransInfo()
            {
                Key = "PasswordPH",
                Lan = "en",
                Value = "Input your password"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "PasswordPH",
                Lan = "zh-TW",
                Value = "您的秘鑰"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "PasswordPH",
                Lan = "zh-CN",
                Value = "您的密码"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Submit",
                Lan = "en",
                Value = "Submit"
            }); 
            Dictionary.Add(new TransInfo()
            {
                Key = "Submit",
                Lan = "zh-TW",
                Value = "確認"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Submit",
                Lan = "zh-CN",
                Value = "提交"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Fortune",
                Lan = "en",
                Value = "Fortune"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Fortune",
                Lan = "zh-TW",
                Value = "今日運勢"
            });
            Dictionary.Add(new TransInfo()
            {
                Key = "Fortune",
                Lan = "zh-CN",
                Value = "今日运势"
            });

        }
        public static List<TransInfo> Dictionary { get; set; } = [];
    }
}
