using FishingLog.Model;

namespace FishingLogMVC.Core
{
    public class DBNote
    {
        private static readonly FishingLog.BLL.note _u = new FishingLog.BLL.note();


        public static string AddNote(note content)
        {
            if (content.ntext?.Length > 1500)
            {
                return "内容过长，限制1500字以内";
            }
            else if (content.ntitle?.Length > 150)
            {
                return "标题过长，限制150字以内";
            }
            else if (content.nuser?.Length > 50)
            {
                return "用户名过长，限制50字以内";
            }
            else if (string.IsNullOrEmpty(content.ntext))
            {
                return "内容不能为空";
            }
            else if (string.IsNullOrEmpty(content.ntitle))
            {
                return "标题不能为空";
            }
            else if (_u.AddNote(content))
            {
                return "成功";
            }
            else
            {
                return "失败，请稍后重试";
            }   
        }
    }
}
