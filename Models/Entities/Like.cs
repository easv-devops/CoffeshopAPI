using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Like
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid PredefinedCoffeeId { get; set; }

    public DateTime LikeTime { get; set; }

    public virtual PredefinedCoffee PredefinedCoffee { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
