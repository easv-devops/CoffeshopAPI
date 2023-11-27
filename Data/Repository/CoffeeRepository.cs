using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repository;

public class CoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeContext _context;

    public CoffeeRepository(CoffeeContext context)
    {
        _context = context;
    }

    public IList<PredefinedCoffee> GetPredefinedCoffees()
    {
        return _context.PredefinedCoffees.ToList();
    }

    public PredefinedCoffee GetPredefinedCoffee(Guid id)
    {
        return _context.PredefinedCoffees.Find(id);
    }

    public bool PredefinedCoffeeExists(Guid id)
    {
        return _context.PredefinedCoffees.Any(e => e.Id == id);
    }

    public PredefinedCoffee UpdatePredefinedCoffee(Guid id, PredefinedCoffee coffee)
    {
        _context.Entry(coffee).State = EntityState.Modified;
        _context.SaveChanges();
        return coffee;
    }

    public void DeletePredefinedCoffee(Guid id)
    {
        var coffee = _context.PredefinedCoffees.Find(id);
        _context.PredefinedCoffees.Remove(coffee);
        _context.SaveChanges();
    }

    public PredefinedCoffee CreatePredefinedCoffee(PredefinedCoffee coffee)
    {
        _context.PredefinedCoffees.Add(coffee);
        _context.SaveChanges();
        return coffee;
    }

    public IList<CustomCoffee> GetCustomCoffees()
    {
        return _context.CustomCoffees.ToList();
    }

    public CustomCoffee GetCustomCoffee(Guid id)
    {
        return _context.CustomCoffees.Find(id);
    }

    public bool CustomCoffeeExists(Guid id)
    {
        return _context.CustomCoffees.Any(e => e.Id == id);
    }

    public CustomCoffee UpdateCustomCoffee(Guid id, CustomCoffee coffee)
    {
        _context.Entry(coffee).State = EntityState.Modified;
        _context.SaveChanges();
        return coffee;
    }

    public void DeleteCustomCoffee(Guid id)
    {
        var coffee = _context.CustomCoffees.Find(id);
        _context.CustomCoffees.Remove(coffee);
        _context.SaveChanges();
    }

    public CustomCoffee CreateCustomCoffee(CustomCoffee coffee)
    {
        _context.CustomCoffees.Add(coffee);
        _context.SaveChanges();
        return coffee;
    }
}