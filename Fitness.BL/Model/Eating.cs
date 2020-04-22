using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class Food Eating
    /// </summary>
    public class Eating
    {
        public int Id { get; set; }

        /// <summary>
        /// Moment of eating
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        ///  List of foods
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Eating user
        /// </summary>
        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(user));
            UserId = user.Id;
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var _food = Foods.Keys.FirstOrDefault(e => e.Name.Equals(food.Name));

            if (_food == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[_food] += weight;
            }
        }
    }
}
