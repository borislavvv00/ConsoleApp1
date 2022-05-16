using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoginValidation
    {
        private string userName;
        private string password;
        private string error;

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError err;

        public LoginValidation(string user_name, string pass, ActionOnError Err)
        {
            userName = user_name;
            password = pass;
            err = Err;
        }

        static public UserRoles currentUserRole
        {
            get;
            private set;
        }

        static public string currentUserUsername { get; set }
        public bool ValidateUserInput(ref User user)
        {
            bool retVal = false ;

            if ((5u > userName.Length) || (5u > password.Length))
            {
                user = UserData.IsUserPassCorrect(userName, password);

                if(null == user)
                {
                    error = "User not found!";
                    err(error);
                    currentUserRole = UserRoles.ANONYMOUS;
                }
                else
                {
                    retVal = true;
                    Logger.LogActivity("Success log in");
                    currentUserRole = (UserRoles)user.role;
                }
            }
            else
            {
                error = "Too short name or password!";
                err(error);
                currentUserRole = UserRoles.ANONYMOUS;
            }

            return retVal;
        }
    }
}
