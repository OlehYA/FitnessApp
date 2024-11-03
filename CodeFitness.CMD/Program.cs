using CodeFintess.BL.Controller;
using CodeFintess.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the arm fitness program!");

            Console.WriteLine("Enter the user name.");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.ISNewUser)
            {
                Console.Write("Write the gender");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your date of birth (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format birth day");
                }
            }

            return birthDate;

        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter your {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong format {name}");
                }
            }
        }
    }
}
