using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            UserContext context = new UserContext();
            string activityLine = "************************************************\n" +
                DateTime.Now + "\n"
                + LoginValidation.CurrentUsername + "\n"
                + LoginValidation.CurrentUserRole + "\n"
                + activity + "\n************************************************\n";
            currentSessionActivities.Add(activityLine);

            Log log = new Log();

            log.LogString = activityLine;

            context.Logs.Add(log);
            context.SaveChanges();

            File.AppendAllText("LogFile.txt", activityLine);
            File.Delete(Path.GetFullPath(@"..\..\..\LogFile.txt"));
            File.Copy("LogFile.txt", Path.GetFullPath(@"..\..\..\LogFile.txt"));
        }

        public static void LogError(string errorMessage, int errorCode)
        {
            string activityLine = "************************************************\n"
                + DateTime.Now + "\n"
                + "Код на грешка: " + errorCode + " - " + errorMessage
                + "\n************************************************\n\n";

            File.AppendAllText("LogErrorFile.txt", activityLine);
        }

        public static IEnumerable<string> GetCurrentSessionActivities()
        {
            return currentSessionActivities;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            return currentSessionActivities.Where(a => a.Contains(filter));
        }
    }
}
