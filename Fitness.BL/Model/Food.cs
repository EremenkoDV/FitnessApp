using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class Food
    /// </summary>
    public class Food
    {

        /// <summary>
        /// Food's name
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Food's ID
        /// </summary>

        public string Name { get; }

        /// <summary>
        /// Proteins in mg
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Fats in mg
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Carbohydrates in mg
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Calories
        /// </summary>
        public double Calories { get; set; }

        //private double ProteinsPerOneGramm => Proteins / 100.0;
        //private double FatsPerOneGramm => Fats / 100.0;
        //private double CarbohydratesPerOneGramm => Carbohydrates / 100.0;
        //private double CaloriesPerOneGramm => Calories / 100.0;

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: проверка
            Name = name;
            Id = Name.GetHashCode();
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override int GetHashCode()
        {
            //return Encoding.UTF8.GetBytes(name,) name.Length
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
