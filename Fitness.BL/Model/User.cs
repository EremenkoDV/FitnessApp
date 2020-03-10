using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class User
    /// </summary>
    public class User
    {

        #region Properties
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// User gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// User birthdate
        /// </summary>
        public DateTime Birthday { get; set; }

        public int Age => GetAge(Birthday);

        /// <summary>
        /// User weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// User height
        /// </summary>
        public double Height { get; set; }

        #endregion Properties
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">user's name</param>
        /// <param name="gender">user's gender</param>
        /// <param name="birthday">user's birthday</param>
        /// <param name="weight">user's weight</param>
        /// <param name="height">user's height</param>
        public User(string name,
                    Gender gender,
                    DateTime birthday,
                    double weight,
                    double height)
        {
            #region Arguments validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            }

            if (birthday < DateTime.Parse("01.01.1900") || birthday >= DateTime.Now)
            {
                throw new ArgumentException("Дата рождения должна быть датой, не меньше 01.01.1900 и не больше текущей.", nameof(birthday));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес должен быть числом, больше 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост должен быть числом, больше 0.", nameof(height));
            }

            #endregion Arguments validation

            Name = name;
            Birthday = birthday;
            Weight = weight;
            Height = height;
        }

        private int GetAge(DateTime dateTime)
        {
            int age = DateTime.Now.Year - dateTime.Year;
            return dateTime > DateTime.Now.AddYears(-age) ? age-- : age;
        }

        public User(string name)
        {
            #region Arguments validation
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }
            #endregion Arguments validation

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
