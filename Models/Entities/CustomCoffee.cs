using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class CustomCoffee
{
    public Guid Id { get; set; }

    public Guid BeanId { get; set; }

    public Guid BrewingId { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual CoffeeBean Bean { get; set; } = null!;

    public virtual BrewingMethod Brewing { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
