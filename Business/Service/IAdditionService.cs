using Models.Entities;

namespace Business.Service;
public interface IAdditionService
{
    Cookie CreateCookie(Cookie cookie);
    Cookie UpdateCookie(Guid id, Cookie cookie);
    void DeleteCookie(Guid id);
    Cookie? GetCookie(Guid id);
    IList<Cookie> GetCookies();
    bool CookieExists(Guid id);
    
    Addition CreateAddition(Addition addition);
    Addition UpdateAddition(Guid id, Addition addition);
    void DeleteAddition(Guid id);
    Addition? GetAddition(Guid id);
    IList<Addition> GetAdditions();
    bool AdditionExists(Guid id);
    
    CoffeeBean CreateCoffeeBean(CoffeeBean coffeeBean);
    CoffeeBean UpdateCoffeeBean(Guid id, CoffeeBean coffeeBean);
    void DeleteCoffeeBean(Guid id);
    CoffeeBean? GetCoffeeBean(Guid id);
    IList<CoffeeBean> GetCoffeeBeans();
    bool CoffeeBeanExists(Guid id);
    
    BrewingMethod CreateBrewingMethod(BrewingMethod brewingMethod);
    BrewingMethod UpdateBrewingMethod(Guid id, BrewingMethod brewingMethod);
    void DeleteBrewingMethod(Guid id);
    BrewingMethod? GetBrewingMethod(Guid id);
    IList<BrewingMethod> GetBrewingMethods();
    bool BrewingMethodExists(Guid id);
    
    PickupLocation CreatePickupLocation(PickupLocation pickupLocation);
    PickupLocation? GetPickupLocation(Guid id);
    IList<PickupLocation> GetPickupLocations();
}