using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class UserData
    {
        static public List<User> testUsers;
        static private void ResetTestUserData()
        {
            for (int i = 0; i < 3; i++)
            {
                if (null == testUsers[i])
                {
                    testUsers[i] = new User();
                    testUsers[i].name = "Gosho";
                    testUsers[i].password = "ddd";
                    testUsers[i].facNumber = "12121222112";
                    testUsers[i].Created = DateTime.Now;
                    testUsers[i].activeDue = DateTime.MaxValue;

                    if (0u == i)
                    {
                        testUsers[i].role = 1;
                    }
                    else
                    {
                        testUsers[i].role = 4;
                    }
                }
            }
        }

        static public void SetUserActiveTo(string name, DateTime dueData)
        {
            foreach (User testUser in testUsers)
            { 
                if(name == testUser.name)
                {
                    testUser.activeDue = dueData;
                    Logger.LogActivity("Change active date of " + name);
                }
            }
        }

        static public void AssignUserRole(string name, UserRoles newRole)
        {
            foreach (User testUser in testUsers)
            {
                if (name == testUser.name)
                {
                    testUser.role = (int)newRole;

                    Logger.LogActivity("Change role of " + name);
                }
            }
        }


        static public User IsUserPassCorrect(string name, string pass)
        {
            User retVal = null;

            foreach (User testUser in testUsers)
            {
                if((name == testUser.name) && (pass == testUser.password))
                {
                    retVal = testUser;
                }
            }

            return retVal;
        }


        static public void MainMethod()
        {
            ResetTestUserData();
        }
    }
}
