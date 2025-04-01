using LegacyApp.Interfaces;
using LegacyApp.Services;

namespace UserServiceTest
{
    public class Tests
    {
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _userService = new UserService();
        }

        [Test]
        public void AddUser_WithValidNormalClient_ShouldReturnTrue()
        {
            string firstName = "John";
            string lastName = "Doe";
            string email = "john.doe@example.com";
            DateTime dateOfBirth = new DateTime(1990, 1, 1);
            int clientId = 1;

            bool result = _userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

            Assert.IsTrue(result, "User should be added successfully.");
        }

        [Test]
        public void AddUser_WithInvalidEmail_ShouldReturnFalse()
        {
            string firstName = "John";
            string lastName = "Doe";
            string email = "invalid-email";
            DateTime dateOfBirth = new DateTime(1990, 1, 1);
            int clientId = 1;

            bool result = _userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

            Assert.IsFalse(result, "User should not be added due to invalid email.");
        }
    }
}