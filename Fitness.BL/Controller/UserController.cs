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
    /// Class UserController
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// User
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User's name</param>
        public UserController(string userName, string genderName, string birthday, string weight, string height)
        {
            /// TODO : Проверка входных данных
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, Convert.ToDateTime(birthday), Convert.ToDouble(weight), Convert.ToDouble(height));
            //User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
        }

        public UserController()
        {
            User = Load();
            /// TODO : Что делать если пользователя не прочитали?
        }

        /// <summary>
        /// Save user's data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Load user's data from file
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            User user = null;
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                user = formatter.Deserialize(fs) as User;
            }
            return user;
        }
    }
}
