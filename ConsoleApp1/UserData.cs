using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class UserData
    {
        static public User testUser;
        static private void ResetTestUserData()
        {
            testUser = new User();

            if (null == testUser)
            {
                testUser.name = "Gosho";
                testUser.password = "ddd";
                testUser.facNumber = "12121222112";
                testUser.role = 1;
            }
        }


    }
}
