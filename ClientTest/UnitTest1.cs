using NUnit.Framework;
using Fit_Fitness_Client.Models;

namespace ClientTest
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void NewClientShouldHaveAllPropertiesSet()
        {
            // Arrange
            int expectedId = 1;
            string expectedName = "Test Name";
            string expectedEmail = "test@email.com";
            string expectedPhone = "1234567890";
            string expectedUsername = "test_username";
            string expectedPassword = "test_password";

            // Act
            var client = new Client(expectedId, expectedName, expectedEmail, expectedPhone, expectedUsername, expectedPassword);

            // Assert
            Assert.That(client.id, Is.EqualTo(expectedId));
            Assert.That(client.name, Is.EqualTo(expectedName));
            Assert.That(client.email, Is.EqualTo(expectedEmail));
            Assert.That(client.phone, Is.EqualTo(expectedPhone));
            Assert.That(client.username, Is.EqualTo(expectedUsername));
            Assert.That(client.password, Is.EqualTo(expectedPassword));
        }
    }
}
