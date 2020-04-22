using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        //[TestMethod()]
        //public void UserControllerTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthday = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "м";
            var controller = new UserController(userName);

            // Act
            controller.SetNewUserData(userName, gender, birthday, weight, height);
            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthday, controller2.CurrentUser.Birthday);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        //[TestMethod()]
        //public void LoadTest()
        //{
        //    Assert.Fail();
        //}
    }
}