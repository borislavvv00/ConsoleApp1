using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"+ LoginValidation.currentUserUsername + ";"+ LoginValidation.currentUserRole + ";"+ activity;
            currentSessionActivities.Add(activityLine);

            string s = File.ReadAllText("test.txt");
            s += currentSessionActivities[currentSessionActivities.Capacity - 1];
            File.WriteAllText("test.txt", s);
        }

        static public string GetCurrentSessionActivities()
        {
            return currentSessionActivities[currentSessionActivities.Capacity - 1];
        }

    }
}
