using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Class EatingConrtroller
    /// </summary>
    public class EatingController : ControllerBase
    {

        private const string FOODS_FILE_NAME = "foods.dat";
        
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(user));

            Foods = Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
            Eating = Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(this.user);
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.FirstOrDefault(e => e.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save<List<Food>>(FOODS_FILE_NAME, Foods);
            }
            else
            {
                Eating.Add(product, weight);
            }
            Save<Eating>(EATINGS_FILE_NAME, Eating);
        }

        //public bool Add(string foodName, double weight)
        //{
        //    var product = Foods.FirstOrDefault(e => e.Name == foodName);
        //    if (product != null)
        //    {
        //        Eating.Add(product, weight);
        //        Save<Eating>(EATINGS_FILE_NAME, Eating);
        //        return true;
        //    }
        //    return false;
        //}


        //private List<Food> GetAllFoods()
        //{
        //    var formatter = new BinaryFormatter();

        //    using (FileStream fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
        //    {
        //        if (fs.Length > 0 && (formatter.Deserialize(fs) is List<Food> foods))
        //        {
        //            return foods;
        //        }
        //        else
        //        {
        //            return new List<Food>();
        //        }
        //    }
        //}
    }
}
