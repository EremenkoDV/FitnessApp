using Fitness.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        //[TestMethod()]
        //public void ExeciseControllerTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(activityName, exerciseController.Activities.FirstOrDefault(e => e.Name == activity.Name).Name);
        }
    }
}