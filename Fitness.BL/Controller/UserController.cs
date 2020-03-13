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

        public bool IsNewUser { get; } = false;

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

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }

        }

        /// <summary>
        /// Set a Data with validation for a new user
        /// </summary>
        /// <param name="user">User's name</param>
        public void SetNewUserData(string name, string gender, DateTime birthday, double weight = 1, double height = 1)
        {
            /// TODO : Проверка входных данных

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(gender));
            }

            CurrentUser.Gender = new Gender(gender);

            //if (DateTime.TryParse(_birthday, out DateTime dateTime))
            //{
            CurrentUser.Birthday = birthday;
            //}

            //if (Int32.TryParse(_weight, out int weight))
            //{
            CurrentUser.Weight = weight;
            //}

            //if (Int32.TryParse(_height, out int height))
            //{
            CurrentUser.Height = height;
            //}
            Save();


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
