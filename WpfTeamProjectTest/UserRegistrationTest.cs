using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfTeamProject;

namespace WpfTeamProjectTest
{
    [TestClass]
    public class UserRegistrationTest
    {
        [TestMethod]
        public void IsEmptyTest()
        {
            // Arrange
            WpfTeamProject.ViewModel.UserRegistrationViewModel stringInput = new WpfTeamProject.ViewModel.UserRegistrationViewModel() { UserName = "UserName", FirstName = "Name", LastName = ""};
            bool expected = true;

            // Act
            bool actual = stringInput.IsEmpty();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNumericInputTest()
        {
            // Arrange
            WpfTeamProject.ViewModel.UserRegistrationViewModel stringInput = new WpfTeamProject.ViewModel.UserRegistrationViewModel() { PhoneNumber = 1};
            bool expected = false;

            // Act
            bool actual = stringInput.IsNumericInput(stringInput.PhoneNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
