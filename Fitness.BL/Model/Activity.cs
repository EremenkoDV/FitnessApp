using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{

    [Serializable]
    /// <summary>
    /// Class Activity
    /// </summary>
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {

            // TODO : проверка
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
