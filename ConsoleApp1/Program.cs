using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void ActionOnError(string errorMsg);

        static  void  AcError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        static private void PrintUsers()
        {
            foreach (User user in UserData.testUsers)
            {
                Console.WriteLine(user.name);
                Console.WriteLine(user.password);
                Console.WriteLine(user.facNumber);
                Console.WriteLine(user.role);
                Console.WriteLine(user.activeDue);
                Console.WriteLine(user.Created);
            }
        }

        static private void PrintLog()
        {
            string s = File.ReadAllText("test.txt");
            Console.WriteLine(s);
        }

        static private void PrintCurrectActivity()
        {
            Console.WriteLine(Logger.GetCurrentSessionActivities());
        }


        static private void AdminMenu()
        {
            int input = 0;
            int newRole = 0;
            string newName = "";
            string newName1 = "";
            DateTime newDate = DateTime.MinValue;

            Console.WriteLine("Choose option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change role of user");
            Console.WriteLine("2: Change active date of user");
            Console.WriteLine("3: List of user");
            Console.WriteLine("4: Check activity log");
            Console.WriteLine("5: Check current activity");
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 0:
                    break;
                case 1:
                    newName = Console.ReadLine();
                    newRole = int.Parse(Console.ReadLine());
                    UserData.AssignUserRole(newName, (UserRoles)newRole);
                    Logger.LogActivity("Change role of user");
                    break;
                case 2:
                    newName1 = Console.ReadLine();
                    newDate = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(newName1, newDate);
                    Logger.LogActivity("Change active date of user");
                    break;
                case 3:
                    PrintUsers();
                    Logger.LogActivity(" List of user");
                    break;
                case 4:
                    PrintLog();
                    Logger.LogActivity(" Check activity log");
                    break;
                case 5:
                    PrintCurrectActivity();
                    Logger.LogActivity(" Check current activity");
                    break;
                default:
                    //Do nothing.
                    break;
            }
        }
        static void Main(string[] args)
        {
            string name = "";
            string pass = "";
            name = Console.ReadLine();
            pass = Console.ReadLine();
            LoginValidation validation = new LoginValidation(name, pass, AcError);
            User user = new User();
            UserData.MainMethod();

            if (true == validation.ValidateUserInput(ref user))
            {
                AdminMenu();

            }
        }
    }
}
