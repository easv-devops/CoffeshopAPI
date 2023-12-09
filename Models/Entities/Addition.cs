using System;
using System.Collections.Generic;

namespace Models.Entities;

public class Addition
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public virtual ICollection<CoffeeAddition> CoffeeAdditions { get; set; } = new List<CoffeeAddition>();
}
