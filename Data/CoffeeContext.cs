using Microsoft.EntityFrameworkCore;

namespace Data;

public class CoffeeContext : DbContext
{
    public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
    {
        
    }
}