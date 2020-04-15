using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        static CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-RU");
        //static CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        //static CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
        static ResourceManager resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {

            Console.WriteLine(resourceManager.GetString("Welcome", culture));
            Console.WriteLine(resourceManager.GetString("Line", culture));

            string name = GetEnteredValue<string>(resourceManager.GetString("UserName", culture) + ": ", "value <> ''");

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                string gender = GetEnteredValue<string>(resourceManager.GetString("UserGender", culture) + ": ", "value <> ''");
                DateTime birthday = GetEnteredValue<DateTime>(resourceManager.GetString("UserBirthday", culture) + ": ", "value > '01.01.1900' AND value < '" + DateTime.Now + "'");
                double weight = GetEnteredValue<double>(resourceManager.GetString("UserWeight", culture) + ": ", "value > '10' AND value < '300'");
                double height = GetEnteredValue<double>(resourceManager.GetString("UserHeight", culture) + ": ", "value > '50' AND value < '300'");

                userController.SetNewUserData(name, gender, birthday, weight, height);
            }

            Console.Write(userController.CurrentUser);
            //Console.ReadLine();

            while (true)
            {
                Console.WriteLine(resourceManager.GetString("Line", culture));
                Console.WriteLine(resourceManager.GetString("ActQuestion", culture));
                Console.WriteLine(resourceManager.GetString("Select1", culture) + " :");
                Console.WriteLine(resourceManager.GetString("Select2", culture) + " :");
                Console.WriteLine(resourceManager.GetString("Select3", culture) + " :");
                Console.WriteLine(resourceManager.GetString("Select4", culture) + " :");
                Console.WriteLine(resourceManager.GetString("Select5", culture) + " :");
                var key = Console.ReadKey();
                Console.WriteLine();

                //switch (key.Key)
                switch (key.KeyChar)
                {
                    //case ConsoleKey.E:
                    case 'e':
                    case 'E':
                        if (key.KeyChar == 'E')
                        {
                            string foodName = GetEnteredValue<string>(resourceManager.GetString("FoodName", culture) + ": ", "value <> ''");
                            double weight = GetEnteredValue<double>(resourceManager.GetString("FoodWeight", culture) + ": ", "value > '0' AND value < '10000'");
                            double calories = GetEnteredValue<double>(resourceManager.GetString("FoodCalories", culture) + ": ", "value > '0' AND value < '10000'");
                            double proteins = GetEnteredValue<double>(resourceManager.GetString("FoodProteins", culture) + ": ", "value >= '0' AND value < '10000'");
                            double fats = GetEnteredValue<double>(resourceManager.GetString("FoodFats", culture) + ": ", "value >= '0' AND value < '10000'");
                            double carbohydrates = GetEnteredValue<double>(resourceManager.GetString("FoodCarbohydrates", culture) + ": ", "value >= '0' AND value < '10000'");

                            Food food = new Food(foodName, calories, proteins, fats, carbohydrates);
                            eatingController.Add(food, weight);
                        }

                        //Console.Write(eatingController.Eating.Foods.FirstOrDefault(e => e.Key == foodName.GetHashCode()));
                        foreach (var item in eatingController.Foods)
                        {
                            Console.WriteLine(resourceManager.GetString("Line", culture));
                            Console.WriteLine($"\t{item.Name} : {item.Calories} kcal - prot/fat/carb : {item.Proteins}g/{item.Fats}g/{item.Carbohydrates}g");
                        }
                        break;
                    //case ConsoleKey.A:
                    case 'a':
                    case 'A':
                        if (key.KeyChar == 'A')
                        {
                            string exerciseName = GetEnteredValue<string>(resourceManager.GetString("ExerciseName", culture) + ": ", "value <> ''");
                            double energy = GetEnteredValue<double>(resourceManager.GetString("ExerciseEnergy", culture) + ": ", "value > '0' AND value < '10000'");
                            DateTime begin = GetEnteredValue<DateTime>(resourceManager.GetString("ExerciseBegin", culture) + ": ", "value > '01.01.1900' AND value < '31.12.2100'");
                            DateTime end = GetEnteredValue<DateTime>(resourceManager.GetString("ExerciseEnd", culture) + ": ", "value > '01.01.1900' AND value < '31.12.2100'");
                            var activity = new Activity(exerciseName, energy);
                            //var exercise = new Exercise(begin, end, activity, userController.CurrentUser);
                            exerciseController.Add(activity, begin, end);
                        }

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine(resourceManager.GetString("Line", culture));
                            Console.WriteLine($"\t{item.Activity} : {item.Start.ToShortTimeString()} - {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    //case ConsoleKey.Q:
                    case 'q':
                    case 'Q':
                        Environment.Exit(0);
                        break;
                }
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
        /// Get entered value from keyboard
        /// </summary>
        /// <typeparam name="T">any struct type, e.g. (int, float, double, string, bool, DateTime)</typeparam>
        /// <param name="parameter">parameter's name</param>
        /// <param name="conditions">SQL string conditions, e.g. "value > '01.01.2000' AND value < '31.12.2020'"</param>
        /// <returns></returns>
        public static T GetEnteredValue<T>(string parameter, string conditions = "")
        {
            int attemps = 3;
            do
            {
                Console.Write(resourceManager.GetString("Enter", culture) + " " + parameter);

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

            Console.WriteLine(resourceManager.GetString("ErrorMessage1", culture));
            throw new ArgumentException(resourceManager.GetString("ErrorMessage2", culture), nameof(parameter));

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
