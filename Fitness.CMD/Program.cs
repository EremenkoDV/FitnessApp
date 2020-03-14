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
            Console.WriteLine("--------------------------------------------------------");

            string name = GetInputedValue<string>("имя пользователя: ", "value <> ''");

            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                string gender = GetInputedValue<string>("пол пользователя: ", "value <> ''");
                DateTime birthday = GetInputedValue<DateTime>("день рождения пользователя: ", "value > '01.01.1900' AND value < '" + DateTime.Now + "'");
                double weight = GetInputedValue<double>("вес пользователя: ", "value > '10' AND value < '300'");
                double height = GetInputedValue<double>("рост пользователя: ", "value > '50' AND value < '300'");

                userController.SetNewUserData(name, gender, birthday, weight, height);
            }

            Console.Write(userController.CurrentUser);
            //Console.ReadLine();

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Что Вы хотите сделать?");
            Console.Write("E - ввести прием пищи :");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                Console.WriteLine("");
                string foodName = GetInputedValue<string>("имя продукта: ", "value <> ''");
                double weight = GetInputedValue<double>("вес порции продукта (в граммах): ", "value > '0' AND value < '10000'");
                double calories = GetInputedValue<double>("количество калорийность в порции продукта (в калориях): ", "value > '0' AND value < '10000'");
                double proteins = GetInputedValue<double>("количество белков в порции продукта (в граммах): ", "value >= '0' AND value < '10000'");
                double fats = GetInputedValue<double>("количество жиров в порции продукта (в граммах): ", "value >= '0' AND value < '10000'");
                double carbohydrates = GetInputedValue<double>("количество углеводов в порции продукта (в граммах): ", "value >= '0' AND value < '10000'");

                Food food = new Food(foodName, calories, proteins, fats, carbohydrates);
                EatingController eatingController = new EatingController(userController.CurrentUser);
                eatingController.Add(food, weight);

                //Console.Write(eatingController.Eating.Foods.FirstOrDefault(e => e.Key == foodName.GetHashCode()));
                foreach (var item in eatingController.Foods)
                {
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Calories);
                    Console.WriteLine(item.Proteins);
                    Console.WriteLine(item.Fats);
                    Console.WriteLine(item.Carbohydrates);
                }


                Console.ReadLine();
            }



        }

        /// <summary>
        /// TryParse method for any struct types
        /// </summary>
        /// <typeparam name="T">any struct type, e.g. (int, float, double, string, bool, DateTime)</typeparam>
        /// <param name="value">input value</param>
        /// <param name="result">output value</param>
        /// <returns></returns>
        public static bool TryParse<T>(string value, out T result)
        {
            result = default(T);
            try
            {
                result = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get inputed value from keyboard
        /// </summary>
        /// <typeparam name="T">any struct type, e.g. (int, float, double, string, bool, DateTime)</typeparam>
        /// <param name="parameter">parameter's name</param>
        /// <param name="conditions">SQL string conditions, e.g. "value > '01.01.2000' AND value < '31.12.2020'"</param>
        /// <returns></returns>
        public static T GetInputedValue<T>(string parameter, string conditions = "")
        {
            int attemps = 3;
            do
            {
                Console.Write("Введите " + parameter);

                if (TryParse<T>(Console.ReadLine(), out T result))
                {
                    if (IsTrue(result, conditions))
                    {
                        return result;
                    }
                    else if (attemps-- > 0)
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

        /// <summary>
        /// Test value on conditions
        /// </summary>
        /// <typeparam name="T">any struct type, e.g. (int, float, double, string, bool, DateTime)</typeparam>
        /// <param name="value">value</param>
        /// <param name="conditions">SQL string conditions, e.g. "(value > '0' AND value < '10' AND value <> '5') OR (value > '50' AND value < '60')"</param>
        /// <returns></returns>
        public static bool IsTrue<T>(T value, string conditions)
        {
            var dt = new DataTable();
            dt.Columns.Add("value", typeof(T));
            DataRow row = dt.NewRow();
            row["value"] = value;
            dt.Rows.Add(row);
            //dt.AcceptChanges();
            var rows = dt.Select(conditions);
            return rows.Length > 0;
        }

    }
}
