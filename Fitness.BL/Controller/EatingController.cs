﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Class EatingConrtroller
    /// </summary>
    public class EatingController : ControllerBase
    {

        //private const string FOODS_FILE_NAME = "foods.dat";

        //private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Полученный пользователь равен null", nameof(user));

            Foods = Load<Food>() ?? new List<Food>();
            Eating = Load<Eating>()?.FirstOrDefault() ?? new Eating(this.user);
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.FirstOrDefault(e => e.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save<Food>(Foods);
            }
            else
            {
                Eating.Add(product, weight);
            }
            Save<Eating>(new List<Eating> { Eating });
        }

    }
}
