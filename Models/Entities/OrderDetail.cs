using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid? PredefinedCoffeeId { get; set; }

    public Guid? CustomCoffeeId { get; set; }

    public Guid? CookieId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual Cookie? Cookie { get; set; }

    public virtual CustomCoffee? CustomCoffee { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PredefinedCoffee? PredefinedCoffee { get; set; }
}
