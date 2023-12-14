using System;
using System.Collections.Generic;
using Business.Service;
using Data.Repository;
using Models.Entities;
using Moq;
using NUnit.Framework;
using Moq;
using Models.Entities;


namespace Tests
{
    [TestFixture]
    public class CoffeeServiceTests
    {
        private Mock<ICoffeeRepository> _coffeeRepositoryMock;
        private ICoffeeService _coffeeService;

        [SetUp]
        public void SetUp()
        {
            _coffeeRepositoryMock = new Mock<ICoffeeRepository>();
            _coffeeService = new CoffeeService(_coffeeRepositoryMock.Object);
        }

        [Test]
        public void GetPredefinedCoffees_ShouldReturnListOfPredefinedCoffees()
        {
            // Arrange
            var predefinedCoffees = new List<PredefinedCoffee> { new PredefinedCoffee(), new PredefinedCoffee() };
            _coffeeRepositoryMock.Setup(r => r.GetPredefinedCoffees()).Returns(predefinedCoffees);

            // Act
            var result = _coffeeService.GetPredefinedCoffees();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(PredefinedCoffee)));
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetPredefinedCoffee_ExistingId_ShouldReturnPredefinedCoffee()
        {
            // Arrange
            var coffeeId = Guid.NewGuid();
            var predefinedCoffee = new PredefinedCoffee { Id = coffeeId };
            _coffeeRepositoryMock.Setup(r => r.GetPredefinedCoffee(coffeeId)).Returns(predefinedCoffee);

            // Act
            var result = _coffeeService.GetPredefinedCoffee(coffeeId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(PredefinedCoffee)));
            Assert.That(result.Id, Is.EqualTo(coffeeId));
        }

        [Test]
        public void GetPredefinedCoffee_NonExistingId_ShouldReturnNull()
        {
            // Arrange
            var nonExistingCoffeeId = Guid.NewGuid();
            _coffeeRepositoryMock.Setup(r => r.GetPredefinedCoffee(nonExistingCoffeeId))
                .Returns((PredefinedCoffee)null);

            // Act
            var result = _coffeeService.GetPredefinedCoffee(nonExistingCoffeeId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void PredefinedCoffeeExists_ExistingId_ShouldReturnTrue()
        {
            // Arrange
            var existingCoffeeId = Guid.NewGuid();
            _coffeeRepositoryMock.Setup(r => r.PredefinedCoffeeExists(existingCoffeeId)).Returns(true);

            // Act
            var result = _coffeeService.PredefinedCoffeeExists(existingCoffeeId);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void PredefinedCoffeeExists_NonExistingId_ShouldReturnFalse()
        {
            // Arrange
            var nonExistingCoffeeId = Guid.NewGuid();
            _coffeeRepositoryMock.Setup(r => r.PredefinedCoffeeExists(nonExistingCoffeeId)).Returns(false);

            // Act
            var result = _coffeeService.PredefinedCoffeeExists(nonExistingCoffeeId);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdatePredefinedCoffee_ExistingId_ShouldReturnUpdatedPredefinedCoffee()
        {
            // Arrange
            var existingCoffeeId = Guid.NewGuid();
            var updatedPredefinedCoffee = new PredefinedCoffee { Id = existingCoffeeId, Name = "Updated Coffee" };
            _coffeeRepositoryMock.Setup(r => r.UpdatePredefinedCoffee(existingCoffeeId, updatedPredefinedCoffee))
                .Returns(updatedPredefinedCoffee);

            // Act
            var result = _coffeeService.UpdatePredefinedCoffee(existingCoffeeId, updatedPredefinedCoffee);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(PredefinedCoffee)));
            Assert.That(result.Id, Is.EqualTo(existingCoffeeId));
            Assert.That(result.Name, Is.EqualTo("Updated Coffee"));

        }

        [Test]
        public void DeletePredefinedCoffee_ExistingId_ShouldCallRepositoryDeletePredefinedCoffee()
        {
            // Arrange
            var existingCoffeeId = Guid.NewGuid();

            // Act
            _coffeeService.DeletePredefinedCoffee(existingCoffeeId);

            // Assert
            _coffeeRepositoryMock.Verify(r => r.DeletePredefinedCoffee(existingCoffeeId), Times.Once);
        }

        [Test]
        public void CreatePredefinedCoffee_ShouldReturnCreatedPredefinedCoffee()
        {
            // Arrange
            var newPredefinedCoffee = new PredefinedCoffee { Name = "New Coffee" };
            _coffeeRepositoryMock.Setup(r => r.CreatePredefinedCoffee(newPredefinedCoffee))
                .Returns(newPredefinedCoffee);

            // Act
            var result = _coffeeService.CreatePredefinedCoffee(newPredefinedCoffee);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(PredefinedCoffee)));
            Assert.That(result.Name, Is.EqualTo("New Coffee"));
        }
    }
}