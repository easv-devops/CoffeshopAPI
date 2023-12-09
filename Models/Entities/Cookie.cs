using System;
using System.Collections.Generic;

namespace Models.Entities;

public class Cookie
{
    public Guid Id { get; set; }

    public Guid? PredefinedCoffeeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual PredefinedCoffee? PredefinedCoffee { get; set; }
}
