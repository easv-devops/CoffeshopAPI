using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid LocationId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderTime { get; set; }

    public DateTime PickupTime { get; set; }

    public virtual PickupLocation Location { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
