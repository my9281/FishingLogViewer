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
                return "The content is too lengthy. Please limit it to within 1500 words.";
            }
            else if (content.ntitle?.Length > 150)
            {
                return "The title is too lengthy. Please limit it to within 150 words.";
            }
            else if (content.nuser?.Length > 50)
            {
                return "The username is too lengthy. Please limit it to within 50 words.";
            }
            else if (string.IsNullOrEmpty(content.ntext))
            {
                return "The content cannot be empty.";
            }
            else if (string.IsNullOrEmpty(content.ntitle))
            {
                return "The Title cannot be empty.";
            }
            else if (_u.AddNote(content))
            {
                return "Good Job. Thank you.";
            }
            else
            {
                return "Fail.";
            }   
        }
    }
}
