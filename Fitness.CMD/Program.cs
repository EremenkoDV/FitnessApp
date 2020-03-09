using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness.");

            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();

            Console.Write("Введите пол пользователя:");
            string gender = Console.ReadLine();

            Console.Write("Введите дату рождения пользователя:");
            string birthday = Console.ReadLine();

            Console.Write("Введите вес пользователя:");
            string weight = Console.ReadLine();

            Console.Write("Введите рост пользователя:");
            string height = Console.ReadLine();

            UserController userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();

            Console.Write(userController.CurrentUser);
            Console.ReadLine();

        }
    }
}
