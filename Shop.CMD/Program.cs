using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Shop.BL.Controller;
using Shop.BL.Model;

namespace Shop.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            Console.WriteLine("enterName");
            var name = Console.ReadLine();

            var userController = new UserController(name);
          
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender");
                var gender = Console.ReadLine();

                DateTime birthDate = ParseDateTime("Birdthday");

                Console.WriteLine("Enter Number");
                var number = Console.ReadLine();

                Console.WriteLine("Enter Addres");
                var addres = Console.ReadLine();
                userController.SetNewUserData(gender, birthDate, number, addres);
            }

            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E-Enter product.");
            Console.WriteLine("I-Input Order");
            Console.WriteLine("Q-exit.");

            var key = Console.ReadKey();

            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterFood();
                    userController.FoodMenuAdd(foods);
                    break;
                case ConsoleKey.I:
                    var ordercontroller = new OrderController(userController.CurrentUser.Id);
                    var orderFood = EnterOrder();
                    ordercontroller.Add(orderFood,4);
                    break;
                    
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }


        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter{value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid date format {value}");
                }
            }
            return birthDate;
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid field format {name}");
                }
            }
        }
        public static List<Food> EnterFood()
        {
            var foods = new List<Food>();
            do
            {
                Console.WriteLine("Enter product name.");
                var foodname = Console.ReadLine();
                var proteins = ParseDouble("proteins");
                var fats = ParseDouble("fats");
                var carbohydrates = ParseDouble("carbohydrates");
                var calories = ParseDouble("calories");
                var price = ParseDouble("price");
                var food = new Food(foodname, proteins, fats, carbohydrates, calories, price);
                foods.Add(food);
                Console.WriteLine("Another product?");
                Console.WriteLine("Y-Yes");
                Console.WriteLine("N-No");
            }
            while (Console.ReadLine().ToLower() == "N");

            return foods;
        }
        public static Food EnterOrder()
        {
            Console.WriteLine("Enter product name.");
            var foodname = Console.ReadLine();
            var food = new Food(foodname);
            return food;
        }
        
    }
}
