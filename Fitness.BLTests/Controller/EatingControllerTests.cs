﻿using Fitness.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, rnd.Next(50, 500));

            // Assert
            Assert.AreEqual(foodName.GetHashCode(), eatingController.Eating.Foods.FirstOrDefault(e => e.Key.Name.Equals(food.Name)));
        }
    }
}