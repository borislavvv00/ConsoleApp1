using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public delegate void ActionOnError(string errorMessage, int errorCode);

        private string username;
        private string password;
        private string errorMessage;
        private ActionOnError action;

        public static UserRoles CurrentUserRole { get; private set; }

        public static string CurrentUsername { get; private set; }

        public LoginValidation(string username, string password, ActionOnError action)
        {
            this.username = username;
            this.password = password;
            this.action = action;
        }

        public bool ValidateUserInput(out User user)
        {
            if (string.IsNullOrEmpty(username))
            {
                errorMessage = "Не е посочено потребителско име.";
                action(errorMessage, 10010);
                user = new User();
                return false;
            }

            if (username.Length < 5)
            {
                errorMessage = "Потребителското име трябва да е поне 5 символа.";
                action(errorMessage, 10011);
                user = new User();
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Не е посочена парола.";
                action(errorMessage, 10012);
                user = new User();
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Потребителската парола трябва да е поне 5 символа.";
                action(errorMessage, 10013);
                user = new User();
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                CurrentUsername = user.Username;
                CurrentUserRole = user.UserRole;
                Logger.LogActivity("Успешен Login");
                return true;
            }

            CurrentUsername = "";
            CurrentUserRole = UserRoles.ANONYMOUS;
            errorMessage = "Невалидно потребителско име или парола.";
            action(errorMessage, 10014);
            return false;
        }
    }
}
