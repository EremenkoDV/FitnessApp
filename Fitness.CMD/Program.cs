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

            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол пользователя:");
                string gender = Console.ReadLine();

                Console.Write("Введите дату рождения пользователя:");
                string birthday = Console.ReadLine();

                //Console.Write("Введите вес пользователя:");
                //double weight;
                double weight = GetCorrectedValue<double>("вес пользователя: ");

                Console.Write("Введите рост пользователя:");
                string height = Console.ReadLine();

                userController.SetNewUserData(name, gender, birthday, weight, height);
            }

            Console.Write(userController.CurrentUser);
            Console.ReadLine();

        }

        private static T GetCorrectedValue<T>(string parameter)
        {
            int attemps = 0;
            bool isChecked = false;
            T result;
            result = default(T);
            do
            {
                Console.Write("Введите " + parameter);
                switch (result.GetType().ToString())
)               {
                    case typeof(int).ToString():
                        int intResult;
                        if (int.TryParse(Console.ReadLine(), out intResult))
                        {
                            isChecked = true;
                        }
                        break;
                    case typeof(double).ToString():
                        double dblResult;
                        if (double.TryParse(Console.ReadLine(), out dblResult))
                        {
                            isChecked = true;
                        }
                        break;
                    case typeof(DateTime).ToString():
                        DateTime dtResult;
                        if (DateTime.TryParse(Console.ReadLine(), out dtResult))
                        {
                            isChecked = true;
                        }
                        break;
                    default:
                        string strResult;
                        strResult = Console.ReadLine();
                        isChecked = true;
                        break;
                }

                if (isChecked)
                {
                    Console.WriteLine("Введены некоректные данные. Попробуйте еще раз.");
                }

            } while (attemps++ < 3);

            throw new ArgumentException("Введены некоректные данные. Количество попыток исчерпано!", nameof(parameter));

            class T
            {
                protected string Type()
                {
                    return GetType()
                }
            }
        }

    }
}
