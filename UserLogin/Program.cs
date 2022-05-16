using System;
using System.IO;
using System.Text;

namespace UserLogin
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Console.Write("Въведете потребителско име: ");
            user.Username = Console.ReadLine();

            Console.Write("Въведете потребителска парола: ");
            user.Password = Console.ReadLine();

            LoginValidation loginValidation = new LoginValidation(user.Username, user.Password, Message);

            UserData.ResetTestUserData();

            User validationUser;

            if (loginValidation.ValidateUserInput(out validationUser))
            {
                Console.WriteLine("Потребител: " + validationUser.Username +
                                  "\nПарола: " + validationUser.Password +
                                  "\nФакултетен номер: " + validationUser.FacultyNumber +
                                  "\nРоля: " + validationUser.UserRole);

                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ADMIN:
                        try
                        {
                            AdminOperation();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    case UserRoles.STUDENT:
                        Console.WriteLine("Избраният потребител е студент.");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Избраният потребител е професор.");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Избраният потребител е инспектор.");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Избраният потребител е анонимен.");
                        break;
                }
            }
        }

        public static void Message(string message, int errorCode)
        {
            Logger.LogError(message, errorCode);
            Console.WriteLine("!!! " + message + " !!!");
        }

        public static void AdminOperation()
        {
            Console.WriteLine("Избраният потребител е администратор.");

            Console.WriteLine("\n0: Изход\n" +
                              "1: Промяна на роля на потребител\n" +
                              "2: Промяна на активност на потребител\n" +
                              "3: Списък на потребителите\n" +
                              "4: Преглед на лог на активност\n" +
                              "5: Преглед на текущата активност\n");
            Console.Write("Избрете операция: ");
            int chosenOperation = int.Parse(Console.ReadLine());

            switch (chosenOperation)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    ChangeUserRole();
                    break;
                case 2:
                    ChangeToActiveDate();
                    break;
                case 3:
                    ShowUsers();
                    break;
                case 4:
                    ReadLogFile();
                    break;
                case 5:
                    Console.WriteLine("Филтрирайте по:");

                    string filter = Console.ReadLine();

                    StringBuilder sessionActivities = new StringBuilder();

                    foreach (var currentSession in Logger.GetCurrentSessionActivities(filter))
                    {
                        sessionActivities.Append(currentSession);
                    }

                    Console.WriteLine(sessionActivities.ToString());
                    break;
                default:
                    Console.WriteLine("Невалидна операция");
                    break;
            }
        }
        public static void ChangeUserRole()
        {
            try
            {
                Console.WriteLine("Въведете потребителско име: ");
                string username = Console.ReadLine();

                Console.WriteLine("Въведете роля(цяло число 0-4): ");
                UserRoles userRole = (UserRoles)int.Parse(Console.ReadLine());

                UserData.AssignUserRole(username, userRole);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ChangeToActiveDate()
        {
            try
            {
                Console.Write("Въведете потребителско име: ");
                string username = Console.ReadLine();

                Console.Write("Въведете дата до която е активен потребителя: ");
                DateTime activeToDate = DateTime.Parse(Console.ReadLine()); ;

                UserData.SetUserActiveTo(username, activeToDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowUsers()
        {
            UserContext context = new UserContext();
            foreach (var user in context.Users)
            {
                Console.Write(user.Username + " " +
                              user.UserRole + " " +
                              user.FacultyNumber + " " +
                              user.DateOfCreation.ToShortDateString() + " " +
                              user.DateActiveTo.ToShortDateString() + "\n");
            }
        }

        public static void ReadLogFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("LogFile.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
