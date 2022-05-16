using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginValidation validation = new LoginValidation();


            if (true == validation.ValidateUserInput())
            {
                Console.WriteLine(UserData.testUser.name);
                Console.WriteLine(UserData.testUser.password);
                Console.WriteLine(UserData.testUser.facNumber);
                Console.WriteLine(UserData.testUser.role);
                Console.WriteLine(LoginValidation.currentUserRole);
            }
        }
    }
}
