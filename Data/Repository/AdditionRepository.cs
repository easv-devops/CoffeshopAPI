using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repository;

public class AdditionRepository : IAdditionRepository
{
    private readonly CoffeeContext _context;

    public AdditionRepository(CoffeeContext context)
    {
        _context = context;
    }

    public Cookie CreateCookie(Cookie cookie)
    {
        _context.Add(cookie);
        _context.SaveChanges();
        return cookie;
    }

    public Cookie UpdateCookie(Guid id, Cookie cookie)
    {
        var cookieToUpdate = GetCookie(id);
        cookieToUpdate.Name = cookie.Name;
        cookieToUpdate.Price = cookie.Price;
        _context.SaveChanges();
        return cookieToUpdate;
    }

    public void DeleteCookie(Guid id)
    {
        var cookieToDelete = GetCookie(id);
        _context.Remove(cookieToDelete);
        _context.SaveChanges();
    }

    public Cookie GetCookie(Guid id)
    {
        return _context.Cookies.Find(id);
    }

    public IList<Cookie> GetCookies()
    {
        return _context.Cookies.ToList();
    }

    public IList<Cookie> GetCookiesByCoffee(Guid id)
    {
        var predefinedCoffee = _context.PredefinedCoffees.Find(id);
        return _context.Cookies.Where(c => c.PredefinedCoffee == predefinedCoffee).ToList();
    }

    public Addition CreateAddition(Addition addition)
    {
        _context.Add(addition);
        _context.SaveChanges();
        return addition;
    }

    public Addition UpdateAddition(Guid id, Addition addition)
    {
        _context.Entry(addition).State = EntityState.Modified;
        _context.SaveChanges();
        return addition;
    }

    public void DeleteAddition(Guid id)
    {
        var additionToDelete = GetAddition(id);
        _context.Remove(additionToDelete);
        _context.SaveChanges();
    }

    public Addition GetAddition(Guid id)
    {
        return _context.Additions.Find(id);
    }

    public IList<Addition> GetAdditions()
    {
        return _context.Additions.ToList();
    }

    public CoffeeBean CreateCoffeeBean(CoffeeBean coffeeBean)
    {
        _context.Add(coffeeBean);
        _context.SaveChanges();
        return coffeeBean;
    }

    public CoffeeBean UpdateCoffeeBean(Guid id, CoffeeBean coffeeBean)
    {
        _context.Entry(coffeeBean).State = EntityState.Modified;
        _context.SaveChanges();
        return coffeeBean;
    }

    public void DeleteCoffeeBean(Guid id)
    {
        var coffeeBeanToDelete = GetCoffeeBean(id);
        _context.Remove(coffeeBeanToDelete);
        _context.SaveChanges();
    }

    public CoffeeBean GetCoffeeBean(Guid id)
    {
        return _context.CoffeeBeans.Find(id);
    }
    
    public IList<CoffeeBean> GetCoffeeBeans()
    {
        return _context.CoffeeBeans.ToList();
    }
    
    public BrewingMethod CreateBrewingMethod(BrewingMethod brewingMethod)
    {
        _context.Add(brewingMethod);
        _context.SaveChanges();
        return brewingMethod;
    }
    
    public BrewingMethod UpdateBrewingMethod(Guid id, BrewingMethod brewingMethod)
    {
        _context.Entry(brewingMethod).State = EntityState.Modified;
        _context.SaveChanges();
        return brewingMethod;
    }
    
    public void DeleteBrewingMethod(Guid id)
    {
        var brewingMethodToDelete = GetBrewingMethod(id);
        _context.Remove(brewingMethodToDelete);
        _context.SaveChanges();
    }
    
    public BrewingMethod GetBrewingMethod(Guid id)
    {
        return _context.BrewingMethods.Find(id);
    }
    
    public IList<BrewingMethod> GetBrewingMethods()
    {
        return _context.BrewingMethods.ToList();
    }
    
    public bool CookieExists(Guid id)
    {
        return _context.Cookies.Any(e => e.Id == id);
    }
    
    public bool AdditionExists(Guid id)
    {
        return _context.Additions.Any(e => e.Id == id);
    }
    
    public bool CoffeeBeanExists(Guid id)
    {
        return _context.CoffeeBeans.Any(e => e.Id == id);
    }
    
    public bool BrewingMethodExists(Guid id)
    {
        return _context.BrewingMethods.Any(e => e.Id == id);
    }
    
    public PickupLocation CreatePickupLocation(PickupLocation pickupLocation)
    {
        _context.Add(pickupLocation);
        _context.SaveChanges();
        return pickupLocation;
    }
    
    public PickupLocation GetPickupLocation(Guid id)
    {
        return _context.PickupLocations.Find(id);
    }
    
    public IList<PickupLocation> GetPickupLocations()
    {
        return _context.PickupLocations.ToList();
    }
}