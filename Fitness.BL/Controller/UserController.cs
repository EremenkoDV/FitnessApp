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
        /// List of Users
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User's name</param>
        public UserController(string userName, string genderName, string birthday, string weight, string height)
        {
            /// TODO : Проверка входных данных
            
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(e => e.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }

            Gender gender = new Gender(genderName);
            Users.Add(new User(userName, gender, Convert.ToDateTime(birthday), Convert.ToDouble(weight), Convert.ToDouble(height)));
            //User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
        }

        /// <summary>
        /// Get users data
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load();
        }

        /// <summary>
        /// Save user's data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        /// <summary>
        /// Load user's data from file
        /// </summary>
        /// <returns></returns>
        public List<User> Load()
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
    }
}
