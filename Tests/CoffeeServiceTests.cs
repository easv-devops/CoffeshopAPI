using Business.Service;
using Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Models.Entities;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestClass]
    public class CoffeeServiceTests
    {
        [TestMethod]
        public void GetPredefinedCoffees_ShouldReturnListOfPredefinedCoffees()
        {
            // Arrange
            var coffeeRepositoryMock = new Mock<ICoffeeRepository>();
            coffeeRepositoryMock.Setup(repo => repo.GetPredefinedCoffees()).Returns(new List<PredefinedCoffee>
            {
                new PredefinedCoffee { Id = Guid.NewGuid(), Name = "Coffee1" },
                new PredefinedCoffee { Id = Guid.NewGuid(), Name = "Coffee2" },
            });

            var coffeeService = new CoffeeService(coffeeRepositoryMock.Object);

            // Act
            var result = coffeeService.GetPredefinedCoffees();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        // Write similar tests for other methods in CoffeeService...
    }
}