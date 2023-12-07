using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class PredefinedCoffee
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Cookie> Cookies { get; set; } = new List<Cookie>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
