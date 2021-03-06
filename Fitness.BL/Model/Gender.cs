﻿using System;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Class Gender
    /// </summary>
    public class Gender
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender() { }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name">Gender</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
