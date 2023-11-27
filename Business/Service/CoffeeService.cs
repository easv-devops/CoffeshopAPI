using Data.Repository;
using Models.Entities;

namespace Business.Service;

public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;
    
    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }
    
    public IList<PredefinedCoffee> GetPredefinedCoffees()
    {
        return _coffeeRepository.GetPredefinedCoffees();
    }
    
    public PredefinedCoffee? GetPredefinedCoffee(Guid id)
    {
        return _coffeeRepository.GetPredefinedCoffee(id);
    }
    
    public bool PredefinedCoffeeExists(Guid id)
    {
        return _coffeeRepository.PredefinedCoffeeExists(id);
    }
    
    public PredefinedCoffee UpdatePredefinedCoffee(Guid id, PredefinedCoffee coffee)
    {
        return _coffeeRepository.UpdatePredefinedCoffee(id, coffee);
    }
    
    public void DeletePredefinedCoffee(Guid id)
    {
        _coffeeRepository.DeletePredefinedCoffee(id);
    }
    
    public PredefinedCoffee CreatePredefinedCoffee(PredefinedCoffee coffee)
    {
        return _coffeeRepository.CreatePredefinedCoffee(coffee);
    }
    
    public IList<CustomCoffee> GetCustomCoffees()
    {
        return _coffeeRepository.GetCustomCoffees();
    }
    
    public CustomCoffee? GetCustomCoffee(Guid id)
    {
        return _coffeeRepository.GetCustomCoffee(id);
    }
    
    public bool CustomCoffeeExists(Guid id)
    {
        return _coffeeRepository.CustomCoffeeExists(id);
    }
    
    public CustomCoffee UpdateCustomCoffee(Guid id, CustomCoffee coffee)
    {
        return _coffeeRepository.UpdateCustomCoffee(id, coffee);
    }
    
    public void DeleteCustomCoffee(Guid id)
    {
        _coffeeRepository.DeleteCustomCoffee(id);
    }
    
    public CustomCoffee CreateCustomCoffee(CustomCoffee coffee)
    {
        return _coffeeRepository.CreateCustomCoffee(coffee);
    }
}