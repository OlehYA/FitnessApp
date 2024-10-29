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

            Console.WriteLine("Enter gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO: re

            Console.WriteLine("Enter weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();




        }
    }
}
