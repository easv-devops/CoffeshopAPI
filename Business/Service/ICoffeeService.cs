using Models.Entities;

namespace Business.Service;

public interface ICoffeeService
{
    IList<PredefinedCoffee> GetPredefinedCoffees();
    PredefinedCoffee? GetPredefinedCoffee(Guid id);
    bool PredefinedCoffeeExists(Guid id);
    PredefinedCoffee UpdatePredefinedCoffee(Guid id, PredefinedCoffee coffee);
    void DeletePredefinedCoffee(Guid id);
    PredefinedCoffee CreatePredefinedCoffee(PredefinedCoffee coffee);
    
    IList<CustomCoffee> GetCustomCoffees();
    CustomCoffee? GetCustomCoffee(Guid id);
    bool CustomCoffeeExists(Guid id);
    CustomCoffee UpdateCustomCoffee(Guid id, CustomCoffee coffee);
    void DeleteCustomCoffee(Guid id);
    CustomCoffee CreateCustomCoffee(CustomCoffee coffee);
}