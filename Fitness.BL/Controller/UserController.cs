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

        public bool IsNewUser { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User's name</param>
        public UserController(string userName)
        {
            /// TODO : Проверка входных данных

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.FirstOrDefault(e => e.Name == userName);

            IsNewUser = CurrentUser is null;

        }


        /// <summary>
        /// Set a Data with validation for a new user
        /// </summary>
        /// <param name="user">User's name</param>
        public void SetNewUserData(string _name, string _gender, string _birthday, string _weight = "1", string _height = "1")
        {
            /// TODO : Проверка входных данных

            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(_name));
            }

            if (string.IsNullOrWhiteSpace(_gender))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(_gender));
            }
            CurrentUser.Gender = new Gender(_gender);

            if (DateTime.TryParse(_birthday, out DateTime dateTime))
            {
                CurrentUser.Birthday = dateTime;
            }

            if (Int32.TryParse(_weight, out int weight))
            {
                CurrentUser.Weight = weight;
            }

            if (Int32.TryParse(_height, out int height))
            {
                CurrentUser.Height = height;
            }
            Save();


            Users.Add(new User(_name,new Gender(_gender), Convert.ToDateTime(_birthday), Convert.ToDouble(weight), Convert.ToDouble(height)));
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
                if (fs.Length > 0 && (formatter.Deserialize(fs) is List<User> users))
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
