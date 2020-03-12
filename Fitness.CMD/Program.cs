using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness.");
            int age = GetInputedValue<int>("возраст пользователя: ", "value > 0");
            DateTime birthday = GetInputedValue<DateTime>("день рождения пользователя: ");
            double weight = GetInputedValue<double>("вес пользователя: ");
            double height = GetInputedValue<double>("рост пользователя: ");

            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол пользователя:");
                string gender = Console.ReadLine();
                //DateTime birthday = GetInputedValue<DateTime>("день рождения пользователя: ");
                //double weight = GetInputedValue<double>("вес пользователя: ");
                //double height = GetInputedValue<double>("рост пользователя: ");

                //userController.SetNewUserData(name, gender, birthday, weight.ToString(), height);
            }

            Console.Write(userController.CurrentUser);
            Console.ReadLine();

        }


        public static bool TryParse<T>(string input, out T result)
        {
            result = default(T);
            try
            {
                TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T GetInputedValue<T>(string parameter, string conditions = "")
        {
            int attemps = 3;
            T result;
            do
            {
                Console.Write("Введите " + parameter);

                if (TryParse<T>(Console.ReadLine(), out result))
                {
                    if (TestCondition(result, conditions))
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Введены данные не соответствующие условию : {conditions}. {(attemps == 1 ? "Осталась " + attemps + " попытка" : "Осталось " + attemps + (attemps > 1 && attemps < 5 ? " попытки" : " попыток"))}.");
                    }
                }
                else if (attemps-- > 0)
                {
                    Console.WriteLine($"Введены некоректные данные. {(attemps == 1 ? "Осталась " + attemps + " попытка" : "Осталось " + attemps + (attemps > 1 && attemps < 5 ? " попытки" : " попыток"))}.");
                }

            } while (attemps > 0);

            Console.WriteLine("Количество попыток исчерпано!");
            throw new ArgumentException("Введены некоректные данные. Количество попыток исчерпано!", nameof(parameter));

        }

        public static bool TestCondition<T>(T value, string c)
        {
            var dt = new DataTable();
            dt.Columns.Add("value", typeof(T));
            DataRow row = dt.NewRow();
            //dt.Rows.Add("value");
            row["value"] = value;
            // hack
            // c is constant and doesn't depend on dt columns
            // if there are any rows, c is TRUE
            var rows = dt.Select(c);
            return rows.Length > 0;
        }

    }
}
