using Data.Repository;
using Models.Entities;

namespace Business.Service;

public class AdditionService : IAdditionService
{
    private readonly IAdditionRepository _additionRepository;

    public AdditionService(IAdditionRepository additionRepository)
    {
        _additionRepository = additionRepository;
    }

    public Cookie CreateCookie(Cookie cookie)
    {
        return _additionRepository.CreateCookie(cookie);
    }

    public Cookie UpdateCookie(Guid id, Cookie cookie)
    {
        return _additionRepository.UpdateCookie(id, cookie);
    }

    public void DeleteCookie(Guid id)
    {
        _additionRepository.DeleteCookie(id);
    }

    public Cookie? GetCookie(Guid id)
    {
        return _additionRepository.GetCookie(id);
    }

    public IList<Cookie> GetCookies()
    {
        return _additionRepository.GetCookies();
    }

    public Addition CreateAddition(Addition addition)
    {
        return _additionRepository.CreateAddition(addition);
    }

    public Addition UpdateAddition(Guid id, Addition addition)
    {
        return _additionRepository.UpdateAddition(id, addition);
    }

    public void DeleteAddition(Guid id)
    {
        _additionRepository.DeleteAddition(id);
    }

    public Addition? GetAddition(Guid id)
    {
        return _additionRepository.GetAddition(id);
    }

    public IList<Addition> GetAdditions()
    {
        return _additionRepository.GetAdditions();
    }

    public CoffeeBean CreateCoffeeBean(CoffeeBean coffeeBean)
    {
        return _additionRepository.CreateCoffeeBean(coffeeBean);
    }

    public CoffeeBean UpdateCoffeeBean(Guid id, CoffeeBean coffeeBean)
    {
        return _additionRepository.UpdateCoffeeBean(id, coffeeBean);
    }

    public void DeleteCoffeeBean(Guid id)
    {
        _additionRepository.DeleteCoffeeBean(id);
    }

    public CoffeeBean? GetCoffeeBean(Guid id)
    {
        return _additionRepository.GetCoffeeBean(id);
    }

    public IList<CoffeeBean> GetCoffeeBeans()
    {
        return _additionRepository.GetCoffeeBeans();
    }
    
    public BrewingMethod CreateBrewingMethod(BrewingMethod brewingMethod)
    {
        return _additionRepository.CreateBrewingMethod(brewingMethod);
    }
    
    public BrewingMethod UpdateBrewingMethod(Guid id, BrewingMethod brewingMethod)
    {
        return _additionRepository.UpdateBrewingMethod(id, brewingMethod);
    }
    
    public void DeleteBrewingMethod(Guid id)
    {
        _additionRepository.DeleteBrewingMethod(id);
    }
    
    public BrewingMethod? GetBrewingMethod(Guid id)
    {
        return _additionRepository.GetBrewingMethod(id);
    }
    
    public IList<BrewingMethod> GetBrewingMethods()
    {
        return _additionRepository.GetBrewingMethods();
    }
    
    public bool CookieExists(Guid id)
    {
        return _additionRepository.CookieExists(id);
    }
    
    public bool AdditionExists(Guid id)
    {
        return _additionRepository.AdditionExists(id);
    }
    
    public bool CoffeeBeanExists(Guid id)
    {
        return _additionRepository.CoffeeBeanExists(id);
    }
    
    public bool BrewingMethodExists(Guid id)
    {
        return _additionRepository.BrewingMethodExists(id);
    }
    
    public PickupLocation CreatePickupLocation(PickupLocation pickupLocation)
    {
        return _additionRepository.CreatePickupLocation(pickupLocation);
    }
    
    public PickupLocation? GetPickupLocation(Guid id)
    {
        return _additionRepository.GetPickupLocation(id);
    }
    
    public IList<PickupLocation> GetPickupLocations()
    {
        return _additionRepository.GetPickupLocations();
    }
}