using CodeFintess.BL.Controller;
using CodeFintess.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ua-ua");
            var resourceManager = new ResourceManager("CodeFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterN", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.ISNewUser)
            {
                Console.Write("Write the gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("date of birthday");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("E - to take a meal");
                Console.WriteLine("A - enter exercis");
                Console.WriteLine("Q - EXIT");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var  exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Beging, exe.End);

                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} z {item.Start.ToShortTimeString()} and {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Beging, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Writte name exercise: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("Energy consumption per minute");

            var begin = ParseDateTime("Start exercise");
            var end = ParseDateTime("Finish exercise");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter the product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Calories");
            var prot = ParseDouble("Proteina");
            var fats = ParseDouble("Fats");
            var carbs = ParseDouble("Carbohydrates");

            var weight = ParseDouble("weight of the product: ");
            var product = new Food(food, calories, prot, fats, carbs);

            return (Food: product, Weight: weight);

        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong date format {value}");
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
                    Console.WriteLine($"Wrong format field {name}");
                }
            }
        }
    }
}
