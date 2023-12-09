using System;
using System.Collections.Generic;

namespace Models.Entities;

public class PickupLocation
{
    public Guid Id { get; set; }

    public string ShopName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
