using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoginValidation
    {
        static public UserRoles currentUserRole
        {
            get;
            private set;
        }
        public bool ValidateUserInput()
        {
            bool retVal = true ;
            currentUserRole = UserRoles.ADMIN;
            return retVal;
        }
    }
}
