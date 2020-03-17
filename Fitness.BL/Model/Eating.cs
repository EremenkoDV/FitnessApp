using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime Moment { get; }
        
        /// <summary>
        ///  List of foods
        /// </summary>
        public Dictionary<int, double> Foods { get; }

        public int UserId { get; set; }

        /// <summary>
        /// Eating user
        /// </summary>
        public virtual User User { get; set;  }


        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<int, double>();
        }

        public void Add(Food food, double weight)
        {
            var productId = Foods.Keys.FirstOrDefault(e => e == food.Id);

            if (productId == 0)
            {
                Foods.Add(food.Id, weight);
            }
            else
            {
                Foods[productId] += weight;
            }
        }
    }
}
