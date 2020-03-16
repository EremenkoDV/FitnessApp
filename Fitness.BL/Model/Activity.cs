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
        public double CaloriesperMinute { get; }
        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesperMinute)
        {

            // TODO : проверка
            Name = name;
            CaloriesperMinute = caloriesperMinute;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
