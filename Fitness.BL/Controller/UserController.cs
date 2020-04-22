using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Class UserController
    /// </summary>
    public class UserController : ControllerBase
    {

        //private const string USERS_FILE_NAME = "users.dat";

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

            Users = Load<User>() ?? new List<User>();

            CurrentUser = Users.FirstOrDefault(e => e.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
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
            CurrentUser.Birthday = birthday;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save<User>(Users);

        }

    }
}
