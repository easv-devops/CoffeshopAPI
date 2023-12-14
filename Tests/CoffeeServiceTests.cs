using Business.Service;
using Data.Repository;
using Moq;
using Models.Entities;

namespace Tests
{
    [TestFixture]
    public class CoffeeServiceTests
    {
        private CoffeeService _coffeeService;
        
        [SetUp]
        public void Setup()
        {
            _coffeeService = new CoffeeService(new CoffeeRepository(new CoffeeContext()));
        }
        
        [Test]
        public void GetPredefinedCoffees_ShouldReturnListOfPredefinedCoffees()
        {
            // Act
            var result = _coffeeService.GetPredefinedCoffees();

            // Assert
            Assert.That(result, Is.InstanceOf(typeof(IList<PredefinedCoffee>)));
        }
    }
}